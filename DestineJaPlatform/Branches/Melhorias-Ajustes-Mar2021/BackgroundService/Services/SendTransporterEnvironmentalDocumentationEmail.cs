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
    public class SendTransporterEnvironmentalDocumentationEmail : EmailService<DTO.Transporter.TransporterEnvironmentalDocumentationEmailViewModel>
    {
        public SendTransporterEnvironmentalDocumentationEmail(ILogger<TimedHostedService> logger, IConfiguration iConfiguration)
            : base(logger, iConfiguration)
        {
        }

        public override List<DTO.Transporter.TransporterEnvironmentalDocumentationEmailViewModel> GetItems()
        {
            using var command = context.Database.GetDbConnection().CreateCommand();

            command.CommandText = "pr_GetTransporterEnvironmentalDocumentationToSendEmail @DaysToNotify = NULL";

            context.Database.OpenConnection();

            var viewModels = new List<DTO.Transporter.TransporterEnvironmentalDocumentationEmailViewModel>();
            using var result = command.ExecuteReader();
            while (result.Read())
                viewModels.Add(
                    new DTO.Transporter.TransporterEnvironmentalDocumentationEmailViewModel
                    {
                        TransporterEnvironmentalDocumentation = result.CopyToEntity<DTO.Transporter.TransporterEnvironmentalDocumentationViewModel>(),
                        Transporter = result.CopyToEntity<DTO.Transporter.TransporterViewModel>()
                    });

            return viewModels;
        }

        public override string GetSubject(DTO.Transporter.TransporterEnvironmentalDocumentationEmailViewModel entity) => $"Destine Já - Vencimento de documento: {entity.Transporter.Name}";
        public override List<string> GetEmail(DTO.Transporter.TransporterEnvironmentalDocumentationEmailViewModel entity) => entity.TransporterEnvironmentalDocumentation.Email.Split(";").ToList();

        public override string GetEmailTextBody(DTO.Transporter.TransporterEnvironmentalDocumentationEmailViewModel entity)
        {
            return
            "<div style=\"margin-bottom: 2em;\">" +
                $"<label style=\"font-size: 14px;\">Olá, <b>{entity.Transporter.Name}</b>.</label>" +
                "<br />" +
                $"<label style=\"font-size: 14px;\">Um documento está programado para aviso de vencimento automático.</label>" +
            "</div> " +
            "<div style=\"margin-bottom: 2em;\">" +
                $"<label style=\"font-size: 14px;\">Veja o resumo:</label>" +
                "<ul>" +
                $"<li>Nome do Documento: <b>{entity.TransporterEnvironmentalDocumentation.Name}</b></li>" +
                $"<li>Atividade: <b>{entity.TransporterEnvironmentalDocumentation.ActivityName.IfNullChange("-")}</b></li>" +
                $"<li>Órgão Emissor: <b>{entity.TransporterEnvironmentalDocumentation.Issuer}</b></li>" +
                $"<li>Data de Vencimento: <b>{entity.TransporterEnvironmentalDocumentation._DueDate}</b></li>" +
                $"<li>Este é o documento de licença: <b>{(string.IsNullOrWhiteSpace(entity.TransporterEnvironmentalDocumentation.License) ? "Não" : "Sim")} </b></li>" +
                "</ul>" +
            "</div>";
        }
    }
}