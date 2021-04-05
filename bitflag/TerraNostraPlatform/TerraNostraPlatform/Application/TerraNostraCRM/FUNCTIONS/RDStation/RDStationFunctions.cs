using DTO.RDStation;
using FUNCTIONS.SystemVariable;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace FUNCTIONS.RDStation
{
    public class RDStationFunctions
    {
        HttpClient HttpClient { get; }
        SystemVariableFunctions SystemVariableFunctions { get; }

        public RDStationFunctions(SystemVariableFunctions systemVariableFunctions)
        {
            SystemVariableFunctions = systemVariableFunctions;

            this.HttpClient = new HttpClient { BaseAddress = new Uri("https://api.rd.services/") };
        }

        #region [SHARED]
        public async Task<string> GetToken()
        {
            var _d = JsonConvert.SerializeObject(new
            {
                client_id = SystemVariableFunctions.Get("RDStation.ClientId"),
                client_secret = SystemVariableFunctions.Get("RDStation.ClientSecret"),
                code = SystemVariableFunctions.Get("RDStation.Code")
            });

            var httpResponseMessage = await HttpClient.PostAsync("auth/token", new StringContent(_d, Encoding.UTF8, "application/json"));
            var o = JsonConvert.DeserializeObject<Dictionary<string, object>>(await httpResponseMessage.Content.ReadAsStringAsync());

            if (httpResponseMessage.StatusCode != System.Net.HttpStatusCode.OK) return "";

            return o["access_token"].ToString();
        }

        public async Task<RDStationResponse<T>> RDStationPost<T>(string requestUri, HttpContent httpContent)
        {
            this.HttpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", await GetToken());

            var httpResponseMessage = await HttpClient.PostAsync(requestUri, httpContent);
            var o = JsonConvert.DeserializeObject<T>(await httpResponseMessage.Content.ReadAsStringAsync());

            return new RDStationResponse<T>(httpResponseMessage.StatusCode, o);
        }
        #endregion



    }
}
