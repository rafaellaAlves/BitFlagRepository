using BackgroundService.Services.Shared;
using DTO.Utils;
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

namespace BackgroundService.Services
{
    public class SendClientLicenseConditioningEmail : EmailService<DTO.Client.ClientLicenseConditioningEmailViewModel>
    {
        public SendClientLicenseConditioningEmail(ILogger<TimedHostedService> logger, IConfiguration iConfiguration)
            : base(logger, iConfiguration)
        {
        }

        public override string GetEmailTextBody(DTO.Client.ClientLicenseConditioningEmailViewModel entity)
        {
            return
            "<div style=\"margin-bottom: 2em;\">" +
                $"<label style=\"font-size: 14px;\">Olá, <b>{entity.Client.Name}</b>.</label>" +
                "<br />" +
                $"<label style=\"font-size: 14px;\">A condicionante <b>{entity.Conditioning.Description}</b>, da licença {entity.ClientLicenseName}, está programado para aviso de vencimento automático em {entity.Conditioning.DaysToNotify} dias <b>({entity.EndDateFormated})</b>.</label>" +
            "</div> " +
            "<div style=\"margin-bottom: 2em;\">" +
                $"<label style=\"font-size: 14px;\">Veja o resumo:</label>" +
                "<ul>" +
                $"<li>Nome da Licença/Documento: <b>{entity.ClientLicenseName}</b></li>" +
                $"<li>Número e nome da condicionante: <b>{entity.Conditioning.Number} - {entity.Conditioning.Description}</b></li>" +
                $"<li>Prazo para cumprimento: <b>{entity.Conditioning.DaysToRegularize} dias</b></li>" +
                $"<li>Frequencia/Recorrência do vencimento: <b>{entity.ClientLicenseConditioningPeriodicityName}</b></li>" +
                $"<li>Dias para o vencimento: <b>{entity.Conditioning.DaysToNotify} dias</b></li>" +
                "</ul>" +
            "</div>" +
            "<div style=\"margin-bottom: 2em;\">" +
                $"<label style=\"font-size: 14px;\">Após a renovação entre no <a style=\"font-size: 14px;\" href=\"{Site}ClientLicenseConditioning?clientLicenseId={entity.Conditioning.ClientLicenseConditioningId}\">sistema</a> para apontar o número do protocolo, data do protocolo e o upload de evidências. Após o processo não deixe de clicar em renovar. e acesse o sistema para mais detalhes.</label>" +
                "<br/>" +
                $"<label style=\"font-size: 14px;\">O próximo aviso será <b>{entity.Conditioning.DaysToNotify} dias</b> antes do vencimento.</label>" +
            "</div>";
        }

        public override List<DTO.Client.ClientLicenseConditioningEmailViewModel> GetItems()
        {
            using var command = context.Database.GetDbConnection().CreateCommand();

            command.CommandText = "pr_GetClientLicenseConditioningToSendEmail";

            context.Database.OpenConnection();

            var viewModels = new List<DTO.Client.ClientLicenseConditioningEmailViewModel>();
            using var result = command.ExecuteReader();
            while (result.Read())
                viewModels.Add(
                    new DTO.Client.ClientLicenseConditioningEmailViewModel
                    {
                        Conditioning = result.CopyToEntity<DTO.Client.ClientLicenseConditioningViewModel>(),
                        Client = result.CopyToEntity<DTO.Client.ClientViewModel>(),
                        ClientLicenseEmail = result["ClientLicenseEmail"].GetStringFromDbDataReader(),
                        EndDate = result["EndDate"].GetDateTimeFromDbDataReader().Value,
                        ClientLicenseName = result["ClientLicenseName"].GetStringFromDbDataReader(),
                        ClientLicenseConditioningPeriodicityName = result["ClientLicenseConditioningPeriodicityName"].GetStringFromDbDataReader(),
                    });

            return viewModels;
        }

        public override string GetSubject(DTO.Client.ClientLicenseConditioningEmailViewModel entity) => $"Destine Já - Aviso de Condicionante: {entity.Conditioning.Description}";
        public override List<string> GetEmail(DTO.Client.ClientLicenseConditioningEmailViewModel entity) => entity.ClientLicenseEmail.Split(";").ToList();
    }
}
