using DTO.Sintegra;
using Newtonsoft.Json;
using Services.SystemVariable;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Services.Sintegra
{
    public class SintegraService
    {
        private HttpClient HttpClient { get; }
        private string Token { get; }

        public SintegraService(SystemVariableServices systemVariableService)
        {
            this.Token = systemVariableService.GetDataById("Sintegra.Token").Value;

            this.HttpClient = new HttpClient { BaseAddress = new Uri("https://www.sintegraws.com.br/api/v1/") };
        }

        public async Task<SintegraResultViewModel> GetDataByCNPJ(string cnpj)
        {
#if DEBUG
            cnpj = "06990590000123";
#endif
            var httpResponseMessage = await HttpClient.GetAsync($"execute-api.php?token={this.Token}&cnpj={cnpj}&plugin=ST");
            return JsonConvert.DeserializeObject<SintegraResultViewModel>(await httpResponseMessage.Content.ReadAsStringAsync());
        }
    }
}
