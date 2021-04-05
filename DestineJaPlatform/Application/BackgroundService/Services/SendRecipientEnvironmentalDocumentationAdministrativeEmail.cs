using BackgroundService.Services.Shared;
using DTO.Utils;
using Microsoft.Data.SqlClient;
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
    public class SendRecipientEnvironmentalDocumentationAdministrativeEmail : EmailService<DTO.Recipient.RecipientEnvironmentalDocumentationEmailViewModel>
    {
        public SendRecipientEnvironmentalDocumentationAdministrativeEmail(ILogger<TimedHostedService> logger, IConfiguration iConfiguration)
            : base(logger, iConfiguration)
        {
        }

        public override List<DTO.Recipient.RecipientEnvironmentalDocumentationEmailViewModel> GetItems()
        {
            using var command = context.Database.GetDbConnection().CreateCommand();

            command.CommandText = "pr_GetRecipientEnvironmentalDocumentationToSendEmail @DaysToNotify = @_DaysToNotify";

            command.Parameters.Add(new SqlParameter("@_DaysToNotify", 30));

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

        public override string GetSubject(DTO.Recipient.RecipientEnvironmentalDocumentationEmailViewModel entity) => $"{entity.Recipient.Name} está com documentações a vencer.";
        public override List<string> GetEmail(DTO.Recipient.RecipientEnvironmentalDocumentationEmailViewModel entity) => new List<string> { "operacional@destineja.com.br" };

        public override string GetEmailTextBody(DTO.Recipient.RecipientEnvironmentalDocumentationEmailViewModel entity)
        {
            return
            "<div style=\"margin-bottom: 2em;\">" +
                $"<label style=\"font-size: 14px;\">O destinador <b>{entity.Recipient.Name}</b> está com documentação para vencer <b>{entity.RecipientEnvironmentalDocumentation.ActivityName}</b> (<b>{entity.RecipientEnvironmentalDocumentation._DueDate}</b>). Renove-a para regularizar o cadastro no <a href=\"{Site}Recipient/Manage/{entity.Recipient.RecipientId}\">sistema</a>.</label>" +
            "</div>";
        }
    }
}
