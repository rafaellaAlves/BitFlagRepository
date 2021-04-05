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
    public class SendClientNoContractAndServiceEmail : EmailService<DTO.Client.ClientViewModel>
    {
        public SendClientNoContractAndServiceEmail(ILogger<TimedHostedService> logger, IConfiguration iConfiguration)
            : base(logger, iConfiguration)
        {
        }

        public override List<DTO.Client.ClientViewModel> GetItems()
        {
            using var command = context.Database.GetDbConnection().CreateCommand();

            command.CommandText = "pr_GetClientNoContractAndServiceToSendEmail";

            context.Database.OpenConnection();

            var viewModels = new List<DTO.Client.ClientViewModel>();
            using var result = command.ExecuteReader();
            while (result.Read())
                viewModels.Add(result.CopyToEntity<DTO.Client.ClientViewModel>());

            return viewModels;
        }

        public override string GetSubject(DTO.Client.ClientViewModel entity) => $"Destine Já - Hoje é um bom dia para coletar resíduos, {entity.Name}!";
        public override List<string> GetEmail(DTO.Client.ClientViewModel entity) => entity.CentralEmail.Split(";").ToList();

        public override string GetEmailTextBody(DTO.Client.ClientViewModel entity)
        {
            return 
            "<div style=\"margin-bottom: 2em;\">" +
                $"<label style=\"font-size: 14px;\">Olá, <b>{entity.Name}</b>.</label>" +
                "<br />" +
                $"<label style=\"font-size: 14px;\">Como estão as coisas?</label>" +
            "</div> " +
            "<div style=\"margin-bottom: 2em;\">" +
                $"<label style=\"font-size: 14px;\">Queremos informar que desde o dia <b>{entity.CreatedDateFormated}</b> você está cadastrado em nossos sistema e ainda não solicitou sua coleta de resíduos. Dá uma chance pra gente... <3.</label>" +
                "<br />" +
                $"<label style=\"font-size: 14px;\">Preparamos uma oferta especial para receber a sua demanda. Fale com um dos nossos consultores.</label>" +
                "<br />" +
                $"<label style=\"font-size: 14px;\">Tenha acesso a certificados e relatórios a qualquer momento em nosso sistema. Responda este e-mail e descubra tudo que podemos lhe oferecer!</label>" +
            "</div>";
        }
    }
}