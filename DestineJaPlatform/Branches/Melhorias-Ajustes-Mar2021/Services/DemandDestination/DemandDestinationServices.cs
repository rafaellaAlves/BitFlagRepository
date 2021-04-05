using DTO.Demand;
using DTO.DemandDestination;
using DTO.Recipient;
using DTO.Residue;
using DTO.Transporter;
using DTO.Utils;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Services.Contract;
using Services.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.DemandDestination
{
    public class DemandDestinationServices : Shared.BaseServices<ApplicationDbContext.Models.DemandDestination, DemandDestinationViewModel, int>
    {
        private readonly DemandDestinationStatusServices demandDestinationStatusServices;
        private readonly ServiceStatusServices serviceStatusServices;
        private readonly ContractStatusServices contractStatusServices;

        public DemandDestinationServices(ApplicationDbContext.Context.ApplicationDbContext context, AspNetIdentityDbContext.ApplicationDbContext identityContext, DemandDestinationStatusServices demandDestinationStatusServices, ServiceStatusServices serviceStatusServices, ContractStatusServices contractStatusServices) : base(context, identityContext, "DemandDestinationId")
        {
            this.demandDestinationStatusServices = demandDestinationStatusServices;
            this.serviceStatusServices = serviceStatusServices;
            this.contractStatusServices = contractStatusServices;
        }

        public async Task<int> GetLastId()
        {
            try
            {
                return await Task.Run(async () => await this.dbSet.MaxAsync(x => x.DemandDestinationId));
            }
            catch
            {
                return await Task.Run(() => 1);
            }
        }

        public async Task FinishUpdate(DemandDestinationViewModel model)
        {
            var entity = await GetDataByIdAsync(model.DemandDestinationId.Value);

            entity.WeighingTicket = model.WeighingTicket;
            entity.Weight = model.Weight;
            entity.ArrivedTime = model.ArrivedTime;
            entity.DepartureTime = model.DepartureTime;
            entity.CDF = model.CDF;
            entity.ArrivedDate = model.ArrivedDate.Value;
            entity.DepartureDate = model.DepartureDate.Value;

            this.Update(entity);
            await this.context.SaveChangesAsync();
        }

        public async Task Finish(int demandDestinationId, int userId)
        {
            var entity = await GetDataByIdAsync(demandDestinationId);

            entity.Finished = true;
            entity.FinishedDate = DateTime.Now;
            entity.FinishedBy = userId;

            if (entity.DemandDestinationStatusId != (await demandDestinationStatusServices.GetDataByExternalCode("CONCLUIDO"))?.DemandDestinationStatusId) // caso já esteja concluido
            {
                entity.DemandDestinationStatusId = (await demandDestinationStatusServices.GetDataByExternalCode("FINALIZADO"))?.DemandDestinationStatusId ?? entity.DemandDestinationStatusId;
            }
            this.Update(entity);
            await this.context.SaveChangesAsync();
        }
        public async Task UpdateCDF(DemandDestinationViewModel model)
        {
            var entity = await GetDataByIdAsync(model.DemandDestinationId.Value);

            entity.CDF = model.CDF;

            this.Update(entity);
            await this.context.SaveChangesAsync();
        }

        public bool TryGetMTRFile(int demandDestinationId, out ApplicationDbContext.Models.DemandDestination demandDestination)
        {
            demandDestination = this.dbSet.FirstOrDefault(x => x.DemandDestinationId == demandDestinationId && !string.IsNullOrWhiteSpace(x.MTRFileGuidName));

            return demandDestination != null;
        }
        public bool TryGetCDFFile(int demandDestinationId, out ApplicationDbContext.Models.DemandDestination demandDestination)
        {
            demandDestination = this.dbSet.FirstOrDefault(x => x.DemandDestinationId == demandDestinationId && !string.IsNullOrWhiteSpace(x.CDFFileGuidName));

            return demandDestination != null;
        }
        public async Task UpdateMTRFile(int demandDestinationId, string fileGuidName, string fileName, string fileMimeType)
        {
            var entity = await this.GetDataByIdAsync(demandDestinationId);

            entity.MTRFileGuidName = fileGuidName;
            entity.MTRFileName = fileName;
            entity.MTRFileMimeType = fileMimeType;

            this.dbSet.Update(entity);
            await this.context.SaveChangesAsync();
        }
        public async Task UpdateCDFFile(int demandDestinationId, string fileGuidName, string fileName, string fileMimeType)
        {
            var entity = await this.GetDataByIdAsync(demandDestinationId);

            entity.CDFFileGuidName = fileGuidName;
            entity.CDFFileName = fileName;
            entity.CDFFileMimeType = fileMimeType;
            entity.DemandDestinationStatusId = (await this.context.DemandDestinationStatus.SingleAsync(x => x.ExternalCode == "CONCLUIDO")).DemandDestinationStatusId;

            this.dbSet.Update(entity);
            await this.context.SaveChangesAsync();
        }

        public async Task<DemandDestinationMTRFileViewModel> GetDemandDestinationMTRFileViewModel(int demandDestinationId, int via)
        {
            var entity = await GetDataByIdAsync(demandDestinationId);
            var demandsIds = this.context.DemandDestinationDemand.Where(x => x.DemandDestinationId == demandDestinationId).AsNoTracking().Select(x => x.DemandId);
            var demandClient = this.context.DemandClient.Where(x => demandsIds.Contains(x.DemandId)).AsNoTracking();

            var demandClientResidueList = demandClient.Select(x => this.context.DemandClientResidueList.Where(c => c.DemandClientId == x.DemandClientId && c.ResidueFamilyId == entity.ResidueFamilyId).AsNoTracking()).SelectMany(x => x);//obtem os residuos junto com os dados do cliente que esta vinculado;
            var residues = demandClientResidueList.GroupBy(x => x.ResidueId).Select(x => new { ResidueId = x.Key, Weight = x.Sum(c => c.Weight) });//agrupa os residuos já q o mesmo residuo pode existir em cliente diferentes e soma o total do peso do residuo

            var demandDestinationMTRFileResidueViewModel = new List<DemandDestinationMTRFileResidueViewModel>();

            foreach (var item in residues)
            {
                var residue = (await this.context.ResidueList.SingleAsync(x => x.ResidueId == item.ResidueId)).CopyToEntity<ResidueListViewModel>();
                demandDestinationMTRFileResidueViewModel.Add(new DemandDestinationMTRFileResidueViewModel(residue, item.Weight)); //(await this.context.ResidueFamily.SingleAsync(x => x.ResidueFamilyId == residue.ResidueFamilyId)).CopyToEntity<ResidueFamilyViewModel>(), 
            }

            var viewModel = new DemandDestinationMTRFileViewModel
            {
                Via = via,
                DemandDestination = ToViewModel(entity),
                Recipient = (await this.context.Recipient.SingleAsync(x => x.RecipientId == entity.RecipientId)).CopyToEntity<RecipientViewModel>(),
                Transporter = (await this.context.Transporter.SingleAsync(x => x.TransporterId == entity.TransporterId)).CopyToEntity<TransporterViewModel>(),
                Residues = demandDestinationMTRFileResidueViewModel
            };

            return viewModel;
        }

        public async Task<bool> ExistAlternativeDemandDestinationId(int? demandDestinationId, string alternativeDemandDestinationId) => string.IsNullOrWhiteSpace(alternativeDemandDestinationId) ? false : await this.dbSet.AnyAsync(x => x.AlternativeDemandDestinationId == alternativeDemandDestinationId && (!demandDestinationId.HasValue || demandDestinationId != x.DemandDestinationId));

        public async Task<DemandDestinationViewModel> GetDestinationByDemandIdAndResidueFamilyId(int demandId, int residueFamilyId)
        {
            var demandDestinationDemands = await this.context.DemandDestinationDemand.Where(x => x.DemandId == demandId).AsNoTracking().ToListAsync();
            var demandDestionations = await dbSet.Where(x => x.ResidueFamilyId == residueFamilyId).AsNoTracking().ToListAsync();

            var entity = (from ddd in demandDestinationDemands
                          join dd in demandDestionations on ddd.DemandDestinationId equals dd.DemandDestinationId
                          select dd).FirstOrDefault();

            if (entity == null) return null;

            return ToViewModel(entity);
        }

        public async Task<List<DemandListViewModel>> GetDemandForDemandDestination(int residueFamilyId, DateTime? departureDate)
        {
            using var command = context.Database.GetDbConnection().CreateCommand();

            command.CommandText = "pr_GetDemandForDemandDestination @ResidueFamilyId = @_ResidueFamilyId, @DepartureDate = @_DepartureDate";
            command.Parameters.Add(new SqlParameter("@_ResidueFamilyId", residueFamilyId));
            command.Parameters.Add(new SqlParameter("@_DepartureDate", departureDate ?? (object)DBNull.Value));

            await context.Database.OpenConnectionAsync();

            var viewModels = new List<DemandListViewModel>();
            using var result = await command.ExecuteReaderAsync();
            while (result.Read())
            {
                viewModels.Add(new DemandListViewModel
                {
                    AlternativeDemandId = result["AlternativeDemandId"].GetStringFromDbDataReader(),
                    ArriveDate = result["ArriveDate"].GetDateTimeFromDbDataReader().Value,
                    Cancel = result["Cancel"].GetBoolFromDbDataReader().Value,
                    Closed = result["Closed"].GetBoolFromDbDataReader().Value,
                    CreatedDate = result["CreatedDate"].GetDateTimeFromDbDataReader().Value,
                    DemandClientCompanyNames = result["DemandClientCompanyNames"].GetStringFromDbDataReader(),
                    DemandClientTradeNames = result["DemandClientTradeNames"].GetStringFromDbDataReader(),
                    DemandStatusId = result["DemandStatusId"].GetIntFromDbDataReader().Value,
                    DemandId = result["DemandId"].GetIntFromDbDataReader().Value,
                    DemandStatusName = result["DemandStatusName"].GetStringFromDbDataReader(),
                    DepartureDate = result["DepartureDate"].GetDateTimeFromDbDataReader().Value,
                    TotalWeight = result["TotalWeight"].GetDoubleFromDbDataReader().Value,
                    IsDeleted = result["IsDeleted"].GetBoolFromDbDataReader().Value,
                    RouteId = result["RouteId"].GetIntFromDbDataReader().Value,
                    RouteName = result["RouteName"].GetStringFromDbDataReader(),
                    TotalClient = result["TotalClient"].GetIntFromDbDataReader().Value
                });
            }

            return await Task.Run(() => viewModels);
        }

        public List<DemandListViewModel> GetDemandForDemandDestinationNotAsync(int residueFamilyId, DateTime? departureDate)
        {
            using var command = context.Database.GetDbConnection().CreateCommand();

            command.CommandText = "pr_GetDemandForDemandDestination @ResidueFamilyId = @_ResidueFamilyId, @DepartureDate = @_DepartureDate";
            command.Parameters.Add(new SqlParameter("@_ResidueFamilyId", residueFamilyId));
            command.Parameters.Add(new SqlParameter("@_DepartureDate", departureDate ?? (object)DBNull.Value));

            context.Database.OpenConnection();

            var viewModels = new List<DemandListViewModel>();
            using var result = command.ExecuteReader();
            while (result.Read())
            {
                viewModels.Add(new DemandListViewModel
                {
                    AlternativeDemandId = result["AlternativeDemandId"].GetStringFromDbDataReader(),
                    ArriveDate = result["ArriveDate"].GetDateTimeFromDbDataReader().Value,
                    Cancel = result["Cancel"].GetBoolFromDbDataReader().Value,
                    Closed = result["Closed"].GetBoolFromDbDataReader().Value,
                    CreatedDate = result["CreatedDate"].GetDateTimeFromDbDataReader().Value,
                    DemandClientCompanyNames = result["DemandClientCompanyNames"].GetStringFromDbDataReader(),
                    DemandClientTradeNames = result["DemandClientTradeNames"].GetStringFromDbDataReader(),
                    DemandStatusId = result["DemandStatusId"].GetIntFromDbDataReader().Value,
                    DemandId = result["DemandId"].GetIntFromDbDataReader().Value,
                    DemandStatusName = result["DemandStatusName"].GetStringFromDbDataReader(),
                    DepartureDate = result["DepartureDate"].GetDateTimeFromDbDataReader().Value,
                    TotalWeight = result["TotalWeight"].GetDoubleFromDbDataReader().Value,
                    IsDeleted = result["IsDeleted"].GetBoolFromDbDataReader().Value,
                    RouteId = result["RouteId"].GetIntFromDbDataReader().Value,
                    RouteName = result["RouteName"].GetStringFromDbDataReader(),
                    TotalClient = result["TotalClient"].GetIntFromDbDataReader().Value
                });
            }

            return viewModels;
        }

        public async Task Unlock(int id, int userId, string reason)
        {
            var entity = await GetDataByIdAsync(id);

            entity.Finished = false;
            entity.FinishedBy = null;
            entity.FinishedDate = null;

            entity.OpenReason = reason;
            entity.OpenBy = userId;
            entity.OpenDate = DateTime.Now;

            entity.DemandDestinationStatusId = (await demandDestinationStatusServices.GetDataByExternalCode("EMANDAMENTO")).DemandDestinationStatusId;

            this.dbSet.Update(entity);
            await this.context.SaveChangesAsync();
        }

        public async Task<NewDemandDestinationEmailViewModel> GetNewDemandDestinationEmailViewModel(int id)
        {
            var model = new NewDemandDestinationEmailViewModel();

            model.DemandDestination = await GetViewModelByIdAsync(id);
            model.Recipient = (await this.context.Recipient.SingleAsync(x => x.RecipientId == model.DemandDestination.RecipientId)).CopyToEntity<RecipientViewModel>();
            model.ResidueFamily = (await this.context.ResidueFamily.SingleAsync(x => x.ResidueFamilyId == model.DemandDestination.ResidueFamilyId)).CopyToEntity<ResidueFamilyViewModel>();

            return model;
        }

        public async Task<int> GetDemandDestinationsThisMonth() => await this.dbSet.CountAsync(x => x.CreatedDate.Month == DateTime.Now.Month && x.CreatedDate.Year == DateTime.Now.Year && !x.IsDeleted);
    }
}
