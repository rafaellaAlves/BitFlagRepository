using ApplicationDbContext.Models;
using DTO.Contract;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Linq;
using DTO.Utils;
using Services.Residue;
using System.Runtime.InteropServices;

namespace Services.Contract
{
    public class ContractResidueServices : Shared.BaseServices<ContractResidue, ContractResidueViewModel, int>
    {
        private readonly ResidueServices residueServices;
        private readonly ResidueFamilyServices residueFamilyServices;
        private readonly UnitOfMeasurementServices unitOfMeasurementServices;

        public ContractResidueServices(ApplicationDbContext.Context.ApplicationDbContext context, AspNetIdentityDbContext.ApplicationDbContext identityContext, ResidueServices residueServices, UnitOfMeasurementServices unitOfMeasurementServices, ResidueFamilyServices residueFamilyServices) : base(context, identityContext, "ContractResidueId")
        {
            this.residueServices = residueServices;
            this.unitOfMeasurementServices = unitOfMeasurementServices;
            this.residueFamilyServices = residueFamilyServices;
        }

        public async Task CreateRangeAsync(IEnumerable<ContractResidueViewModel> models)
        {
            await this.dbSet.AddRangeAsync(models.Select(x => x.CopyToEntity<ContractResidue>()));
            await this.context.SaveChangesAsync();
        }

        public async Task<List<ContractResidue>> GetDataByContractId(int contractId)
        {
            return await GetDataAsNoTrackingAsync(x => x.ContractId == contractId);
        }

        public override List<ContractResidueViewModel> ToViewModel(IEnumerable<ContractResidue> datas)
        {
            var residues = residueServices.GetDataAsNoTrackingAsync(x => datas.Select(x => x.ResidueId).Contains(x.ResidueId)).Result;
            var unitOfMeasurement = unitOfMeasurementServices.GetDataAsNoTrackingAsync().Result;

            return (from x in datas
                    join r in residues on x.ResidueId equals r.ResidueId
                    join rf in this.context.ResidueFamily.AsNoTracking() on r.ResidueFamilyId equals rf.ResidueFamilyId
                    from u in unitOfMeasurement.Where(c => c.UnitOfMeasurementId == x.UnitOfMeasurementId).DefaultIfEmpty()
                    select new ContractResidueViewModel
                    {
                        Charge = x.Charge,
                        ContractId = x.ContractId,
                        ContractResidueId = x.ContractResidueId,
                        ResidueId = x.ResidueId,
                        CreatedDate = x.CreatedDate,
                        DeductFromFranchise = x.DeductFromFranchise,
                        DeletedBy = x.DeletedBy,
                        DeletedDate = x.DeletedDate,
                        IsDeleted = x.IsDeleted,
                        MaximumPrice = x.MaximumPrice,
                        MediumPrice = x.MediumPrice,
                        MinimumPrice = x.MinimumPrice,
                        Price = x.Price,
                        Residue = residueServices.ToViewModel(r),
                        ResidueFamily = residueFamilyServices.ToViewModel(rf),
                        UnitOfMeasurementId = x.UnitOfMeasurementId,
                        UnitOfMeasurementName = u?.Name
                    }).ToList();
        }

        public async Task DeleteDefinitilyByContractId(int contractId)
        {
            this.dbSet.RemoveRange(await GetDataAsNoTrackingAsync(x => x.ContractId == contractId));
            await this.context.SaveChangesAsync();
        }

        /// <summary>
        /// Compara os residuos já existentes no contrato com a lista de residuos passada por parametro e retorna os novos residuos inseridos.
        /// </summary>
        /// <returns></returns>
        public async Task<List<ContractResidueViewModel>> GetNewContracResidues(int contractId, List<ContractResidueViewModel> residues)
        {
            var newContractResidues = new List<ContractResidueViewModel>();
            if(residues == null) return await Task.Run(() => newContractResidues);

            var existingContractResidueIds = (await GetDataAsNoTrackingAsync(x => x.ContractId == contractId)).Select(x => x.ResidueId);

            foreach (var item in residues)
            {
                if (existingContractResidueIds.Contains(item.ResidueId)) continue;

                newContractResidues.Add(item);
            }

            return await Task.Run(() => newContractResidues);
        }


        /// <summary>
        /// Compara os residuos já existentes no contrato com a lista de residuos passada por parametro e retorna se há diferença entre os residuos inseridos e os já existentes.
        /// </summary>
        /// <returns></returns>
        public async Task<bool> AnyDifferenceBetweenContractResidues(int contractId, List<ContractResidueViewModel> residues)
        {
            var existingContractResidueIds = (await GetDataAsNoTrackingAsync(x => x.ContractId == contractId)).Select(x => x.ResidueId);
            var newContractResidueIds = (residues ?? new List<ContractResidueViewModel>()).Select(x => x.ResidueId);
            return await Task.Run(() => existingContractResidueIds.Except(newContractResidueIds).Count() > 0 || newContractResidueIds.Except(existingContractResidueIds).Count() > 0);
        }
    }
}
