using DTO.Service;
using DTO.Utils;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Services.Client;
using Services.Residue;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Services.Service
{
    public class ServiceServices : Shared.BaseServices<ApplicationDbContext.Models.Service, ServiceViewModel, int>
    {
        private readonly ServiceStatusServices serviceStatusServices;
        private readonly ClientServices clientServices;
        private readonly ServiceFreightPaymentTermServices serviceFreightPaymentTermServices;
        private readonly ServiceResidualPaymentTermServices serviceResidualPaymentTermServices;
        private readonly UnitOfMeasurementServices unitOfMeasurementServices;
        private readonly ServiceResidueFamilyPriceServices serviceResidueFamilyPriceServices;
        private readonly ResidueFamilyServices residueFamilyServices;
        private readonly ResidueFamilyClassService residueFamilyClassService;

        public ServiceServices(ApplicationDbContext.Context.ApplicationDbContext context, AspNetIdentityDbContext.ApplicationDbContext identityContext, ServiceStatusServices serviceStatusServices, ClientServices clientServices, ServiceFreightPaymentTermServices serviceFreightPaymentTermServices, ServiceResidualPaymentTermServices serviceResidualPaymentTermServices, UnitOfMeasurementServices unitOfMeasurementServices, ServiceResidueFamilyPriceServices serviceResidueFamilyPriceServices, ResidueFamilyServices residueFamilyServices, ResidueFamilyClassService residueFamilyClassService) : base(context, identityContext, "ServiceId")
        {
            this.serviceStatusServices = serviceStatusServices;
            this.clientServices = clientServices;
            this.serviceFreightPaymentTermServices = serviceFreightPaymentTermServices;
            this.serviceResidualPaymentTermServices = serviceResidualPaymentTermServices;
            this.unitOfMeasurementServices = unitOfMeasurementServices;
            this.serviceResidueFamilyPriceServices = serviceResidueFamilyPriceServices;
            this.residueFamilyServices = residueFamilyServices;
            this.residueFamilyClassService = residueFamilyClassService;
        }

        public async Task<string> GetNewCode(int clientId)
        {
            return $"{clientId}/{(await this.dbSet.CountAsync(x => x.ClientId == clientId)) + 1}";
        }
        public async Task<bool> UsingClient(int clientId)
        {
            return await this.dbSet.AnyAsync(x => x.ClientId == clientId && !x.IsDeleted);
        }
        public async Task<bool> Cancel(int serviceId)
        {
            var entity = await GetDataByIdAsync(serviceId);

            var cancelStatus = await serviceStatusServices.GetDataByExternalCode("OSCANCELADA");
            if (cancelStatus == null) return await Task.Run(() => false);

            entity.ServiceStatusId = cancelStatus.ServiceStatusId;
            this.dbSet.Update(entity);
            await this.context.SaveChangesAsync();

            return await Task.Run(() => true);
        }
        public async Task<ServicePrintViewModel> GetServicePrintViewModel(int serviceId)
        {
            return await Task.Run(async () =>
            {
                var service = await GetViewModelByIdAsync(serviceId);
                var serviceFamilyPrices = await serviceResidueFamilyPriceServices.GetViewModelAsNoTrackingAsync(x => x.ServiceId == serviceId);
                //Todos preços de Serviços são guardados como tonelada e na tela de impressão são exibidos em quilogramas.
                var quilogramaId = (await unitOfMeasurementServices.GetDataByExternalCode("KILOGRAMA")).UnitOfMeasurementId;
                var priceInKg = serviceFamilyPrices.Sum(x => (x.Price ?? 0) * unitOfMeasurementServices.GetFactor(x.UnitOfMeasurementId, quilogramaId));

                return new ServicePrintViewModel
                {
                    Service = service,
                    Client = await clientServices.GetViewModelByIdAsync(service.ClientId.Value),
                    ResidueFamilyPrice = serviceFamilyPrices,
                    ServiceFreightPaymentTermDays = (await serviceFreightPaymentTermServices.GetDataByIdAsync(service.ServiceFreightPaymentTermId)).Days,
                    ServiceResidueFamilyPriceDays = (await serviceResidualPaymentTermServices.GetDataByIdAsync(service.ServiceResidualPaymentTermId)).Days,
                    PriceInKg = priceInKg
                };
            });
        }
        public async Task<Guid> GetAndSetEmailTokenAsync(int serviceId)
        {
            var entity = await GetDataByIdAsync(serviceId);

            Guid token = Guid.NewGuid();

            for (int i = 0; i < 10; i++)
            {
                if (!await this.dbSet.AnyAsync(x => x.AcceptTermToken == token && x.ServiceId != serviceId)) break;

                token = Guid.NewGuid();
            }

            entity.AcceptTermToken = token;

            this.dbSet.Update(entity);
            await this.context.SaveChangesAsync();

            return await Task.Run(() => token);
        }
        public async Task SetTermAcceptEmailSended(int serviceId)
        {
            var entity = await GetDataByIdAsync(serviceId);

            entity.AcceptTermEmailSended = true;

            if (entity.ServiceStatusId != (await serviceStatusServices.GetDataByExternalCode("OSASSINADA"))?.ServiceStatusId)
            {
                entity.ServiceStatusId = (await serviceStatusServices.GetDataByExternalCode("OSENVIADA"))?.ServiceStatusId ?? entity.ServiceStatusId;
            }

            this.dbSet.Update(entity);
            await this.context.SaveChangesAsync();
        }
        public async Task SetTermAcceptEmailSendedDate(int serviceId)
        {
            var entity = await GetDataByIdAsync(serviceId);

            entity.AcceptTermEmailSendedDate = DateTime.Now;

            this.dbSet.Update(entity);
            await this.context.SaveChangesAsync();
        }
        public async Task<ApplicationDbContext.Models.Service> GetDataByAcceptTermToken(string token)
        {
            var guid = new Guid(token);
            return await Task.Run(async () => await this.dbSet.FirstOrDefaultAsync(x => x.AcceptTermToken == guid));
        }
        public async Task<bool> ValidateAcceptTerm(int serviceId, string fullName, string cpf)
        {
            var _cpf = cpf.NumbersOnly();
            var _fullName = fullName.ToUpper().Trim();

            return await Task.Run(async () => await this.dbSet.AnyAsync(x => x.ServiceId == serviceId && x.ContactCpf == _cpf)); //&& x.ContactName.ToUpper().Trim() == _fullName 
        }
        public async Task AcceptTerm(int serviceId)
        {
            var entity = await GetDataByIdAsync(serviceId);
            var acceptedId = (await serviceStatusServices.GetDataByExternalCode("OSASSINADA"))?.ServiceStatusId;

            //entity.AcceptTermToken = null;
            entity.TermAccepted = true;
            entity.TermAcceptedDate = DateTime.Now;
            if (acceptedId.HasValue) entity.ServiceStatusId = acceptedId.Value;

            this.dbSet.Update(entity);
            await this.context.SaveChangesAsync();
        }
        public bool TryGetServiceOrderFile(int serviceId, out ApplicationDbContext.Models.Service service)
        {
            service = this.dbSet.FirstOrDefault(x => x.ServiceId == serviceId && !string.IsNullOrWhiteSpace(x.ServiceOrderFileGuidName));

            return service != null;
        }
        public async Task UpdateServiceOrderFile(int serviceId, string serviceOrderFileGuidName, string serviceOrderFileName, string serviceOrderMimeType)
        {
            var entity = await this.GetDataByIdAsync(serviceId);
            var acceptedId = (await serviceStatusServices.GetDataByExternalCode("OSASSINADA"))?.ServiceStatusId;

            entity.ServiceOrderFileGuidName = serviceOrderFileGuidName;
            entity.ServiceOrderFileName = serviceOrderFileName;
            entity.ServiceOrderMimeType = serviceOrderMimeType;
            if (acceptedId.HasValue) entity.ServiceStatusId = acceptedId.Value;

            this.dbSet.Update(entity);
            await this.context.SaveChangesAsync();
        }
        public async Task UpdateMainContact(ServiceViewModel model)
        {
            var entity = await GetDataByIdAsync(model.ServiceId.Value);

            entity.ContactCpf = model.ContactCpf;
            entity.ContactEmail = model.ContactEmail;
            entity.ContactMobilePhone = model.ContactMobilePhone;
            entity.ContactName = model.ContactName;
            entity.ContactPhone = model.ContactPhone;
            entity.ContactRole = model.ContactRole;

            this.dbSet.Update(entity);
            await this.context.SaveChangesAsync();
        }
        public async IAsyncEnumerable<DemandServiceResidueViewModel> GetDemandClientResidueByServiceId(int? serviceId)
        {
            if (serviceId.HasValue)
            {
                using var command = context.Database.GetDbConnection().CreateCommand();

                command.CommandText = "pr_GetDemandClientResidueByServiceId @ServiceId = @_ServiceId";
                command.Parameters.Add(new SqlParameter("@_ServiceId", serviceId));

                context.Database.OpenConnection();

                using var result = await command.ExecuteReaderAsync();
                while (result.Read())
                {
                    yield return new DemandServiceResidueViewModel
                    {
                        IBAMACode = result["IBAMACode"].ToString(),
                        ResidueFamilyName = result["ResidueFamilyName"].ToString(),
                        ResidueFamilyNameAbbreviation = result["ResidueFamilyNameAbbreviation"].ToString(),
                        ResidueName = result["ResidueName"].ToString(),
                        Weight = (double)result["Weight"],
                        UnitOfMeasurementName = result["UnitOfMeasurementName"].ToString(),
                        Price = (double)result["Price"]
                    };
                }
            }
        }
        public async Task<double> GetServiceResidueTotalPrice(int? serviceId)
        {
            if (!serviceId.HasValue) return await Task.Run(() => 0d);

            using var command = context.Database.GetDbConnection().CreateCommand();

            command.CommandText = "pr_GetServiceResidueTotalPrice @ServiceId = @_ServiceId";
            command.Parameters.Add(new SqlParameter("@_ServiceId", serviceId));

            context.Database.OpenConnection();

            using var result = await command.ExecuteReaderAsync();
            while (result.Read())
            {
                return await Task.Run(() => (result["Price"] != DBNull.Value ? (double)result["Price"] : 0d));
            }

            return await Task.Run(() => 0d);
        }
        public async Task<LastDemandClientServiceInfoViewModel> GetLastDemandClientServiceInfo(int? clientId)
        {
            if (!clientId.HasValue) return await Task.Run(() => (LastDemandClientServiceInfoViewModel)null);

            using var command = context.Database.GetDbConnection().CreateCommand();

            command.CommandText = "pr_GetLastDemandClientServiceInfo @ClientId = @_ClientId";
            command.Parameters.Add(new SqlParameter("@_ClientId", clientId));

            context.Database.OpenConnection();

            using var result = await command.ExecuteReaderAsync();
            while (result.Read())
            {
                return await Task.Run(() => new LastDemandClientServiceInfoViewModel
                {
                    ClientId = (int)result["ClientId"],
                    DemandId = (int)result["DemandId"],
                    Price = result["Price"].GetDoubleFromDbDataReader(),
                    ContractId = result["ContractId"] == DBNull.Value? null : (int?)result["ContractId"],
                    ServiceId = result["ServiceId"] == DBNull.Value ? null : (int?)result["ServiceId"],
                    VisitedDate = result["VisitedDate"].GetDateTimeFromDbDataReader(),
                    DemandCreatedDate = result["DemandCreatedDate"].GetDateTimeFromDbDataReader(),
                    Weight = (double?)result["Weight"],
                    AlternativeDemandId = result["AlternativeDemandId"] == DBNull.Value ? "" : result["AlternativeDemandId"].ToString(),
                });
            }

            return await Task.Run(() => (LastDemandClientServiceInfoViewModel)null);
        }
        public async Task CreationConfirm(int id, int userId)
        {
            var entity = await GetDataByIdAsync(id);

            entity.CreationConfirmedDate = DateTime.Now;
            entity.CreationConfirmedBy = userId;

            this.dbSet.Update(entity);
            await this.context.SaveChangesAsync();
        }
        public async Task<List<ApplicationDbContext.Models.Service>> GetServicesByClientCollectionAddressId(int addressId)
        {
            var clientId = (await this.context.ClientCollectionAddress.SingleOrDefaultAsync(x => x.ClientCollectionAddressId == addressId)).ClientId;

            return await Task.Run(async () => await GetDataAsNoTrackingAsync(x => x.ClientId == clientId));
        }
        public async Task<int> GetServiceThisMonth() => await this.dbSet.CountAsync(x => x.CreatedDate.Month == DateTime.Now.Month && x.CreatedDate.Year == DateTime.Now.Year && !x.IsDeleted);
    }
}
