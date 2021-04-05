using System;
using System.Collections.Generic;
using System.Text;
using BackgroundService.Services.Shared;
using DTO.Client;
using DTO.Contract;
using DTO.Utils;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace BackgroundService.Services
{
    public class SendConractToExpiringSitatuationEmail : EmailService<ContractExpiringEmailViewModel>
    {

        public SendConractToExpiringSitatuationEmail(ILogger<TimedHostedService> logger, IConfiguration iConfiguration)
          : base(logger, iConfiguration, 1)
        { }

        public override List<ContractExpiringEmailViewModel> GetItems()
        {
            using var command = context.Database.GetDbConnection().CreateCommand();
            command.CommandText = "SELECT * from [Contract] Con inner join Client Cli on Con.ClientId = Cli.ClientId where DATEDIFF(DAY,DueDate,GETDATE()) > -31 and DATEDIFF(DAY,DueDate,GETDATE()) < 0 ";

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
        public override string GetSubject(ContractExpiringEmailViewModel entity) => $"Contrato do Gerador {entity.Client.Name} a expirar";
#if !DEBUG
        public override List<string> GetEmail(ContractExpiringEmailViewModel entity) => new List<string> { "comercial@destineja.com.br", "financeiro@destineja.com.br" };
#else
        public override List<string> GetEmail(ContractExpiringEmailViewModel entity) => new List<string> { "joao.gregorio@bitflag.systems" };
#endif
        public override string GetEmailTextBody(ContractExpiringEmailViewModel entity)
        {
            return "<div style=\"margin-bottom: 2em;\">" +
                           $"<label style=\"font-size: 14px;\">O contrato do Gerador <b>{entity.Client.Name}</b> vai expirar em 30 dias ({entity.Contract.DueDate.Value.ToBrazilianDateFormat()}). Favor entrar em contato com o gerador para negociar a renovação.</label>" +
                       "</div>";
        }
    }
}
