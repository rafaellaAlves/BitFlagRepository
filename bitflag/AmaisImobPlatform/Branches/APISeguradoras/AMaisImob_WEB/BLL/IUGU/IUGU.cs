using AMaisImob_DB.Models;
using AMaisImob_WEB.Models.Charge;
using AMaisImob_WEB.Models.IUGU;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AMaisImob_WEB.BLL.IUGU
{
    public class IUGU
    {
        public class ResponseData
        {
            public HttpStatusCode Status { get; set; }
            public Dictionary<string, object> Data { get; set; }
        }
        private string _TokenIUGU = ""; // TEST: ee89071a9631572d6bb44f31a36550f9, PROD: 04b398b607e4caad8bdaf8de8edfade0
        private readonly AMaisImob_HomologContext context;

        private HttpClient httpClient { get; set; }
        public IUGU(string tokenIUGU, AMaisImob_HomologContext context)
        {
            this.context = context;
            this._TokenIUGU = tokenIUGU;
            this.httpClient = new HttpClient();
            this.httpClient.BaseAddress = new Uri("https://api.iugu.com/v1/");
            this.httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(ASCIIEncoding.ASCII.GetBytes(string.Format("{0}:{1}", _TokenIUGU, string.Empty))));
        }

        public async Task<ResponseData> AddInvoice(Models.CompanyViewModel model, string description, int priceCents, DateTime dueDate)
        {
            #region [PRE-PROCESSING]
            Regex digitsOnly = new Regex(@"[^\d]");
            var fullPhone = model.Telefone == null ? string.Empty : digitsOnly.Replace(model.Telefone, string.Empty);
            var _phonePrefix = fullPhone.Length > 2 ? fullPhone.Substring(0, 2) : string.Empty;
            var _phone = fullPhone.Length > 2 ? fullPhone.Substring(2, fullPhone.Length - 2) : string.Empty;
            #endregion

            var _d = JsonConvert.SerializeObject(new
            {
                email = model.Email?.Trim(),
                due_date = dueDate.ToString("yyyy-MM-dd"),
                ensure_workday_due_date = true,
                items = new[] { new { description = description, quantity = 1, price_cents = priceCents } },
                //return_url = return_url,
                //notification_url = return_url,
                payable_with = "bank_slip",
                payer = new
                {
                    cpf_cnpj = string.IsNullOrWhiteSpace(model.Cpf) ? model.Cnpj : model.Cpf,
                    name = model.RazaoSocial + (string.IsNullOrWhiteSpace(model.FirstName) ? "" : " (" + string.Format("{0} {1}", model.FirstName, model.LastName) + ")"),
                    phone_prefix = _phonePrefix,
                    phone = _phone,
                    email = model.Email?.Trim(),
                    address = new
                    {
                        street = model.Endereco,
                        number = model.Numero,
                        district = model.Bairro,
                        city = model.Cidade,
                        state = model.Uf,
                        zip_code = model.Cep,
                        complement = model.Complemento,
                        country = "Brasil"
                    }
                }
            });
            var httpResponseMessage = await httpClient.PostAsync("invoices", new StringContent(_d, Encoding.UTF8, "application/json"));
            var o = JsonConvert.DeserializeObject<Dictionary<string, object>>(await httpResponseMessage.Content.ReadAsStringAsync());

            return new ResponseData { Status = httpResponseMessage.StatusCode, Data = o };
        }

        public async Task<ResponseData> AddInvoice(Models.CompanyViewModel company, DateTime dueDate, List<ChargePriceItem> items, Charge charge, string email)
        {
            var iuguItems = new List<Item>();

            #region [PRE-PROCESSING]
            var priceCertificate = charge.AlternativePriceCertificate ?? charge.PriceCertificate;

            if (priceCertificate.HasValue && priceCertificate > 0)
            {
                iuguItems.Add(new Item
                {
                    description = $"Seguro Incêndio A+imob ({charge.AlternativeTotalCertificate ?? charge.TotalCertificate} itens)",
                    price_cents = Convert.ToInt32((priceCertificate) * 100d),
                    quantity = 1,
                });
            }

            if (company.ChargeContractualGuarantee == true)
            {
                foreach (var item in items.Where(x => x.CertificateContractual))
                {
                    var guarantor = await context.Guarantor.SingleAsync(x => x.GuarantorId == item.GuarantorId);

                    iuguItems.Add(new Item
                    {
                        description = $"Seguro Fiança {guarantor.RazaoSocial} ({item.AlternativeAmount ?? item.Amount} itens)",
                        price_cents = Convert.ToInt32((item.AlternativeTotalPrice ?? item.Price) * 100d),
                        quantity = 1,
                    });
                }
            }

            var priceDocuSign = charge.AlternativePriceDocuSign ?? charge.PriceDocuSign;
            if (priceDocuSign.HasValue && priceDocuSign > 0)
            {
                iuguItems.Add(new Item
                {
                    description = $"{charge.AlternativeTotalDocuSign ?? charge.TotalDocuSign}x Contratos DocuSign",
                    price_cents = Convert.ToInt32((priceDocuSign) * 100d),
                    quantity = 1,
                });
            }


            Regex digitsOnly = new Regex(@"[^\d]");
            var fullPhone = company.Telefone == null ? string.Empty : digitsOnly.Replace(company.Telefone, string.Empty);
            var _phonePrefix = fullPhone.Length > 2 ? fullPhone.Substring(0, 2) : string.Empty;
            var _phone = fullPhone.Length > 2 ? fullPhone.Substring(2, fullPhone.Length - 2) : string.Empty;
            #endregion

            var _d = JsonConvert.SerializeObject(new
            {
                email = email?.Trim(),
                due_date = dueDate.ToString("yyyy-MM-dd"),
                ensure_workday_due_date = true,
                items = iuguItems,
                payable_with = "bank_slip",
                payer = new
                {
                    cpf_cnpj = string.IsNullOrWhiteSpace(company.Cpf) ? company.Cnpj : company.Cpf,
                    name = company.RazaoSocial + (string.IsNullOrWhiteSpace(company.FirstName) ? "" : " (" + string.Format("{0} {1}", company.FirstName, company.LastName) + ")"),
                    phone_prefix = _phonePrefix,
                    phone = _phone,
                    email = email?.Trim(),
                    address = new
                    {
                        street = company.Endereco,
                        number = company.Numero,
                        district = company.Bairro,
                        city = company.Cidade,
                        state = company.Uf,
                        zip_code = company.Cep,
                        complement = company.Complemento,
                        country = "Brasil"
                    }
                }
            });
            var httpResponseMessage = await httpClient.PostAsync("invoices", new StringContent(_d, Encoding.UTF8, "application/json"));
            var o = JsonConvert.DeserializeObject<Dictionary<string, object>>(await httpResponseMessage.Content.ReadAsStringAsync());

            return new ResponseData { Status = httpResponseMessage.StatusCode, Data = o };


        }

        public async Task<ResponseData> GetInvoice(string invoiceId)
        {
            var httpResponseMessage = await httpClient.GetAsync($"invoices/{invoiceId}");
            var o = JsonConvert.DeserializeObject<Dictionary<string, object>>(await httpResponseMessage.Content.ReadAsStringAsync());

            return new ResponseData { Status = httpResponseMessage.StatusCode, Data = o };
        }

        public async Task<ResponseData> GetCustomer(string id)
        {
            var httpResponseMessage = await httpClient.GetAsync($"customers/{id}");
            var o = JsonConvert.DeserializeObject<Dictionary<string, object>>(await httpResponseMessage.Content.ReadAsStringAsync());

            return new ResponseData { Status = httpResponseMessage.StatusCode, Data = o };
        }

    }
}
