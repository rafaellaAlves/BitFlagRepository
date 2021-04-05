using ApplicationDbContext.Models;
using Services.Demand;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Route
{
    public class RouteClientServices : Shared.BaseServices<RouteClient, RouteClient, int>
    {
        private readonly RouteResidueFamilyServices routeResidueFamilyServices;

        public RouteClientServices(ApplicationDbContext.Context.ApplicationDbContext context, AspNetIdentityDbContext.ApplicationDbContext identityContext, RouteResidueFamilyServices routeResidueFamilyServices) : base(context, identityContext, "RouteClientId")
        {
            this.routeResidueFamilyServices = routeResidueFamilyServices;
        }

        public async Task DeleteByRouteIdAsync(int routeId)
        {
            var entities = await GetDataAsync(x => x.RouteId == routeId);
            this.dbSet.RemoveRange(entities);
            await this.context.SaveChangesAsync();
        }

        public async Task CreateRange(List<RouteClient> entities)
        {
            await this.dbSet.AddRangeAsync(entities);
            await this.context.SaveChangesAsync();
        }

        public async Task ContractNewFamilies(int contractId, List<int> residueFamilyIds)
        {
            foreach (var entity in await GetDataAsNoTrackingAsync(x => x.ContractId == contractId))
            {
                var familiesToAdd = new List<int>();

                var routeResidueFamilies = (await routeResidueFamilyServices.GetDataAsNoTrackingAsync(x => x.ClientCollectionAddressId == entity.ClientCollectionAddressId && x.RouteId == entity.RouteId)).Select(x => x.ResidueFamilyId);
                foreach (var item in residueFamilyIds)
                {
                    if (routeResidueFamilies.Contains(item)) continue;

                    familiesToAdd.Add(item);
                }

                await routeResidueFamilyServices.CreateRange(familiesToAdd.Select(x => new RouteResidueFamily
                {
                    ClientCollectionAddressId = entity.ClientCollectionAddressId,
                    ResidueFamilyId = x,
                    RouteId = entity.RouteId
                }));
            }
        }
    }
}
