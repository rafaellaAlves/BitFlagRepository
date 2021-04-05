using ApplicationDbContext.Models;
using DTO.Demand;
using DTO.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Demand
{
    public class DemandNotUsedClientServices : Shared.BaseServices<DemandNotUsedClient, DemandNotUsedClientViewModel, int>
    {
        public DemandNotUsedClientServices(ApplicationDbContext.Context.ApplicationDbContext context, AspNetIdentityDbContext.ApplicationDbContext identityContext) : base(context, identityContext, "DemandNotUsedClientId")
        {
        }

        public async Task DeleteByDemandIdAsync(int demandId)
        {
            var entities = await GetDataAsync(x => x.DemandId == demandId);
            this.dbSet.RemoveRange(entities);
            await this.context.SaveChangesAsync();
        }

        public async Task CreateRange(List<DemandNotUsedClientViewModel> models)
        {
            await this.dbSet.AddRangeAsync(models.Select(x => x.CopyToEntity<DemandNotUsedClient>()));
            await this.context.SaveChangesAsync();
        }
    }
}