using BackgroundService.Services.Shared;
using DTO.Client;
using DTO.Contract;
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
    public class SendContractExpiringEmail : EmailService<ContractExpiringEmailViewModel>
    {
        public SendContractExpiringEmail(ILogger<TimedHostedService> logger, IConfiguration iConfiguration)
            : base(logger, iConfiguration)
        {
        }
        public override List<ContractExpiringEmailViewModel> GetItems()
        {
            using var command = context.Database.GetDbConnection().CreateCommand();

            command.CommandText = "pr_GetContractExpiringToSendEmail @DaysToNotify = @_DaysToNotify";

            command.Parameters.Add(new SqlParameter("@_DaysToNotify", 30));

            context.Database.OpenConnection();

            var viewModels = new List<ContractExpiringEmailViewModel>();
            using var result = command.ExecuteReader();
            while (result.Read())
                viewModels.Add(
                    new ContractExpiringEmailViewModel
                    {
                        Contract = result.CopyToEntity<ContractViewModel>(),
                        Client = result.CopyToEntity<ClientViewModel>("Client")
                    });

            return viewModels;
        }

        public override string GetSubject(ContractExpiringEmailViewModel entity) => $"{entity.Client.Name}, contrato será renovado automaticamente.";
        public override List<string> GetEmail(ContractExpiringEmailViewModel entity) => new List<string> { "comercial@destineja.com.br", "financeiro@destineja.com.br" };

        public override string GetEmailTextBody(ContractExpiringEmailViewModel entity)
        {
            return
            "<div style=\"margin-bottom: 2em;\">" +
                $"<label style=\"font-size: 14px;\">O Gerador <b>{entity.Client.Name}</b> possui contrato ativo <b>{entity.Contract.Code}</b> com início em <b>{entity.Contract._StartContract}</b> e final em <b>{entity.Contract._DueDate}</b>. Faça a renovação do contrato do cliente no <a href=\"{Site}Contract\">sistema</a>.</label>" +
            "</div>";
        }
    }
}