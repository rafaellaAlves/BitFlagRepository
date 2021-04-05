using ApplicationDbContext.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Services.Residue
{
    public class ResidueDestinationTypeServices : Shared.BaseListServices<ResidueDestinationType, ResidueDestinationType, int>
    {
        public ResidueDestinationTypeServices(ApplicationDbContext.Context.ApplicationDbContext context, AspNetIdentityDbContext.ApplicationDbContext identityContext) : base(context, identityContext, "ResidueDestinationTypeId")
        {
        }

        public async Task<ResidueDestinationType> GetDataByExternalCode(string externalCode) => await Task.Run(async () => await this.dbSet.SingleOrDefaultAsync(x => x.ExternalCode == externalCode));
    }
}
