using ApplicationDbContext.Models;
using DTO.Contract;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Services.Contract
{
    public class ContractPaymentServices : Shared.BaseServices<ContractPayment, ContractPaymentViewModel, int>
    {
        private readonly ContractServices contractServices;
        public ContractPaymentServices(ApplicationDbContext.Context.ApplicationDbContext context, AspNetIdentityDbContext.ApplicationDbContext identityContext, ContractServices contractServices) : base(context, identityContext, "ContractPaymentId")
        {
            this.contractServices = contractServices;
        }

        public async Task GeneratePayment(int contractId)
        {
            var contract = await contractServices.GetDataByIdAsync(contractId);

            List<ContractPayment> contractPayments = new List<ContractPayment>();

            for (var dueDate = new DateTime(contract.StartContract.Year, contract.StartContract.Month, contract.DueDay); dueDate <= contract.DueDate; dueDate.AddMonths(1))
            {
                contractPayments.Add(new ContractPayment
                {
                    ContractId = contractId,
                    DueDate = dueDate
                });
            }
        }
    }
}
