using AMaisImob_WEB.Models.TooSeguros;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace AMaisImob_WEB.BLL.TooSeguros
{
    public class TooSegurosFunctions
    {
        HttpClient HttpClient { get; }
        SystemVariableFunctions SystemVariableFunctions { get; }
        CertificateContractualFunctions CertificateContractualFunctions { get; }

        public TooSegurosFunctions(SystemVariableFunctions systemVariableFunctions, CertificateContractualFunctions certificateContractualFunctions)
        {
            this.SystemVariableFunctions = systemVariableFunctions;
            this.CertificateContractualFunctions = certificateContractualFunctions;

#if DEBUG
            this.HttpClient = new HttpClient { BaseAddress = new Uri("https://app-hom-gateway.tooseguros.com.br/") };
#else
            this.HttpClient = new HttpClient { BaseAddress = new Uri("https://api.tooseguros.com.br/") };
#endif

            this.HttpClient.DefaultRequestHeaders.Add("clientId", SystemVariableFunctions.GetSystemVariable("TooSeguros.ClientId"));
            this.HttpClient.DefaultRequestHeaders.Add("clientSecret", SystemVariableFunctions.GetSystemVariable("TooSeguros.SecretId"));
        }

        #region [SHARED]
        public async Task<string> GetToken()
        {
            var httpResponseMessage = await HttpClient.GetAsync("authentication");
            var o = JsonConvert.DeserializeObject<Dictionary<string, object>>(await httpResponseMessage.Content.ReadAsStringAsync());

            if (httpResponseMessage.StatusCode != System.Net.HttpStatusCode.OK) return "";

            return o["accessToken"].ToString();
        }

        async Task<TooSegurosResponse<T>> TooSegurosPost<T>(string requestUri, HttpContent httpContent)
        {
            this.HttpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", await GetToken());

            var httpResponseMessage = await HttpClient.PostAsync($"/api/v1/{requestUri}", httpContent);
            var o = JsonConvert.DeserializeObject<T>(await httpResponseMessage.Content.ReadAsStringAsync());

            return new TooSegurosResponse<T>(httpResponseMessage.StatusCode, o);
        }

        async Task<TooSegurosResponse<T>> TooSegurosGet<T>(string requestUri)
        {
            this.HttpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", await GetToken());

            var httpResponseMessage = await HttpClient.GetAsync($"/api/v1/{requestUri}");
            var o = JsonConvert.DeserializeObject<T>(await httpResponseMessage.Content.ReadAsStringAsync());

            return new TooSegurosResponse<T>(httpResponseMessage.StatusCode, o);
        }
        #endregion

        public async Task<TooSegurosResponse<int>> CreateProposal(int certificateContractualId)
        {
            var certificateContractual = CertificateContractualFunctions.GetDataByID(certificateContractualId);

            //TODO: provavelmente o CPF inserido na url abaixo não será do cliente
            return await TooSegurosPost<int>($"clientes/{certificateContractual.CPFCNPJ}/propostas", new StringContent(JsonConvert.SerializeObject(new ProposalRequestViewModel(certificateContractual)), Encoding.UTF8, "application/json"));
        }
    }
}
