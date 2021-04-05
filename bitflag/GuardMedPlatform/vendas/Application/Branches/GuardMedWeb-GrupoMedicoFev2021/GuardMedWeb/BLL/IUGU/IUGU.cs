using Microsoft.Extensions.Configuration;
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

namespace GuardMedWeb.BLL.IUGU
{
    public class IUGU
    {
        readonly IConfiguration configuration;

        public class ResponseData
        {
            public HttpStatusCode Status { get; set; }
            public Dictionary<string, object> Data { get; set; }
        }
        private string _TokenIUGU = "90c90e6b039f5ebd6aade2a9309a7908"; // TEST: 90c90e6b039f5ebd6aade2a9309a7908, PROD: a41f0e8ed7025602a772d37043417649  // TEST: ee89071a9631572d6bb44f31a36550f9, PROD: 04b398b607e4caad8bdaf8de8edfade0
        private string _IUGUID = "116478583FE8430181AE6798BF81D599";


        private HttpClient httpClient { get; set; }
        public IUGU(string tokenIUGU, string IUGUID, IConfiguration configuration)
        {
            this.configuration = configuration;

            this._IUGUID = IUGUID;
            this._TokenIUGU = tokenIUGU;
            this.httpClient = new HttpClient();
            this.httpClient.BaseAddress = new Uri("https://api.iugu.com/v1/");
            this.httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(ASCIIEncoding.ASCII.GetBytes(string.Format("{0}:{1}", _TokenIUGU, string.Empty))));
        }

        public class Subitem
        {
            public string description { get; set; }
            public int price_cents { get; set; }
            public int quantity { get; set; }
            public bool recurrent { get; set; }
        }

        public async Task<ResponseData> PaymentToken(string number, string first_name, string last_name, string month, string year, string verification_value)
        {
            object d;

            if (configuration.GetValue<bool>("IsHomolog"))
            {
                d = new
                {
                    account_id = this._IUGUID,
                    method = "credit_card",
                    test = true,
                    data = new
                    {
                        number = number,
                        verification_value = verification_value,
                        first_name = first_name,
                        last_name = last_name,
                        month = month,
                        year = year
                    }
                };
            }
            else
            {
                d = new
                {
                    account_id = this._IUGUID,
                    method = "credit_card",
#if DEBUG
                    test = true,
#endif
                    data = new
                    {
                        number = number,
                        verification_value = verification_value,
                        first_name = first_name,
                        last_name = last_name,
                        month = month,
                        year = year
                    }
                };
            }

            var _d = JsonConvert.SerializeObject(d);

            var httpResponseMessage = await httpClient.PostAsync("payment_token", new StringContent(_d, Encoding.UTF8, "application/json"));
            var o = JsonConvert.DeserializeObject<Dictionary<string, object>>(await httpResponseMessage.Content.ReadAsStringAsync());

            return new ResponseData { Status = httpResponseMessage.StatusCode, Data = o };
        }

        public async Task<ResponseData> AddCustomer(Models.SeguradoProfissionalViewModel model)
        {
            #region [PRE-PROCESSING]
            Regex digitsOnly = new Regex(@"[^\d]");
            var fullPhone = digitsOnly.Replace(model.Celular, string.Empty);
            var _phonePrefix = fullPhone.Length > 2 ? fullPhone.Substring(0, 2) : string.Empty;
            var _phone = fullPhone.Length > 3 ? fullPhone.Substring(2, fullPhone.Length - 3) : string.Empty;
            #endregion

            var data = new[]
                {
                    new { name = "Referência", value = model.Referencia },
                    new { name = "CRM", value = model.CRM },
                    new { name = "EstadoCRM", value = model.EstadoCRM },
                    new { name = "DataDeNascimento", value = model._DataNascimento },
                    new { name = "DataDeCadastro", value = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss") }
                };

            if (model.Idade > 40)
            {
                data = new[]
                {
                    new { name = "Referência", value = model.Referencia },
                    new { name = "CRM", value = model.CRM },
                    new { name = "EstadoCRM", value = model.EstadoCRM },
                    new { name = "DataDeNascimento", value = model._DataNascimento },
                    new { name = "DataDeCadastro", value = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss") },
                    new { name = "Doenças", value = model.Doencas },
                    new { name = "DoençasAtuais", value = model.DoencasAtuais },
                    new { name = "Medicamentos", value = model.Medicamentos },
                    new { name = "Fumante", value = (model.Fumante.HasValue && model.Fumante.Value) ? "Sim" : "Não" }
                };
            }

            var _d = JsonConvert.SerializeObject(new
            {
                email = model.Email,
                name = model.Nome,
                phone = _phone,
                phone_prefix = _phonePrefix,
                cpf_cnpj = model.CPF,
                zip_code = model.CEP,
                number = model.EnderecoNumero,
                street = model.Endereco,
                city = model.Cidade,
                state = model.Estado,
                district = model.Bairro,
                complement = model.Complemento,
                custom_variables = data
            });

            var httpResponseMessage = await httpClient.PostAsync("customers", new StringContent(_d, Encoding.UTF8, "application/json"));
            var o = JsonConvert.DeserializeObject<Dictionary<string, object>>(await httpResponseMessage.Content.ReadAsStringAsync());

            return new ResponseData { Status = httpResponseMessage.StatusCode, Data = o };
        }

        public async Task<ResponseData> AddCustomer(Models.SeguradoClinicaVeterinariaViewModel model)
        {
            #region [PRE-PROCESSING]
            Regex digitsOnly = new Regex(@"[^\d]");
            var fullPhone = digitsOnly.Replace(model.Celular, string.Empty);
            var _phonePrefix = fullPhone.Length > 2 ? fullPhone.Substring(0, 2) : string.Empty;
            var _phone = fullPhone.Length > 3 ? fullPhone.Substring(2, fullPhone.Length - 3) : string.Empty;
            #endregion

            var data = new[]
            {
                new { name = "Referência", value = model.Referencia  },
                new { name = "CRMV", value = model.CRMVTecnico },
                new { name = "EstadoCRMV", value = model.CRMVEstado },
                new { name = "DataDeNascimento", value = model.DataNascimentoTecnico.Value.ToString("dd/MM/yyyy") },
                new { name = "DataDeCadastro", value = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss") }
            };

            var _d = JsonConvert.SerializeObject(new
            {
                email = model.EmailResponsavelFinanceiro,
                name = model.RazaoSocial + " (" + model.NomeContato + ")",
                phone = _phone,
                phone_prefix = _phonePrefix,
                cpf_cnpj = string.IsNullOrWhiteSpace(model.CPF) ? model.CNPJ : model.CPF,
                zip_code = model.CEP,
                number = model.EnderecoNumero,
                street = model.Endereco,
                city = model.Cidade,
                state = model.Estado,
                district = model.Bairro,
                complement = model.Complemento,
                custom_variables = data
            });

            var httpResponseMessage = await httpClient.PostAsync("customers", new StringContent(_d, Encoding.UTF8, "application/json"));
            var o = JsonConvert.DeserializeObject<Dictionary<string, object>>(await httpResponseMessage.Content.ReadAsStringAsync());

            return new ResponseData { Status = httpResponseMessage.StatusCode, Data = o };
        }

        public async Task<ResponseData> RemoveCustomer(string id)
        {
            var httpResponseMessage = await httpClient.DeleteAsync("customers/" + id);
            var o = JsonConvert.DeserializeObject<Dictionary<string, object>>(await httpResponseMessage.Content.ReadAsStringAsync());

            return new ResponseData { Status = httpResponseMessage.StatusCode, Data = o };
        }

        public async Task<ResponseData> SuspendSubscription(string id)
        {
            var httpResponseMessage = await httpClient.PostAsync($"subscriptions/{id}/suspend/", new StringContent(JsonConvert.SerializeObject(new { id }), Encoding.UTF8, "application/json"));
            var o = JsonConvert.DeserializeObject<Dictionary<string, object>>(await httpResponseMessage.Content.ReadAsStringAsync());

            return new ResponseData { Status = httpResponseMessage.StatusCode, Data = o };
        }

        public async Task<ResponseData> AddCustomerPaymentMethod(string customer_id, string description, string token, bool set_as_default)
        {
            var _d = JsonConvert.SerializeObject(new
            {
                customer_id = customer_id,
                description = description,
                token = token,
                set_as_default = set_as_default
            });

            var httpResponseMessage = await httpClient.PostAsync("customers/" + customer_id + "/payment_methods", new StringContent(_d, Encoding.UTF8, "application/json"));
            var o = JsonConvert.DeserializeObject<Dictionary<string, object>>(await httpResponseMessage.Content.ReadAsStringAsync());

            return new ResponseData { Status = httpResponseMessage.StatusCode, Data = o };
        }

        public async Task<ResponseData> RemoveCustomerPaymentMethod(string customer_id, string id)
        {
            var httpResponseMessage = await httpClient.DeleteAsync("customers/" + customer_id + "/payment_methods/" + id);
            var o = JsonConvert.DeserializeObject<Dictionary<string, object>>(await httpResponseMessage.Content.ReadAsStringAsync());

            return new ResponseData { Status = httpResponseMessage.StatusCode, Data = o };
        }

        public async Task<List<Dictionary<string, object>>> GetCustomerPaymentMethod(string customer_id)
        {
            var httpResponseMessage = await httpClient.GetAsync("customers/" + customer_id + "/payment_methods");
            var o = JsonConvert.DeserializeObject<List<Dictionary<string, object>>>(await httpResponseMessage.Content.ReadAsStringAsync());

            return o;
        }

        public async Task<ResponseData> AddSubscription(string plan_identifier, string customer_id, string payable_with, double desconto, string descricaoDesconto, double protecaoRenda, double? coberturaAdicionalDiretorChefeEquipe, double? coberturaAdicionalSocioEmpresaAreaMedica, DateTime? expires_at = null)
        {
            string _d = null;

            if (expires_at.HasValue && expires_at < DateTime.Today)
                expires_at = expires_at.Value.AddMonths(1);

            var subItems = new List<Subitem>();

            if (desconto > 0)
            {
                subItems.Add(new Subitem
                {
                    description = descricaoDesconto,
                    price_cents = -Convert.ToInt32(desconto * 100d),
                    quantity = 1,
                    recurrent = true
                });
            }

            if (protecaoRenda > 0)
            {
                subItems.Add(new Subitem
                {
                    description = "Proteção de renda contratado.",
                    price_cents = Convert.ToInt32(protecaoRenda * 100d),
                    quantity = 1,
                    recurrent = true
                });
            }

            if (coberturaAdicionalDiretorChefeEquipe.HasValue)
            {
                subItems.Add(new Subitem
                {
                    description = "Cobertura adicional para Diretor Médico e/ou Chefe de Equipe.",
                    price_cents = Convert.ToInt32(coberturaAdicionalDiretorChefeEquipe.Value * 100d),
                    quantity = 1,
                    recurrent = true
                });
            }

            if (coberturaAdicionalSocioEmpresaAreaMedica.HasValue)
            {
                subItems.Add(new Subitem
                {
                    description = "Cobertura adicional para Pessoa Jurídica.",
                    price_cents = Convert.ToInt32(coberturaAdicionalSocioEmpresaAreaMedica.Value * 100d),
                    quantity = 1,
                    recurrent = true
                });
            }

            if (desconto > 0 || protecaoRenda > 0 || coberturaAdicionalDiretorChefeEquipe.HasValue || coberturaAdicionalSocioEmpresaAreaMedica.HasValue)
            {
                _d = JsonConvert.SerializeObject(new
                {
                    plan_identifier = plan_identifier,
                    customer_id = customer_id,
                    payable_with = payable_with,
                    expires_at = expires_at.HasValue ? expires_at.Value.ToString("yyyy-MM-dd") : DateTime.Now.ToString("yyyy-MM-dd"),
                    //only_on_charge_success = true,
                    subitems = subItems
                });
            }
            else
            {
                _d = JsonConvert.SerializeObject(new
                {
                    plan_identifier = plan_identifier,
                    customer_id = customer_id,
                    payable_with = payable_with,
                    expires_at = expires_at.HasValue ? expires_at.Value.ToString("yyyy-MM-dd") : DateTime.Now.ToString("yyyy-MM-dd"),
                    //only_on_charge_success = true
                });
            }

            var httpResponseMessage = await httpClient.PostAsync("subscriptions", new StringContent(_d, Encoding.UTF8, "application/json"));
            var o = JsonConvert.DeserializeObject<Dictionary<string, object>>(await httpResponseMessage.Content.ReadAsStringAsync());

            return new ResponseData { Status = httpResponseMessage.StatusCode, Data = o };
        }

        public async Task<ResponseData> AddSubscription(string plan_identifier, double desconto, string customer_id, double protecaoRenda, double? coberturaAdicionalDiretorChefeEquipe, List<Subitem> subitems)
        {
            var _d = JsonConvert.SerializeObject(new
            {
                plan_identifier = plan_identifier,
                customer_id = customer_id,
                expires_at = DateTime.Now.AddDays(3).ToString("yyyy-MM-dd"),
                subitems = subitems?.ToArray()
            });

            var httpResponseMessage = await httpClient.PostAsync("subscriptions", new StringContent(_d, Encoding.UTF8, "application/json"));
            var o = JsonConvert.DeserializeObject<Dictionary<string, object>>(await httpResponseMessage.Content.ReadAsStringAsync());

            return new ResponseData { Status = httpResponseMessage.StatusCode, Data = o };
        }

        public async Task<ResponseData> AddInvoice(Models.SeguradoProfissionalViewModel model, string description, int price_cents, string return_url, double desconto, string descricaoDesconto, double protecaoRenda)
        {
            #region [PRE-PROCESSING]
            Regex digitsOnly = new Regex(@"[^\d]");
            var fullPhone = digitsOnly.Replace(model.Celular, string.Empty);
            var _phonePrefix = fullPhone.Length > 2 ? fullPhone.Substring(0, 2) : string.Empty;
            var _phone = fullPhone.Length > 3 ? fullPhone.Substring(2, fullPhone.Length - 3) : string.Empty;
            #endregion

            var precoSeguro = Convert.ToDouble(price_cents / 100d) - desconto;

            var items = new[] {
                    new { description = description, quantity = 1, price_cents = price_cents }
            }.ToList();

            if (desconto > 0)
            {
                items.Add(new { description = descricaoDesconto, quantity = 1, price_cents = -Convert.ToInt32(desconto * 100d) });
            }

            if (protecaoRenda > 0)
            {
                items.Add(new { description = "Proteção de renda contratado.", quantity = 1, price_cents = Convert.ToInt32(protecaoRenda * 100d) });
            }

            if (model.DiretorChefeEquipe == true && model.CoberturaAdicionalDiretorChefeEquipe == true)
            {
                items.Add(new { description = "Cobertura adicional para Diretor Médico e/ou Chefe de Equipe.", quantity = 1, price_cents = Convert.ToInt32((precoSeguro * 0.1d) * 100d) });
            }
            if (model.SocioEmpresaAreaMedica == true && model.CoberturaAdicionalSocioEmpresaAreaMedica == true)
            {
                items.Add(new { description = "Cobertura adicional para Pessoa Jurídica.", quantity = 1, price_cents = Convert.ToInt32((precoSeguro * 0.1d) * 100d) });
            }

            var _d = JsonConvert.SerializeObject(new
            {
                email = model.Email,
                due_date = DateTime.Now.AddDays(3).ToString("yyyy-MM-dd"),
                ensure_workday_due_date = true,
                items = items.ToArray(),
                //new[] {
                //    new { description = description, quantity = 1, price_cents = price_cents }
                //},
                return_url = return_url,
                payable_with = "bank_slip",
                custom_variables = new[]
            {
                    new { name = "Referência", value = model.Referencia },
                    new { name = "CRM", value = model.CRM },
                    new { name = "EstadoCRM", value = model.EstadoCRM },
                    new { name = "DataDeNascimento", value = model._DataNascimento },
                    new { name = "DataDeCadastro", value = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss") }
                },
                payer = new
                {
                    cpf_cnpj = model.CPF,
                    name = model.Nome,
                    phone_prefix = _phonePrefix,
                    phone = _phone,
                    email = model.Email,
                    address = new
                    {
                        street = model.Endereco,
                        number = model.EnderecoNumero,
                        district = model.Bairro,
                        city = model.Cidade,
                        state = model.Estado,
                        zip_code = model.CEP,
                        complement = model.Complemento,
                        country = "Brasil"
                    }
                }
            });
            var httpResponseMessage = await httpClient.PostAsync("invoices", new StringContent(_d, Encoding.UTF8, "application/json"));
            var o = JsonConvert.DeserializeObject<Dictionary<string, object>>(await httpResponseMessage.Content.ReadAsStringAsync());

            return new ResponseData { Status = httpResponseMessage.StatusCode, Data = o };
        }

        public async Task<ResponseData> AddInvoice(Models.SeguradoClinicaVeterinariaViewModel model, string description, int price_cents, string return_url)
        {
            #region [PRE-PROCESSING]
            Regex digitsOnly = new Regex(@"[^\d]");
            var fullPhone = digitsOnly.Replace(model.Celular, string.Empty);
            var _phonePrefix = fullPhone.Length > 2 ? fullPhone.Substring(0, 2) : string.Empty;
            var _phone = fullPhone.Length > 3 ? fullPhone.Substring(2, fullPhone.Length - 3) : string.Empty;
            #endregion

            var _d = JsonConvert.SerializeObject(new
            {
                email = model.Email,
                due_date = DateTime.Now.AddDays(3).ToString("yyyy-MM-dd"),
                ensure_workday_due_date = true,
                items = new[] { new { description = description, quantity = 1, price_cents = price_cents } },
                return_url = return_url,
                payable_with = "bank_slip",
                custom_variables = new[]
                {
                    new { name = "Referência", value = model.Referencia },
                    new { name = "CRMV", value = model.CRMVTecnico },
                    new { name = "EstadoCRMV", value = model.CRMVEstado },
                    new { name = "DataDeNascimento", value = model.DataNascimentoTecnico.Value.ToString("dd/MM/yyyy") },
                    new { name = "DataDeCadastro", value = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss") }
                },
                payer = new
                {
                    cpf_cnpj = string.IsNullOrWhiteSpace(model.CPF) ? model.CNPJ : model.CPF,
                    name = model.RazaoSocial + " (" + model.NomeContato + ")",
                    phone_prefix = _phonePrefix,
                    phone = _phone,
                    email = model.Email,
                    address = new
                    {
                        street = model.Endereco,
                        number = model.EnderecoNumero,
                        district = model.Bairro,
                        city = model.Cidade,
                        state = model.Estado,
                        zip_code = model.CEP,
                        complement = model.Complemento,
                        country = "Brasil"
                    }
                }
            });
            var httpResponseMessage = await httpClient.PostAsync("invoices", new StringContent(_d, Encoding.UTF8, "application/json"));
            var o = JsonConvert.DeserializeObject<Dictionary<string, object>>(await httpResponseMessage.Content.ReadAsStringAsync());

            return new ResponseData { Status = httpResponseMessage.StatusCode, Data = o };
        }

        public async Task<ResponseData> GetCustomer(string id)
        {
            var httpResponseMessage = await httpClient.GetAsync($"customers/{id}");
            var o = JsonConvert.DeserializeObject<Dictionary<string, object>>(await httpResponseMessage.Content.ReadAsStringAsync());

            return new ResponseData { Status = httpResponseMessage.StatusCode, Data = o };
        }

        public async Task<ResponseData> GetCustomers()
        {
            //var httpResponseMessage = await httpClient.GetAsync($"customers?created_at_from={new DateTime(2020, 1, 20)}");
            var httpResponseMessage = await httpClient.GetAsync($"customers?query=caiowthen@gmail.com");

            var o = JsonConvert.DeserializeObject<Dictionary<string, object>>(await httpResponseMessage.Content.ReadAsStringAsync());

            return new ResponseData { Status = httpResponseMessage.StatusCode, Data = o };
        }

        public async Task<ResponseData> GetSubscription(string costumer)
        {
            var httpResponseMessage = await httpClient.GetAsync($"subscriptions?customer_id={costumer}");
            var o = JsonConvert.DeserializeObject<Dictionary<string, object>>(await httpResponseMessage.Content.ReadAsStringAsync());

            return new ResponseData { Status = httpResponseMessage.StatusCode, Data = o };
        }

        public async Task<ResponseData> GetSubscriptionById(string subscriptionId)
        {
            var httpResponseMessage = await httpClient.GetAsync($"subscriptions/{subscriptionId}");
            var o = JsonConvert.DeserializeObject<Dictionary<string, object>>(await httpResponseMessage.Content.ReadAsStringAsync());

            return new ResponseData { Status = httpResponseMessage.StatusCode, Data = o };
        }
    }
}
