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
    public class SendClientNoServiceEmail : EmailService<DTO.Client.ClientNoServiceEmailViewModel>
    {
        public SendClientNoServiceEmail(ILogger<TimedHostedService> logger, IConfiguration iConfiguration)
            : base(logger, iConfiguration)
        {
        }

        public override List<DTO.Client.ClientNoServiceEmailViewModel> GetItems()
        {
            using var command = context.Database.GetDbConnection().CreateCommand();

            command.CommandText = "pr_GetClientNoServiceToSendEmail";

            context.Database.OpenConnection();

            var viewModels = new List<DTO.Client.ClientNoServiceEmailViewModel>();
            using var result = command.ExecuteReader();
            while (result.Read())
                viewModels.Add(new DTO.Client.ClientNoServiceEmailViewModel(result.CopyToEntity<DTO.Client.ClientViewModel>(), result.CopyToEntity<DTO.Demand.DemandViewModel>("Demand"), result["VisitedDate"].GetDateTimeFromDbDataReader().Value));

            return viewModels;
        }

        public override string GetSubject(DTO.Client.ClientNoServiceEmailViewModel entity) => $"Destine Já - Estamos com saudades, {entity.Client.Name}!";
        public override List<string> GetEmail(DTO.Client.ClientNoServiceEmailViewModel entity) => entity.Client.CentralEmail.Split(";").ToList();

        public override string GetEmailTextBody(DTO.Client.ClientNoServiceEmailViewModel entity)
        {
            return
            "<div style=\"margin-bottom: 2em;\">" +
                $"<label style=\"font-size: 14px;\">Olá, <b>{entity.Client.Name}</b>.</label>" +
                "<br />" +
                $"<label style=\"font-size: 14px;\">Como estão as coisas?</label>" +
                "<br />" +
                $"<label style=\"font-size: 14px;\">Estamos com saudades!</label>" +
            "</div> " +
            "<div style=\"margin-bottom: 2em;\">" +
                $"<label style=\"font-size: 14px;\">Queremos informar que desde o dia <b>{entity.VisitedDateFormated}</b> você não solicita sua coleta de resíduos.</label>" +
                "<br />" +
                $"<label style=\"font-size: 14px;\">Preparamos uma oferta especial para receber novamente a sua demanda. Fale com um dos nossos consultores.</label>" +
                "<br />" +
                $"<label style=\"font-size: 14px;\">A sua última coleta foi em <b>{entity.VisitedDateFormated}</b>, no MTR <b>{entity.Demand.DestinaJaDemandId}</b> e o certificado e os relatórios da coleta estão disponíveis em <a href=\"{Site}\">{Site}.</a></label>" +
                "<br />" +
                $"<label style=\"font-size: 14px;\">Caso não tenha sua senha de acesso, solicite à nossa equipe respondendo este e-mail.</label>" +
            "</div>";
        }
    }
}