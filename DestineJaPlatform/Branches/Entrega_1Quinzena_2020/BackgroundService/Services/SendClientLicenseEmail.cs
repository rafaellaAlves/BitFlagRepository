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
    public class SendClientLicenseEmail : EmailService<DTO.Client.ClientLicenseEmailViewModel>
    {
        public SendClientLicenseEmail(ILogger<TimedHostedService> logger, IConfiguration iConfiguration)
            : base(logger, iConfiguration)
        {
        }

        public override List<DTO.Client.ClientLicenseEmailViewModel> GetItems()
        {
            using var command = context.Database.GetDbConnection().CreateCommand();

            command.CommandText = "pr_GetClientLicenseToSendEmail";

            context.Database.OpenConnection();

            var viewModels = new List<DTO.Client.ClientLicenseEmailViewModel>();
            using var result = command.ExecuteReader();
            while (result.Read())
                viewModels.Add(
                    new DTO.Client.ClientLicenseEmailViewModel
                    {
                        ClientLicense = result.CopyToEntity<DTO.Client.ClientLicenseViewModel>(),
                        Client = result.CopyToEntity<DTO.Client.ClientViewModel>()
                    });

            return viewModels;
        }

        public override string GetSubject(DTO.Client.ClientLicenseEmailViewModel entity) => $"Destine Já - Vencimento de documento: {entity.ClientLicense.Name}";
        public override List<string> GetEmail(DTO.Client.ClientLicenseEmailViewModel entity) => entity.ClientLicense.Email.Split(";").ToList();

        public override string GetEmailTextBody(DTO.Client.ClientLicenseEmailViewModel entity)
        {
            return 
            "<div style=\"margin-bottom: 2em;\">" +
                $"<label style=\"font-size: 14px;\">Olá, <b>{entity.Client.Name}</b>.</label>" +
                "<br />" +
                $"<label style=\"font-size: 14px;\">Um documento está programado para aviso de vencimento automático.</label>" +
            "</div> " +
            "<div style=\"margin-bottom: 2em;\">" +
                $"<label style=\"font-size: 14px;\">Veja o resumo:</label>" +
                "<ul>" +
                $"<li>Nome do Documento: <b>{entity.ClientLicense.Name}</b></li>" +
                $"<li>Atividade: <b>{entity.ClientLicense.Activity.IfNullChange("-")}</b></li>" +
                $"<li>Órgão Emissor: <b>{entity.ClientLicense.Issuer}</b></li>" +
                $"<li>Data de Vencimento: <b>{entity.ClientLicense._DueDate}</b></li>" +
                $"<li>Este é o documento de licença: <b>{(string.IsNullOrWhiteSpace(entity.ClientLicense.License) ? "Não" : "Sim")} </b></li>" +
                "</ul>" +
            "</div>" +
            "<div style=\"margin-bottom: 2em;\">" +
                $"<label style=\"font-size: 14px;\">Para mais detalhes acesso o site <a style=\"font-size: 14px;\" href=\"{Site}ClientLicense\">sistema</a>.</label>" +
            "</div>";
        }
    }
}