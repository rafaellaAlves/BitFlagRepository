using ApplicationDbContext.Models;
using DTO.Demand;
using DTO.Utils;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Services.Client;
using Services.Contract;
using Services.Route;
using Services.Service;
using Services.Transporter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Demand
{
    public class DemandServices : Shared.BaseServices<ApplicationDbContext.Models.Demand, DemandViewModel, int>
    {
        private readonly DemandClientResidueListServices demandClientResidueListServices;
        private readonly DemandStatusServices demandStatusServices;
        private readonly ClientServices clientServices;
        private readonly RouteTypeServices routeTypeServices;
        private readonly RouteServices routeServices;
        private readonly ServiceStatusServices serviceStatusServices;

        public DemandServices(ApplicationDbContext.Context.ApplicationDbContext context, AspNetIdentityDbContext.ApplicationDbContext identityContext, DemandClientResidueListServices demandClientResidueListServices, ClientServices clientServices, DemandStatusServices demandStatusServices, RouteTypeServices routeTypeServices, RouteServices routeServices, ServiceStatusServices serviceStatusServices) : base(context, identityContext, "DemandId")
        {
            this.demandClientResidueListServices = demandClientResidueListServices;
            this.clientServices = clientServices;
            this.demandStatusServices = demandStatusServices;
            this.routeTypeServices = routeTypeServices;
            this.routeServices = routeServices;
            this.serviceStatusServices = serviceStatusServices;
        }
        public async Task<int> GetLastId()
        {
            try
            {
                return await Task.Run(async () => await this.dbSet.MaxAsync(x => x.DemandId));
            }
            catch
            {
                return await Task.Run(() => 1);
            }
        }

        public async Task<DemandClientCertificateViewModel> GetDemandClientCertificateViewModel(int demandClientId)
        {
            var demandClient = (await this.context.DemandClient.SingleOrDefaultAsync(x => x.DemandClientId == demandClientId)).CopyToEntity<DemandClientViewModel>();
            var ClientAddress = await this.context.ClientCollectionAddress.SingleOrDefaultAsync(x => x.ClientCollectionAddressId == demandClient.ClientCollectionAddressId);
            var viewModel = new DemandClientCertificateViewModel();

            viewModel.DemandClientResidue = await demandClientResidueListServices.GetViewModelAsNoTrackingAsync(x => x.DemandClientId == demandClientId);
            viewModel.DemandClient = demandClient;
            viewModel.Client = await clientServices.GetViewModelByIdAsync(ClientAddress.ClientId);
            viewModel.Demand = await GetViewModelByIdAsync(demandClient.DemandId);

            return viewModel;
        }

        public async Task CloseUpdate(DemandViewModel model)
        {
            var entity = await this.GetDataByIdAsync(model.DemandId.Value);
            entity.ArriveDate = model.ArriveDate;
            entity.DepartureDate = model.DepartureDate;

            this.dbSet.Update(entity);
            await this.context.SaveChangesAsync();
        }
        public async Task Close(int demandId, int userId)
        {
            var entity = await this.GetDataByIdAsync(demandId);
            entity.Closed = true;
            entity.ClosedDate = DateTime.Now;
            entity.ClosedBy = userId;
            entity.DemandStatusId = (await demandStatusServices.GetDataByExternalCode("COLETAFINALIZADA"))?.DemandStatusId ?? entity.DemandStatusId;

            this.dbSet.Update(entity);
            await this.context.SaveChangesAsync();
        }
        public async Task<bool> CanClose(int demandId)
        {
            return await Task.Run(async () => !(await this.context.DemandClient.AnyAsync(x => x.DemandId == demandId && !x.Visited.HasValue)));
        }
        public async Task<DemandInfoViewModel> GetDemandInfoViewModel(int demandId, int? residueFamilyId = null)
        {
            var demandClient = this.context.DemandClientList.Where(x => x.DemandId == demandId).ToList();

            var items = demandClient.Select(x => new DemandInfoItemViewModel(x.CopyToEntity<DemandClientListViewModel>(), this.context.DemandClientResidueList.Where(c => c.DemandClientId == x.DemandClientId).Select(v => v.CopyToEntity<DemandClientResidueListViewModel>()).ToList())).ToList();

            return await Task.Run(() => new DemandInfoViewModel(items, residueFamilyId));
        }
        public async Task Cancel(int id, string reason)
        {
            var entity = await GetDataByIdAsync(id);

            entity.Cancel = true;
            entity.CancelReason = reason;

            this.dbSet.Update(entity);
            await this.context.SaveChangesAsync();
        }
        public async Task Unlock(int id, int userId, string reason)
        {
            var entity = await GetDataByIdAsync(id);

            entity.Closed = false;
            entity.ClosedBy = null;
            entity.ClosedDate = null;

            entity.OpenReason = reason;
            entity.OpenBy = userId;
            entity.OpenDate = DateTime.Now;

            entity.DemandStatusId = (await demandStatusServices.GetDataByExternalCode("COLETAANDAMENTO")).DemandStatusId;

            this.dbSet.Update(entity);
            await this.context.SaveChangesAsync();
        }

        public async Task Conclude(IEnumerable<int> ids)
        {
            foreach (var id in ids)
            {
                var entity = await GetDataByIdAsync(id);


                entity.DemandStatusId = (await demandStatusServices.GetDataByExternalCode("PROCESSOCONCLUIDO"))?.DemandStatusId ?? entity.DemandStatusId;
                this.dbSet.Update(entity);
            }

            await this.context.SaveChangesAsync();
        }
        public async Task<IEnumerable<ResidueFamilyList>> GetAvailbleResidueFamilies(int routeId, int? contractId, int? serviceId, bool notValidateFamily = false)
        {
            var route = await this.context.Route.SingleAsync(x => x.RouteId == routeId);
            var RouteUsedForContract = route.RouteTypeId == (await routeTypeServices.GetDataByExternalCode("CONTRATO"))?.RouteTypeId;
            var RouteUsedForService = route.RouteTypeId == (await routeTypeServices.GetDataByExternalCode("SERVICO"))?.RouteTypeId;

            IEnumerable<ResidueFamilyList> families = new List<ResidueFamilyList>();
            if (RouteUsedForContract) // se for contrato verifica a quantidade de familias disponiveis para cada cliente (Obs. na linha que contêm o retorno)
            {
                if (contractId.HasValue)
                {
                    var availbleFamilyIds = (await routeServices.GetResidueFamiliesByRouteId(routeId)).Select(x => x.ResidueFamilyId);

                    families = (from crs in this.context.ContractResidue.Where(x => x.ContractId == contractId).AsNoTracking()
                                join r in this.context.Residue.AsNoTracking() on crs.ResidueId equals r.ResidueId
                                join rf in this.context.ResidueFamilyList.AsNoTracking() on r.ResidueFamilyId equals rf.ResidueFamilyId
                                where availbleFamilyIds.Contains(rf.ResidueFamilyId) || notValidateFamily
                                select rf).Distinct();
                }
            }
            if (RouteUsedForService)
            {
                if (serviceId.HasValue)
                {
                    families = (from srf in this.context.ServiceResidueFamilyPrice.Where(x => serviceId == x.ServiceId).AsNoTracking()
                                join rf in this.context.ResidueFamilyList.AsNoTracking() on srf.ResidueFamilyId equals rf.ResidueFamilyId
                                select rf).Distinct();
                }
            }

            return await Task.Run(() => families);
        }
        public async Task UpdateServiceStatusToDemandClosed(int demandId)
        {
            var services = from y in this.context.DemandClient.Where(x => x.DemandId == demandId && x.ServiceId.HasValue)
                           join s in this.context.Service on y.ServiceId equals s.ServiceId
                           select s;

            foreach (var item in services)
            {
                item.ServiceStatusId = (await serviceStatusServices.GetDataByExternalCode("COLETACONCLUIDA"))?.ServiceStatusId ?? item.ServiceStatusId;
            }

            this.context.Service.UpdateRange(services);
            await this.context.SaveChangesAsync();
        }
        public async Task UpdateServiceStatusToDemandSchedule(int demandId)
        {
            var services = from y in this.context.DemandClient.Where(x => x.DemandId == demandId && x.ServiceId.HasValue)
                           join s in this.context.Service on y.ServiceId equals s.ServiceId
                           select s;

            foreach (var item in services)
            {
                item.ServiceStatusId = (await serviceStatusServices.GetDataByExternalCode("COLETAAGENDADA"))?.ServiceStatusId ?? item.ServiceStatusId;
            }

            this.context.Service.UpdateRange(services);
            await this.context.SaveChangesAsync();
        }
        public async Task UpdateServiceStatusToOSAssinada(int demandId)
        {
            var services = from y in this.context.DemandClient.Where(x => x.DemandId == demandId && x.ServiceId.HasValue)
                           join s in this.context.Service on y.ServiceId equals s.ServiceId
                           select s;

            foreach (var item in services)
            {
                item.ServiceStatusId = (await serviceStatusServices.GetDataByExternalCode("OSASSINADA"))?.ServiceStatusId ?? item.ServiceStatusId;
            }

            this.context.Service.UpdateRange(services);

            await this.context.SaveChangesAsync();
        }

        public async Task<bool> ExistAlternativeDemandId(int? demandId, string alternativeDemandId) => string.IsNullOrWhiteSpace(alternativeDemandId) ? false : await this.dbSet.AnyAsync(x => x.AlternativeDemandId == alternativeDemandId && (!demandId.HasValue || demandId != x.DemandId));

        public async Task<double?> GetWeightCollectedFromClient(int contractId, int clientCollectionAddressId)
        {
            using var command = context.Database.GetDbConnection().CreateCommand();

            command.CommandText = "SELECT [dbo].[GetWeightCollectedFromClient](@ContractId, @ClientCollectionAddressId) as 'CollectedWeight'";
            command.Parameters.Add(new SqlParameter("@ContractId", contractId));
            command.Parameters.Add(new SqlParameter("@ClientCollectionAddressId", clientCollectionAddressId));

            await context.Database.OpenConnectionAsync();

            using var result = await command.ExecuteReaderAsync();
            while (result.Read())
                return await Task.Run(() => result["CollectedWeight"].GetDoubleFromDbDataReader());

            return await Task.Run(() => (double?)null);
        }

        public async Task<int> GetDemandsThisMonth() => await this.dbSet.CountAsync(x => x.CreatedDate.Month == DateTime.Now.Month && x.CreatedDate.Year == DateTime.Now.Year && !x.IsDeleted);
    }
}
