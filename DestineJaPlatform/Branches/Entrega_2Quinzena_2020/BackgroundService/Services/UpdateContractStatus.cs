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
    public class UpdateContractStatus : TimedHostedService
    {
        public UpdateContractStatus(ILogger<TimedHostedService> logger, IConfiguration iConfiguration)
            : base(logger, iConfiguration, 1)
        {

        }

        public override void DoWork(object state)
        {
            try
            {
                UpdateStatus();
            }
            catch { }
        }

        void UpdateStatus()
        {
            var sendedStatusId = this.context.ContractStatus.Single(x => x.ExternalCode == "CONTRATOENVIADO").ContractStatusId;
            var signedStatusId = this.context.ContractStatus.Single(x => x.ExternalCode == "CONTRATOASSINADO").ContractStatusId;

            foreach (var contract in this.context.Contract.Where(x => !x.IsDeleted && x.ContractStatusId != signedStatusId))
            {
                if (contract.AcceptTermEmailSended)
                    contract.ContractStatusId = sendedStatusId;

                if(contract.TermAccepted || !string.IsNullOrWhiteSpace(contract.FileGuidName) || contract.Signed == true)
                    contract.ContractStatusId = signedStatusId;

                this.context.Contract.Update(contract);
            }

            this.context.SaveChanges();
        }
    }
}