using ApplicationDbContext.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.DemandDestination
{
    public class DemandDestinationStatusServices : Shared.BaseServices<DemandDestinationStatus, DemandDestinationStatus, int>
    {
        public DemandDestinationStatusServices(ApplicationDbContext.Context.ApplicationDbContext context, AspNetIdentityDbContext.ApplicationDbContext identityContext) : base(context, identityContext, "DemandDestinationStatusId")
        {
        }

        public async Task<DemandDestinationStatus> GetDataByExternalCode(string externalCode) => await Task.Run(async () => await this.dbSet.SingleOrDefaultAsync(x => x.ExternalCode == externalCode));

        public async Task<DemandDestinationStatus> GetInitialStatus()
        {
            var entities = await GetDataAsNoTrackingAsync();
            var min = entities.Aggregate(entities[0], (min, next) => min.Order > next.Order? next : min);

            return (await GetDataByExternalCode("EMABERTO"))?? min;
        }
    }
}
