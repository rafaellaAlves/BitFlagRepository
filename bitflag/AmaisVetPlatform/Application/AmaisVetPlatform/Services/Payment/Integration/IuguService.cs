using DTO.Payment;
using DTO.Payment.Integration.Iugu;
using DTO.Subscription;
using Microsoft.Extensions.Options;
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

namespace Services.Payment.Integration
{
    public class IuguService
    {
        private readonly string token;
        private readonly string id;
        private readonly HttpClient httpClient;

        public IuguService(IOptions<Configuration> configuration)
        {
            this.token = configuration.Value.Token;
            this.id = configuration.Value.Id;

            this.httpClient = new HttpClient();
            this.httpClient.BaseAddress = new Uri("https://api.iugu.com/v1/");
            this.httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(ASCIIEncoding.ASCII.GetBytes(string.Format("{0}:{1}", this.token, string.Empty))));
        }

        public class Subitem
        {
            public string description { get; set; }
            public int price_cents { get; set; }
            public int quantity { get; set; }
            public bool recurrent { get; set; }
        }

        public async Task<ResponseData> PaymentToken(string number, string first_name, string last_name, string month, string year, string verificationValue)
        {
            var payload = JsonConvert.SerializeObject(new
            {
                account_id = this.id,
                method = "credit_card",
#if DEBUG
                test = true,
#endif
                data = new
                {
                    number = number,
                    verification_value = verificationValue,
                    first_name = first_name,
                    last_name = last_name,
                    month = month,
                    year = year
                }
            });

            var httpResponseMessage = await httpClient.PostAsync("payment_token", new StringContent(payload, Encoding.UTF8, "application/json"));
            var data = JsonConvert.DeserializeObject<Dictionary<string, object>>(await httpResponseMessage.Content.ReadAsStringAsync());

            return new ResponseData { Status = httpResponseMessage.StatusCode, Data = data };
        }
        public string HandleIuguPaymentTokenReponseData(ResponseData responseData, out bool hasError, out string token)
        {
            hasError = responseData.Status != System.Net.HttpStatusCode.OK;
            token = hasError ? null : Convert.ToString(responseData.Data["id"]);
            if (token != null) return null;

            var errors = JsonConvert.DeserializeObject<PaymentTokenError>(Convert.ToString(responseData.Data["errors"]));
            var stringBuilder = new StringBuilder();

            if (errors.Number != null) stringBuilder.Append("Número: " + string.Join(", ", errors.Number) + Environment.NewLine);
            if (errors.FirstName != null) stringBuilder.Append("Nome: " + string.Join(", ", errors.FirstName) + Environment.NewLine);
            if (errors.LastName != null) stringBuilder.Append("Sobrenome: " + string.Join(", ", errors.LastName) + Environment.NewLine);
            if (errors.Month != null) stringBuilder.Append("Mês: " + string.Join(", ", errors.Month) + Environment.NewLine);
            if (errors.Year != null) stringBuilder.Append("Ano: " + string.Join(", ", errors.Year) + Environment.NewLine);
            if (errors.VerificationValue != null) stringBuilder.Append("Código de Verificação: " + string.Join(", ", errors.VerificationValue) + Environment.NewLine);

            return stringBuilder.ToString();
        }
        public async Task<string> AddCustomer(SubscriptionViewModel subscriptionViewModel)
        {
            try
            {
                var payload = JsonConvert.SerializeObject(new
                {
                    email = subscriptionViewModel.Email,
                    name = subscriptionViewModel.FullName,
                    cpf_cnpj = subscriptionViewModel.CpfClean,
                    zip_code = subscriptionViewModel.ZipCode,
                    number = subscriptionViewModel.AddressNumber,
                    street = subscriptionViewModel.Address,
                    city = subscriptionViewModel.City,
                    state = subscriptionViewModel.State,
                    district = subscriptionViewModel.Neighborhood,
                    complement = subscriptionViewModel.AddressAdditionalInfo,
                    custom_variables = new object[]
                    {
                    new { name = "Referência", value = subscriptionViewModel.Reference },
                    new { name = "CRMV", value = subscriptionViewModel.Crmv },
                    new { name = "EstadoCRMV", value = subscriptionViewModel.Crmvstate },
                    new { name = "DataDeNascimento", value = subscriptionViewModel.BirthDateFormatted },
                    new { name = "DataDeCadastro", value = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss") }
                    }
                });

                var httpResponseMessage = await httpClient.PostAsync("customers", new StringContent(payload, Encoding.UTF8, "application/json"));
                var data = JsonConvert.DeserializeObject<Dictionary<string, object>>(await httpResponseMessage.Content.ReadAsStringAsync());

                if (httpResponseMessage.StatusCode != HttpStatusCode.OK) throw new Exception();

                return Convert.ToString(data["id"]);
            }
            catch
            {
                throw new PaymentException("Não foi possível criar sua conta.");
            }
        }
        public async Task<ResponseData> RemoveCustomer(string id)
        {
            var httpResponseMessage = await httpClient.DeleteAsync("customers/" + id);
            var o = JsonConvert.DeserializeObject<Dictionary<string, object>>(await httpResponseMessage.Content.ReadAsStringAsync());

            return new ResponseData { Status = httpResponseMessage.StatusCode, Data = o };
        }
        public async Task<ResponseData> AddCustomerPaymentMethod(string customer_id, string description, string token, bool set_as_default)
        {
            try
            {
                var payload = JsonConvert.SerializeObject(new
                {
                    description = description,
                    token = token,
                    set_as_default = set_as_default
                });

                var httpResponseMessage = await httpClient.PostAsync("customers/" + customer_id + "/payment_methods", new StringContent(payload, Encoding.UTF8, "application/json"));
                var data = JsonConvert.DeserializeObject<Dictionary<string, object>>(await httpResponseMessage.Content.ReadAsStringAsync());

                if (httpResponseMessage.StatusCode != HttpStatusCode.OK) throw new Exception();

                return new ResponseData { Status = httpResponseMessage.StatusCode, Data = data };
            }
            catch
            {
                throw new PaymentException("Houve um erro ao criar forma de pagamento.");
            }
        }
        public async Task<ResponseData> RemoveCustomerPaymentMethod(string customer_id, string id)
        {
            var httpResponseMessage = await httpClient.DeleteAsync("customers/" + customer_id + "/payment_methods/" + id);
            var data = JsonConvert.DeserializeObject<Dictionary<string, object>>(await httpResponseMessage.Content.ReadAsStringAsync());

            return new ResponseData { Status = httpResponseMessage.StatusCode, Data = data };
        }
        public async Task<string> AddSubscription(string plan_identifier, string customer_id, string payable_with, string expires_at)
        {
            try
            {
                var payload = JsonConvert.SerializeObject(new
                {
                    plan_identifier = plan_identifier,
                    customer_id = customer_id,
                    payable_with,
                    expires_at,
                    only_on_charge_success = (payable_with == "credit_card"),
                });

                var httpResponseMessage = await httpClient.PostAsync("subscriptions", new StringContent(payload, Encoding.UTF8, "application/json"));
                var data = JsonConvert.DeserializeObject<Dictionary<string, object>>(await httpResponseMessage.Content.ReadAsStringAsync());

                if (httpResponseMessage.StatusCode != HttpStatusCode.OK) throw new Exception();

                return Convert.ToString(data["id"]);
            }
            catch
            {
                throw new PaymentException("Houve um erro ao criar assinatura.");
            }
        }
        public string GetPayableWith(PaymentMethods paymentMethod)
        {
            switch (paymentMethod)
            {
                case PaymentMethods.BankSlip:
                    return "bank_slip";
                case PaymentMethods.CreditCard:
                    return "credit_card";
                default:
                    return string.Empty;
            }
        }
        public string GetExpirationDate(PaymentMethods paymentMethod)
        {
            switch (paymentMethod)
            {
                case PaymentMethods.BankSlip:
                    return DateTime.Now.AddDays(7).ToString("dd-MM-yyyy");
                default:
                    return DateTime.Now.ToString("dd-MM-yyyy");
            }
        }
    }
}
