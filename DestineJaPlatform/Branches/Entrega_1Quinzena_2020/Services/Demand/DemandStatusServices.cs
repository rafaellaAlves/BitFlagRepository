using ApplicationDbContext.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Demand
{
    public class DemandStatusServices : Shared.BaseListServices<DemandStatus, DemandStatus, int>
    {
        public DemandStatusServices(ApplicationDbContext.Context.ApplicationDbContext context, AspNetIdentityDbContext.ApplicationDbContext identityContext) : base(context, identityContext, "DemandStatusId")
        {
        }

        public async Task<DemandStatus> GetDataByExternalCode(string externalCode) => await Task.Run(() => this.dbSet.SingleOrDefaultAsync(x => x.ExternalCode == externalCode));

        public async Task<DemandStatus> GetInitialStatus()
        {
            var entities = await GetDataAsNoTrackingAsync();
            var min = entities.Aggregate(entities[0], (min, next) => min.Order > next.Order ? next : min);

            return (await GetDataByExternalCode("COLETAAGENDADA")) ?? min;
        }
    }
}
