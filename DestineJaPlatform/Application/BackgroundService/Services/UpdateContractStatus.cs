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
                UpdateExpiringContracts();
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

                if (contract.TermAccepted || !string.IsNullOrWhiteSpace(contract.FileGuidName) || contract.Signed == true)
                    contract.ContractStatusId = signedStatusId;

                this.context.Contract.Update(contract);
            }

            this.context.SaveChanges();
        }

        void UpdateExpiringContracts()
        {
            var signedStatusId = this.context.ContractStatus.Single(x => x.ExternalCode == "CONTRATOASSINADO").ContractStatusId;
            var expireSituation = this.context.ContractSituation.Single(x => x.ExternalCode == "AEXPIRAR").ContractSituationId;

            foreach (var contract in this.context.Contract.Where(x => !x.IsDeleted && x.ContractStatusId == signedStatusId))
            {
                var daysRemaining = this.context.Contract.Single(x => x.ContractId == contract.ContractId).DueDate.Subtract(DateTime.Today).TotalDays;

                var daysInMonth = DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.Month);

                if (daysRemaining <= 30 && daysRemaining > 0 && daysInMonth == 30 || daysRemaining <= 31 && daysRemaining > 0 && daysInMonth == 31 || daysRemaining <= 28 && daysRemaining > 0 && daysInMonth == 28)
                    contract.ContractSituationId = expireSituation;

                this.context.Contract.Update(contract);
            }

            this.context.SaveChanges();
        }

    }
}