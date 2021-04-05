using ApplicationDbContext.Models;
using DTO.Client;
using DTO.Demand;
using DTO.Residue;
using DTO.Service;
using DTO.Utils;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Services.Client;
using Services.Contract;
using Services.Residue;
using Services.Route;
using Services.Service;
using Services.Transporter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Services.Demand
{
    public class DemandClientServices : Shared.BaseServices<DemandClient, DemandClientViewModel, int>
    {
        private readonly DemandServices demandServices;
        private readonly TransporterServices transporterServices;
        private readonly TransporterDriverServices transporterDriverServices;
        private readonly TransporterVehicleServices transporterVehicleServices;
        private readonly DemandResidueFamilyServices demandResidueFamilyServices;
        private readonly ResidueListServices residueListServices;
        private readonly ClientCollectionAddressServices clientCollectionAddressServices;
        private readonly ClientServices clientServices;
        private readonly ClientContactServices clientContactServices;
        private readonly ContractResidueServices contractResidueServices;
        private readonly ServiceResidueFamilyPriceServices serviceResidueFamilyPriceServices;

        public DemandClientServices(ApplicationDbContext.Context.ApplicationDbContext context, AspNetIdentityDbContext.ApplicationDbContext identityContext, DemandServices demandServices, TransporterServices transporterServices, TransporterDriverServices transporterDriverServices, TransporterVehicleServices transporterVehicleServices, DemandClientResidueServices demandClientResidueServices, ResidueListServices residueListServices, ClientServices clientServices, ClientCollectionAddressServices clientCollectionAddressServices, ClientContactServices clientContactServices, DemandResidueFamilyServices demandResidueFamilyServices, ContractResidueServices contractResidueServices, ServiceResidueFamilyPriceServices serviceResidueFamilyPriceServices) : base(context, identityContext, "DemandClientId")
        {
            this.demandServices = demandServices;
            this.transporterServices = transporterServices;
            this.transporterDriverServices = transporterDriverServices;
            this.transporterVehicleServices = transporterVehicleServices;
            this.demandResidueFamilyServices = demandResidueFamilyServices;
            this.residueListServices = residueListServices;
            this.clientServices = clientServices;
            this.clientCollectionAddressServices = clientCollectionAddressServices;
            this.clientContactServices = clientContactServices;
            this.contractResidueServices = contractResidueServices;
            this.serviceResidueFamilyPriceServices = serviceResidueFamilyPriceServices;
        }

        /// <param name="demandClientId">Ids dos DemandClient q serão atualizados.</param>
        public async Task DeleteByDemandIdAsync(int demandId, IEnumerable<int> demandClientId)
        {
            var entities = await GetDataAsync(x => x.DemandId == demandId && !demandClientId.Contains(x.DemandClientId));
            this.dbSet.RemoveRange(entities);
            await this.context.SaveChangesAsync();
        }

        public async Task CreateRange(IEnumerable<DemandClientViewModel> models)
        {
            await this.dbSet.AddRangeAsync(models.Select(x => x.CopyToEntity<DemandClient>()));
            await this.context.SaveChangesAsync();
        }

        public async Task UpdateDemandClient(DemandClientViewModel model)
        {
            var entity = await GetDataByIdAsync(model.DemandClientId.Value);

            entity.Visited = model.Visited;
            entity.Collected = model.Collected;
            entity.ArrivedTime = model.ArrivedTime;
            entity.DepartureTime = model.DepartureTime;
            entity.ReceptorName = model.ReceptorName;
            entity.ReceptorCPF = model.ReceptorCPF;
            entity.NonCollectingReason = model.NonCollectingReason;
            entity.VisitedDate = model.VisitedDate;

            if (model.Collected.Value && !entity.CertificateId.HasValue) entity.CertificateId = await GetNewCertificateId();

            //entity.CertificateId = model.CertificateId;

            this.dbSet.Update(entity);
            await this.context.SaveChangesAsync();
        }

        public async Task<DemandMTRFileViewModel> GetDemandMTRFileViewModel(int demandClientId)
        {
            var viewModel = new DemandMTRFileViewModel();
            viewModel.DemandClient = await GetViewModelByIdAsync(demandClientId);
            viewModel.Demand = await demandServices.GetViewModelByIdAsync(viewModel.DemandClient.DemandId);
            viewModel.Transporter = await transporterServices.GetViewModelByIdAsync(viewModel.Demand.TransporterId);
            viewModel.TransporterDriver = await transporterDriverServices.GetViewModelByIdAsync(viewModel.Demand.TransporterDriverId);
            viewModel.TransporterVehicle = await transporterVehicleServices.GetViewModelByIdAsync(viewModel.Demand.TransporterVehicleId);

            var clientAddress = await clientCollectionAddressServices.GetViewModelByIdAsync(viewModel.DemandClient.ClientCollectionAddressId);
            viewModel.Client = await clientServices.GetViewModelByIdAsync(clientAddress.ClientId);

            var mainAddress = await clientCollectionAddressServices.GetFirstDataAsync(x => x.ClientId == clientAddress.ClientId && x.Main);
            if(mainAddress == null) mainAddress = await clientCollectionAddressServices.GetFirstDataAsync(x => x.ClientId == clientAddress.ClientId);
            viewModel.ClientMainAddress = clientCollectionAddressServices.ToViewModel(mainAddress);

            var contact = await clientContactServices.dbSet.AnyAsync(x => x.MainContact && x.ClientId == clientAddress.ClientId) ? await clientContactServices.dbSet.FirstOrDefaultAsync(x => x.MainContact && x.ClientId == clientAddress.ClientId) : await clientContactServices.dbSet.FirstOrDefaultAsync(x => x.ClientId == clientAddress.ClientId);
            if (contact != null) viewModel.ClientContact = clientContactServices.ToViewModel(contact);

            if (viewModel.DemandClient.ContractId.HasValue)
            { //Residuos do Contrato
                var residueIds = (await contractResidueServices.GetDataAsNoTrackingAsync(x => x.ContractId == viewModel.DemandClient.ContractId)).Select(x => x.ResidueId);
                viewModel.ContractResidues = await residueListServices.GetViewModelAsNoTrackingAsync(x => residueIds.Contains(x.ResidueId));
            }
            else //Residuos do Serviço
            {
                var residueFamilyIds = (await serviceResidueFamilyPriceServices.GetDataAsNoTrackingAsync(x => x.ServiceId == viewModel.DemandClient.ServiceId)).Select(x => x.ResidueFamilyId);
                viewModel.ContractResidues = await residueListServices.GetViewModelAsNoTrackingAsync(x => residueFamilyIds.Contains(x.ResidueFamilyId));
            }

            var demandeResidueFamilyIds = this.context.DemandResidueFamily.Where(x => x.DemandId == viewModel.Demand.DemandId && x.ClientCollectionAddressId == viewModel.DemandClient.ClientCollectionAddressId).AsNoTracking().Select(x => x.ResidueFamilyId);
            viewModel.DemandResidueFamilies = await this.context.ResidueFamily.Where(x => demandeResidueFamilyIds.Contains(x.ResidueFamilyId)).Select(x => x.CopyToEntity<ResidueFamilyViewModel>()).ToListAsync();

            return viewModel;
        }

        public async Task UpdateMTRFile(int demandClientId, string fileGuidName, string fileName, string fileMimeType)
        {
            var entity = await this.GetDataByIdAsync(demandClientId);

            entity.MTRFileGuidName = fileGuidName;
            entity.MTRFileName = fileName;
            entity.MTRFileMimeType = fileMimeType;

            this.dbSet.Update(entity);
            await this.context.SaveChangesAsync();
        }
        public bool TryGetMTRFile(int demandClientId, out ApplicationDbContext.Models.DemandClient demandClient)
        {
            demandClient = this.dbSet.FirstOrDefault(x => x.DemandClientId == demandClientId && !string.IsNullOrWhiteSpace(x.MTRFileGuidName));

            return demandClient != null;
        }
        public async Task<int> GetNewCertificateId()
        {
            var certificateIds = (await GetDataAsNoTrackingAsync(x => x.CertificateId.HasValue)).Select(x => x.CertificateId);
            if (certificateIds.Count() == 0) return 1;

            return certificateIds.Max(x => x.Value) + 1;
        }

        public async Task<bool> ExistClientFromDemand(int demandId, int clientId)
        {
            var clientCollectionAddressIds = this.context.ClientCollectionAddress.Where(x => x.ClientId == clientId).AsNoTracking().Select(x => x.ClientCollectionAddressId);

            return await Task.Run(async () => await this.dbSet.AnyAsync(x => x.DemandId == demandId && clientCollectionAddressIds.Contains(x.ClientCollectionAddressId)));
        }

        public async Task<List<ClientViewModel>> GetClientsByDemandId(int demandId)
        {
            return await Task.Run(async () =>
            (
                from y in await GetDataAsNoTrackingAsync(x => x.DemandId == demandId)
                join cca in this.context.ClientCollectionAddress.AsNoTracking() on y.ClientCollectionAddressId equals cca.ClientCollectionAddressId
                join c in this.context.Client.AsNoTracking() on cca.ClientId equals c.ClientId
                select c.CopyToEntity<ClientViewModel>()).ToList()
            );
        }

    }
}