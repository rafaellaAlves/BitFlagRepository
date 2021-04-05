using ApplicationDbContext.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Services.Contract
{
    public class ContractSituationServices : Shared.BaseListServices<ContractSituation, ContractSituation, int>
    {
        public ContractSituationServices(ApplicationDbContext.Context.ApplicationDbContext context, AspNetIdentityDbContext.ApplicationDbContext identityContext) : base(context, identityContext, "ContractSituationId")
        {
        }

        public async Task<ContractSituation> GetDataByExternalCodeAsync(string externalCode) => await this.dbSet.FirstOrDefaultAsync(x => x.ExternalCode == externalCode);
    }
}
