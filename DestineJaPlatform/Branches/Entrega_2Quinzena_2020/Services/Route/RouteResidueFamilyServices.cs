using ApplicationDbContext.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Services.Route
{
    public class RouteResidueFamilyServices : Shared.BaseServices<RouteResidueFamily, RouteResidueFamily, int>
    {
        public RouteResidueFamilyServices(ApplicationDbContext.Context.ApplicationDbContext context, AspNetIdentityDbContext.ApplicationDbContext identityContext) : base(context, identityContext, "RouteResidueFamilyId")
        {
        }
        public async Task DeleteByRouteIdAsync(int routeId)
        {
            var entities = await GetDataAsync(x => x.RouteId == routeId);
            this.dbSet.RemoveRange(entities);
            await this.context.SaveChangesAsync();
        }

        public async Task CreateRange(IEnumerable<RouteResidueFamily> entities)
        {
            await this.dbSet.AddRangeAsync(entities.Distinct());
            await this.context.SaveChangesAsync();
        }
    }
}
