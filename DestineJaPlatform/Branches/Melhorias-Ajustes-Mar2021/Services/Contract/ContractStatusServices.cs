using ApplicationDbContext.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Services.Contract
{
    public class ContractStatusServices : Shared.BaseListServices<ContractStatus, ContractStatus, int>
    {
        public ContractStatusServices(ApplicationDbContext.Context.ApplicationDbContext context, AspNetIdentityDbContext.ApplicationDbContext identityContext) : base(context, identityContext, "ContractStatusId")
        {
        }

        public async Task<ContractStatus> GetDataByExternalCode(string externalCode) => await this.dbSet.SingleOrDefaultAsync(x => x.ExternalCode == externalCode);
    }
}
