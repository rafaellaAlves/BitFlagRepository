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
    public class SendRecipientEnvironmentalDocumentationEmail : EmailService<DTO.Recipient.RecipientEnvironmentalDocumentationEmailViewModel>
    {
        public SendRecipientEnvironmentalDocumentationEmail(ILogger<TimedHostedService> logger, IConfiguration iConfiguration)
            : base(logger, iConfiguration)
        {
        }

        public override List<DTO.Recipient.RecipientEnvironmentalDocumentationEmailViewModel> GetItems()
        {
            using var command = context.Database.GetDbConnection().CreateCommand();

            command.CommandText = "pr_GetRecipientEnvironmentalDocumentationToSendEmail @DaysToNotify = NULL";

            context.Database.OpenConnection();

            var viewModels = new List<DTO.Recipient.RecipientEnvironmentalDocumentationEmailViewModel>();
            using var result = command.ExecuteReader();
            while (result.Read())
                viewModels.Add(
                    new DTO.Recipient.RecipientEnvironmentalDocumentationEmailViewModel
                    {
                        RecipientEnvironmentalDocumentation = result.CopyToEntity<DTO.Recipient.RecipientEnvironmentalDocumentationViewModel>(),
                        Recipient = result.CopyToEntity<DTO.Recipient.RecipientViewModel>()
                    });

            return viewModels;
        }

        public override string GetSubject(DTO.Recipient.RecipientEnvironmentalDocumentationEmailViewModel entity) => $"Destine Já - Vencimento de documento: {entity.Recipient.Name}";
        public override List<string> GetEmail(DTO.Recipient.RecipientEnvironmentalDocumentationEmailViewModel entity) => entity.RecipientEnvironmentalDocumentation.Email.Split(";").ToList();

        public override string GetEmailTextBody(DTO.Recipient.RecipientEnvironmentalDocumentationEmailViewModel entity)
        {
            return
            "<div style=\"margin-bottom: 2em;\">" +
                $"<label style=\"font-size: 14px;\">Olá, <b>{entity.Recipient.Name}</b>.</label>" +
                "<br />" +
                $"<label style=\"font-size: 14px;\">Um documento está programado para aviso de vencimento automático.</label>" +
            "</div> " +
            "<div style=\"margin-bottom: 2em;\">" +
                $"<label style=\"font-size: 14px;\">Veja o resumo:</label>" +
                "<ul>" +
                $"<li>Nome do Documento: <b>{entity.RecipientEnvironmentalDocumentation.DocumentName}</b></li>" +
                $"<li>Atividade: <b>{entity.RecipientEnvironmentalDocumentation.ActivityName.IfNullChange("-")}</b></li>" +
                $"<li>Órgão Emissor: <b>{entity.RecipientEnvironmentalDocumentation.Issuer}</b></li>" +
                $"<li>Data de Vencimento: <b>{entity.RecipientEnvironmentalDocumentation._DueDate}</b></li>" +
                "</ul>" +
            "</div>";
        }
    }
}