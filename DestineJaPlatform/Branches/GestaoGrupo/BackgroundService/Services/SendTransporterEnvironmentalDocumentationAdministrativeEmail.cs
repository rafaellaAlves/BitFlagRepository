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
    public class SendTransporterEnvironmentalDocumentationAdministrativeEmail : EmailService<DTO.Transporter.TransporterEnvironmentalDocumentationEmailViewModel>
    {
        public SendTransporterEnvironmentalDocumentationAdministrativeEmail(ILogger<TimedHostedService> logger, IConfiguration iConfiguration)
            : base(logger, iConfiguration)
        {
        }

        public override List<DTO.Transporter.TransporterEnvironmentalDocumentationEmailViewModel> GetItems()
        {
            using var command = context.Database.GetDbConnection().CreateCommand();

            command.CommandText = "pr_GetTransporterEnvironmentalDocumentationToSendEmail @DaysToNotify = @_DaysToNotify";

            command.Parameters.Add(new SqlParameter("@_DaysToNotify", 30));

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

        public override string GetSubject(DTO.Transporter.TransporterEnvironmentalDocumentationEmailViewModel entity) => $"{entity.Transporter.Name} está com documentações a vencer.";
        public override List<string> GetEmail(DTO.Transporter.TransporterEnvironmentalDocumentationEmailViewModel entity) => new List<string> { "operacional@destineja.com.br" };

        public override string GetEmailTextBody(DTO.Transporter.TransporterEnvironmentalDocumentationEmailViewModel entity)
        {
            

            return
            "<div style=\"margin-bottom: 2em;\">" +
                $"<label style=\"font-size: 14px;\">O transportador <b>{entity.Transporter.Name}</b> está com documentação para vencer <b>{entity.TransporterEnvironmentalDocumentation.Name}</b> (<b>{entity.TransporterEnvironmentalDocumentation._DueDate}</b>). Renove-a para regularizar o cadastro no <a href=\"{Site}Transporter/Manage/{entity.Transporter.TransporterId}\">sistema</a>." +
            "</div>";
        }
    }
}