using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;

namespace BackgroundService.Services
{
    public class SendRenewEmailService : TimedHostedService
    {
        public SendRenewEmailService(ILogger<TimedHostedService> logger, IConfiguration iConfiguration)
            : base(logger, iConfiguration, 24)
        {
        }

        public override async void DoWork(object state)
        {
            try
            {
                var insurances = await GetInsurances();

                if (insurances.Count == 0) return;

                await mailFunctions.SendAsync($"GuardMed - Prévia de Renovação de certificados", GetEmailText(insurances), new List<string> { "contato@guardmed.com.br" }, null);
            }
            catch { }
        }

        async Task<List<VendasDbContext.Models.SeguradoProfissional>> GetInsurances()
        {
            using var command = vendasContext.Database.GetDbConnection().CreateCommand();

            command.CommandText = "pr_GetInsureToRenewSendEmail";

            await vendasContext.Database.OpenConnectionAsync();

            var viewModels = new List<VendasDbContext.Models.SeguradoProfissional>();
            using var result = await command.ExecuteReaderAsync();
            while (result.Read())
                viewModels.Add(result.CopyToEntity<VendasDbContext.Models.SeguradoProfissional>());

            return viewModels;
        }

        public string GetEmailText(List<VendasDbContext.Models.SeguradoProfissional> model)
        {
            return "<div style=\"max-width: 500px; margin-left: auto; margin-right: auto; padding: 15px; border: 1px solid #bbbbbb; background-color: #f1f1f152;\">" +
            "<div style=\"margin-bottom: 2em;\">" +
                $"<label style=\"font-size: 14px;\">Existem {model.Count} certificados com vencimento previsto para o próximo mês {DateTime.Now.AddMonths(1):MM/yyyy}.</label>" +
                "<br/>" +
                $"<label style=\"font-size: 14px;\">Acesse as adesões <a href=\"{BackgroundService.Models.InsuranceConfiguration.InsuranceWebsite}/Report/Index?status=2\">clicando aqui</a>.</label>" +
            "</div> " +
            "<div style=\"font-size: 14px;\">" +
                "Atenciosamente," +
                "<br />" +
                "Equipe GuardMed." +
            "</div>" +
        "</div>";
        }
    }
}