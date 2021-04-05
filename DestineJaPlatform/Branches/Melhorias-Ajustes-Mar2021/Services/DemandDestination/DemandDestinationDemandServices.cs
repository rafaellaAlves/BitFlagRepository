using ApplicationDbContext.Models;
using DTO.Demand;
using DTO.DemandDestination;
using DTO.Utils;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.DemandDestination
{
    public class DemandDestinationDemandServices : Shared.BaseServices<DemandDestinationDemand, DemandDestinationDemand, int>
    {
        public DemandDestinationDemandServices(ApplicationDbContext.Context.ApplicationDbContext context, AspNetIdentityDbContext.ApplicationDbContext identityContext) : base(context, identityContext, "DemandDestinationDemandId")
        {
        }
        public async Task DeleteByDemandDestinationIdAsync(int demandDestinationId)
        {
            var entities = await GetDataAsync(x => x.DemandDestinationId == demandDestinationId);
            this.dbSet.RemoveRange(entities);
            await this.context.SaveChangesAsync();
        }

        public async Task CreateRange(List<DemandDestinationDemand> entities)
        {
            await this.dbSet.AddRangeAsync(entities);
            await this.context.SaveChangesAsync();
        }

        public async Task<IEnumerable<DemandDestionationDemandSelectViewModel>> GetUsedDemands(int? demandDestinationId = null)
        {
            var data = await GetDataAsNoTrackingAsync();
            var demandDestination = await this.context.DemandDestination.Where(x => x.DemandDestinationId != demandDestinationId && !x.IsDeleted).AsNoTracking().ToListAsync();

            return await Task.Run(() =>
                from ddd in data
                join dd in demandDestination on ddd.DemandDestinationId equals dd.DemandDestinationId
                select new DemandDestionationDemandSelectViewModel(ddd.DemandId, dd.ResidueFamilyId));
        }

        public List<DemandDestionationDemandSelectViewModel> GetUsedDemandsNotAsync(int? demandDestinationId = null)
        {
            var data = GetDataAsNoTracking();
            var demandDestination = this.context.DemandDestination.Where(x => x.DemandDestinationId != demandDestinationId && !x.IsDeleted).AsNoTracking();

            return (
                from ddd in data
                join dd in demandDestination on ddd.DemandDestinationId equals dd.DemandDestinationId
                select new DemandDestionationDemandSelectViewModel(ddd.DemandId, dd.ResidueFamilyId)).ToList();
        }

        public async Task<List<DemandListViewModel>> GetDemandsByDemandDestination(int demandDestinationId)
        {
            var demandIds = (await GetDataAsNoTrackingAsync(x => x.DemandDestinationId == demandDestinationId)).Select(x => x.DemandId);

            return await this.context.DemandList.Where(x => demandIds.Contains(x.DemandId)).AsNoTracking().Select(x => x.CopyToEntity<DemandListViewModel>()).ToListAsync();
        }
    }
}
