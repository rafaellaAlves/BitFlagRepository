using ApplicationDbContext.Models;
using DTO.Contract;
using DTO.Demand;
using DTO.Utils;
using Microsoft.EntityFrameworkCore;
using Services.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Demand
{
    public class DemandClientResidueServices : Shared.BaseServices<DemandClientResidue, DemandClientResidueViewModel, int>
    {
        private readonly ContractResidueServices contractResidueServices;
        public DemandClientResidueServices(ApplicationDbContext.Context.ApplicationDbContext context, AspNetIdentityDbContext.ApplicationDbContext identityContext, ContractResidueServices contractResidueServices) : base(context, identityContext, "DemandClientResidueId")
        {
            this.contractResidueServices = contractResidueServices;
        }
        public async Task DeleteByDemandClientIdAsync(int demandClientId)
        {
            var entities = await GetDataAsync(x => x.DemandClientId == demandClientId);
            this.dbSet.RemoveRange(entities);
            await this.context.SaveChangesAsync();
        }

        public async Task CreateRange(List<DemandClientResidue> entities)
        {
            await this.dbSet.AddRangeAsync(entities);
            await this.context.SaveChangesAsync();
        }
        public async Task CreateRange(List<DemandClientResidueViewModel> models)
        {
            await this.dbSet.AddRangeAsync(models.Select(x => x.CopyToEntity<DemandClientResidue>()));
            await this.context.SaveChangesAsync();
        }
        public async Task<bool> Validate(int demandClientId, List<int?> demandResidues)
        {
            var demandClient = await this.context.DemandClient.SingleAsync(x => x.DemandClientId == demandClientId);

            if (!demandClient.ContractId.HasValue) return true;

            var contractResidues = (await contractResidueServices.GetDataAsNoTrackingAsync(x => x.ContractId == demandClient.ContractId)).Select(x => x.ResidueId);

            foreach (var demandResidue in demandResidues)
                if (demandResidue.HasValue && !contractResidues.Contains(demandResidue.Value))
                    return false;

            return true;
        }

        public async Task<List<ContractResidueViewModel>> GetResiduesOutOfContract(int demandClientId, List<int?> demandResidueIds)
        {
            var result = new List<ContractResidueViewModel>();
            var demandClient = await this.context.DemandClient.SingleAsync(x => x.DemandClientId == demandClientId);

            if (!demandClient.ContractId.HasValue) return result;

            var contractResidues = contractResidueServices.ToViewModel(await contractResidueServices.GetDataAsNoTrackingAsync(x => x.ContractId == demandClient.ContractId));

            var contractResidueIds = contractResidues.Select(x => x.ResidueId);

            foreach (var demandResidueId in demandResidueIds)
                if (demandResidueId.HasValue && !contractResidueIds.Contains(demandResidueId.Value))
                {
                    var demandResidue = await this.context.Residue.SingleAsync(x => x.ResidueId == demandResidueId);
                    var contractResidue = contractResidues.First(x => x.ResidueFamilyId == demandResidue.ResidueFamilyId);

                    result.Add(new ContractResidueViewModel
                    {
                        Charge = true,
                        ContractId = contractResidue.ContractId,
                        ResidueId = demandResidueId.Value,
                        DeductFromFranchise = true,
                        MaximumPrice = contractResidue.MaximumPrice,
                        MediumPrice = contractResidue.MediumPrice,
                        MinimumPrice = contractResidue.MinimumPrice,
                        Price = contractResidue.Price,
                        UnitOfMeasurementId = contractResidue.UnitOfMeasurementId
                    });
                }

            return result;
        }
    }
}
