using Helpers;
using Microsoft.AspNetCore.WebUtilities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Web.Services.SeguradoProfissional;
using RestSharp;
using Web.DTO.IUGU;
using VendasDbContext.Models;

namespace Web.Services.IUGU
{
    public class IUGUService
    {
        private SeguradoProfissionalService seguradoProfissionalService;
        
        private readonly RestClient restClient;
        public IUGUService(SeguradoProfissionalService seguradoProfissionalService, VendasContext context)
        {
            var tokenIugu = context.SystemVariable.Single(x => x.Key.ToUpper().Equals("TOKENIUGU"));
            restClient = new RestClient("https://api.iugu.com/v1")
            {
                Authenticator = new RestSharp.Authenticators.HttpBasicAuthenticator(tokenIugu.Value, "")//90c90e6b039f5ebd6aade2a9309a7908 // 116478583FE8430181AE6798BF81D599 //a41f0e8ed7025602a772d37043417649
            };

            this.seguradoProfissionalService = seguradoProfissionalService;
        }


        public async Task<Invoice> GetInvoices(int seguradoProfissionalId)
        {
            var segurado = seguradoProfissionalService.GetDataById(seguradoProfissionalId);

            var request = new RestRequest("invoices", DataFormat.Json);

            request.AddParameter("created_at_from", DateTime.Now.AddMonths(-12).ToString("yyyy-MM-ddTHH:mm:ssZ")); //Obter faturas criadas a partir de 12 meses atras
            request.AddParameter("customer_id", segurado.IuguCustomerId); //7408CA4BE72E4689B065928A53D8887C //segurado.IUGU_customer_id

            return await restClient.GetAsync<Invoice>(request);
        }
        public async Task<InvoiceItem> GetInvoice(int seguradoProfissionalId)
        {
            var segurado = seguradoProfissionalService.GetDataById(seguradoProfissionalId);

            var request = new RestRequest($"invoices/{segurado.IuguInvoiceId}", DataFormat.Json); //segurado.IUGU_invoice_id;

            return await restClient.GetAsync<InvoiceItem>(request);
        }
        public async Task<Subscription> GetSubscription(int seguradoProfissionalId)
        {
            var segurado = seguradoProfissionalService.GetDataById(seguradoProfissionalId);

            var request = new RestRequest("subscriptions", DataFormat.Json);

            request.AddParameter("customer_id", segurado.IuguCustomerId); //7408CA4BE72E4689B065928A53D8887C //segurado.IUGU_customer_id
            request.AddParameter("status_filter", "active");

            return await restClient.GetAsync<Subscription>(request);
        }
        public async Task<Costumer> GetCostumer(int seguradoProfissionalId)
        {
            var segurado = seguradoProfissionalService.GetDataById(seguradoProfissionalId);

            var request = new RestRequest($"customers/{segurado.IuguCustomerId}", DataFormat.Json); //segurado.IUGU_customer_id

            return await restClient.GetAsync<Costumer>(request);
        }

    }
}
