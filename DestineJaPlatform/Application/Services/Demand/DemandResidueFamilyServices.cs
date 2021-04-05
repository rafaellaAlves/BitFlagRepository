using ApplicationDbContext.Models;
using DTO.Demand;
using DTO.Residue;
using DTO.Utils;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Services.Demand
{
    public class DemandResidueFamilyServices : Shared.BaseServices<DemandResidueFamily, DemandResidueFamilyViewModel, int>
    {
        public DemandResidueFamilyServices(ApplicationDbContext.Context.ApplicationDbContext context, AspNetIdentityDbContext.ApplicationDbContext identityContext) : base(context, identityContext, "DemandResidueFamilyId")
        {
        }

        public async Task DeleteByDemandIdAsync(int demandId)
        {
            var entities = await GetDataAsync(x => x.DemandId == demandId);
            this.dbSet.RemoveRange(entities);
            await this.context.SaveChangesAsync();
        }

        public async Task CreateRange(List<DemandResidueFamily> entities)
        {
            await this.dbSet.AddRangeAsync(entities);
            await this.context.SaveChangesAsync();
        }
        public async Task ContractNewFamilies(int contractId, List<int> residueFamilyIds)
        {
            var demandClients = this.context.DemandClient.Where(x => x.ContractId == contractId).AsNoTracking();

            foreach (var demandClient in demandClients)
            {
                var familiesToAdd = new List<int>();

                var routeResidueFamilies = this.context.DemandResidueFamily.Where(x => x.DemandId == demandClient.DemandId && x.ClientCollectionAddressId == demandClient.ClientCollectionAddressId).Select(x => x.ResidueFamilyId);
                foreach (var item in residueFamilyIds)
                {
                    if (routeResidueFamilies.Contains(item)) continue;

                    familiesToAdd.Add(item);
                }

                await this.context.DemandResidueFamily.AddRangeAsync(familiesToAdd.Select(x => new DemandResidueFamily
                {
                    ClientCollectionAddressId = demandClient.ClientCollectionAddressId,
                    ResidueFamilyId = x,
                    DemandId = demandClient.DemandId
                }));
            }
        }

        public override async Task<List<DemandResidueFamilyViewModel>> GetViewModelAsNoTrackingAsync(Expression<Func<DemandResidueFamily, bool>> expr)
        {
            var r = await base.GetViewModelAsNoTrackingAsync(expr);

            r.ForEach(x => x.ResidueFamily = this.context.ResidueFamily.Single(c => c.ResidueFamilyId == x.ResidueFamilyId).CopyToEntity<ResidueFamilyViewModel>());

            return r;
        }
    }
}
