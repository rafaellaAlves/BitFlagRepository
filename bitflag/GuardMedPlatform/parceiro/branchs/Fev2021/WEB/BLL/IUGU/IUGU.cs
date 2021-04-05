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

namespace WEB.BLL.IUGU
{
    public class IUGU
    {
        public class ResponseData
        {
            public HttpStatusCode Status { get; set; }
            public Dictionary<string, object> Data { get; set; }
        }
        private string _TokenIUGU = ""; // TEST: ee89071a9631572d6bb44f31a36550f9, PROD: 04b398b607e4caad8bdaf8de8edfade0

        private HttpClient httpClient { get; set; }
        public IUGU(string tokenIUGU)
        {
            this._TokenIUGU = tokenIUGU;
            this.httpClient = new HttpClient();
            this.httpClient.BaseAddress = new Uri("https://api.iugu.com/v1/");
            this.httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(ASCIIEncoding.ASCII.GetBytes(string.Format("{0}:{1}", _TokenIUGU, string.Empty))));
        }

        public async Task<ResponseData> AddInvoice(Models.CompanyViewModel model, string description, int priceCents, DateTime dueDate) //, string return_url
        {
            return new ResponseData { Status = HttpStatusCode.OK, Data = null };
        }
    }
}
