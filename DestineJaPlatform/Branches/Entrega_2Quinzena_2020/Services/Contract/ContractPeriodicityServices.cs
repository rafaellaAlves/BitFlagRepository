using ApplicationDbContext.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Services.Contract
{
    public class ContractPeriodicityServices : Shared.BaseListServices<ContractPeriodicity, ContractPeriodicity, int>
    {
        public ContractPeriodicityServices(ApplicationDbContext.Context.ApplicationDbContext context, AspNetIdentityDbContext.ApplicationDbContext identityContext) : base(context, identityContext, "ContractPeriodicityId")
        {
        }

        public async Task<ContractPeriodicity> GetDataByExternalCode(string externalCode) => await Task.Run(() => this.dbSet.SingleOrDefaultAsync(x => x.ExternalCode == externalCode));
    }
}
