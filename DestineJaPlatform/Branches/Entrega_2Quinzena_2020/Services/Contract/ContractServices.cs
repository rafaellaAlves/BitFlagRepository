using ApplicationDbContext.Models;
using DTO.Contract;
using DTO.Residue;
using DTO.Shared;
using DTO.Utils;
using Microsoft.AspNetCore.Identity;
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

namespace Services.Contract
{
    public class ContractServices : Shared.BaseServices<ApplicationDbContext.Models.Contract, ContractViewModel, int>
    {
        private readonly ContractResidueServices contractResidueServices;
        private readonly ResidueServices residueServices;
        private readonly ResidueFamilyListService residueFamilyListService;
        private readonly UnitOfMeasurementServices unitOfMeasurementServices;
        private readonly ClientServices clientServices;
        private readonly ContractStatusServices contractStatusServices;

        public ContractServices(ApplicationDbContext.Context.ApplicationDbContext context, AspNetIdentityDbContext.ApplicationDbContext identityContext, ContractResidueServices contractResidueServices, ResidueServices residueServices, ResidueFamilyListService residueFamilyListService, UnitOfMeasurementServices unitOfMeasurementServices, ClientServices clientServices, ContractStatusServices contractStatusServices) : base(context, identityContext, "ContractId")
        {
            this.contractResidueServices = contractResidueServices;
            this.residueServices = residueServices;
            this.residueFamilyListService = residueFamilyListService;
            this.unitOfMeasurementServices = unitOfMeasurementServices;
            this.clientServices = clientServices;
            this.contractStatusServices = contractStatusServices;
        }

        public async Task<IEnumerable<ApplicationDbContext.Models.Contract>> GetDataByClientIdAsync(int clientId)
        {
            return await GetDataAsNoTrackingAsync(x => x.ClientId == clientId);
        }

        public async Task<int> Renew(ContractViewModel model)
        {
            var oldEntity = await GetDataByIdAsync(model.ContractId.Value);

            var entity = model.CopyToEntity<ApplicationDbContext.Models.Contract>();
            entity.ClientId = oldEntity.ClientId;
            entity.RenewFrom = oldEntity.ContractId;
            entity.RenewDate = DateTime.Now;
            entity.Code = await GetNewCode(entity.ClientId, entity.StartContract);
            entity.TermAccepted = false;
            entity.TermAcceptedDate = null;
            entity.AcceptTermEmailSended = false;
            entity.AcceptTermToken = null;
            entity.ContractId = 0;
            entity.ContractStatusId = (await contractStatusServices.GetDataByExternalCode("CONTRATOCRIADO"))?.ContractStatusId ?? oldEntity.ContractStatusId;

            await this.dbSet.AddAsync(entity);
            await this.context.SaveChangesAsync();

            return entity.ContractId;
        }

        /// <summary>
        /// Check if a contract was already renewed
        /// </summary>
        /// <param name="contractId"></param>
        /// <returns></returns>
        public async Task<bool> Renewed(int? contractId)
        {
            if (!contractId.HasValue) return false;

            return await this.dbSet.AnyAsync(x => x.RenewFrom == contractId);
        }
        public async Task<string> GetNewCode(int clientId, DateTime startContract)
        {
            var entities = await GetDataAsNoTrackingAsync(x => x.ClientId == clientId && x.StartContract.Year == startContract.Year && !x.IsDeleted);

            if (entities.Count == 0) return $"{clientId}/{startContract.Year}";

            return $"{clientId}/{startContract.Year}/{entities.Count}";
        }
        /// <summary>
        /// Verifica se existe um contrato com o clientId informado
        /// </summary>
        public async Task<bool> UsingClient(int clientId)
        {
            return await this.dbSet.AnyAsync(x => x.ClientId == clientId && !x.IsDeleted);
        }
        public bool TryGetContractFile(int contractId, out ApplicationDbContext.Models.Contract contract)
        {
            contract = this.dbSet.FirstOrDefault(x => x.ContractId == contractId && !string.IsNullOrWhiteSpace(x.FileGuidName));

            return contract != null;
        }
        public async Task UpdateContractFile(int contractId, string fileGuidName, string fileName, string fileMimeType)
        {
            var entity = await this.GetDataByIdAsync(contractId);
            var acceptedId = (await contractStatusServices.GetDataByExternalCode("CONTRATOASSINADO"))?.ContractStatusId;

            entity.FileGuidName = fileGuidName;
            entity.FileName = fileName;
            entity.FileMimeType = fileMimeType;
            if (acceptedId.HasValue) entity.ContractStatusId = acceptedId.Value;

            this.dbSet.Update(entity);
            await this.context.SaveChangesAsync();
        }
        public async Task<ContractPrintViewModel> GetContractPrintViewModel(int contractId)
        {
            var contract = await GetViewModelByIdAsync(contractId);
            var contractResiduePrices = contractResidueServices.ToViewModel(await contractResidueServices.GetDataAsNoTrackingAsync(x => x.ContractId == contractId));

            var quilogramaId = (await unitOfMeasurementServices.GetDataByExternalCode("KILOGRAMA")).UnitOfMeasurementId;
            Dictionary<int, double> factors = new Dictionary<int, double>();
            contractResiduePrices.ForEach(x => factors.Add(x.ContractResidueId, unitOfMeasurementServices.GetFactor(x.UnitOfMeasurementId, quilogramaId)));

            var familyIDs = contractResiduePrices.Select(x => x.ResidueFamilyId);
            var families = await residueFamilyListService.GetViewModelAsNoTrackingAsync(x => familyIDs.Contains(x.ResidueFamilyId));

            return new ContractPrintViewModel
            {
                Contract = contract,
                Client = await clientServices.GetViewModelByIdAsync(contract.ClientId.Value),
                Residues = families.ToDictionary(x => x, x => contractResiduePrices.Where(c => c.ResidueFamilyId == x.ResidueFamilyId).ToList()),
                PriceInKg = contractResiduePrices.Sum(x => (x.Price ?? 0) * factors[x.ContractResidueId])
            };
        }
        public async Task<Guid> GetAndSetEmailTokenAsync(int contractId)
        {
            var entity = await GetDataByIdAsync(contractId);

            Guid token = Guid.NewGuid();

            for (int i = 0; i < 10; i++)
            {
                if (!await this.dbSet.AnyAsync(x => x.AcceptTermToken != token && x.ContractId != contractId)) break;

                token = Guid.NewGuid();
            }

            entity.AcceptTermToken = token;

            this.dbSet.Update(entity);
            await this.context.SaveChangesAsync();

            return await Task.Run(() => token);
        }
        public async Task SetTermAcceptEmailSended(int contractId)
        {
            var entity = await GetDataByIdAsync(contractId);

            entity.AcceptTermEmailSended = true;

            if (entity.ContractStatusId != (await contractStatusServices.GetDataByExternalCode("CONTRATOASSINADO"))?.ContractStatusId)
            {
                entity.ContractStatusId = (await contractStatusServices.GetDataByExternalCode("CONTRATOENVIADO"))?.ContractStatusId ?? entity.ContractStatusId;
            }

            this.dbSet.Update(entity);
            await this.context.SaveChangesAsync();
        }
        public async Task SetTermAcceptEmailSendedDate(int contractId)
        {
            var entity = await GetDataByIdAsync(contractId);

            entity.AcceptTermEmailSendedDate = DateTime.Now;

            this.dbSet.Update(entity);
            await this.context.SaveChangesAsync();
        }
        public async Task<ApplicationDbContext.Models.Contract> GetDataByAcceptTermToken(string token)
        {
            var guid = new Guid(token);
            return await Task.Run(async () => await this.dbSet.FirstOrDefaultAsync(x => x.AcceptTermToken == guid));
        }
        public async Task<bool> ValidateAcceptTerm(int contractId, string fullName, string cpf)
        {
            var _cpf = cpf.NumbersOnly();
            var _fullName = fullName.ToUpper().Trim();

            return await Task.Run(async () => await this.dbSet.AnyAsync(x => x.ContractId == contractId && x.ContactCpf == _cpf)); //&& x.ContactName.ToUpper().Trim() == _fullName
        }
        public async Task AcceptTerm(int contractId)
        {
            var entity = await GetDataByIdAsync(contractId);
            var acceptedId = (await contractStatusServices.GetDataByExternalCode("CONTRATOASSINADO"))?.ContractStatusId;

            //entity.AcceptTermToken = null;
            entity.TermAccepted = true;
            entity.TermAcceptedDate = DateTime.Now;
            if (acceptedId.HasValue) entity.ContractStatusId = acceptedId.Value;

            this.dbSet.Update(entity);
            await this.context.SaveChangesAsync();
        }
        public async Task UpdateMainContact(ContractViewModel model)
        {
            var entity = await GetDataByIdAsync(model.ContractId.Value);

            entity.ContactCpf = model.ContactCpf;
            entity.ContactEmail = model.ContactEmail;
            entity.ContactMobilePhone = model.ContactMobilePhone;
            entity.ContactName = model.ContactName;
            entity.ContactPhone = model.ContactPhone;
            entity.ContactRole = model.ContactRole;

            this.dbSet.Update(entity);
            await this.context.SaveChangesAsync();
        }
        public async Task CreationConfirm(int id, int userId)
        {
            var entity = await GetDataByIdAsync(id);

            entity.CreationConfirmedDate = DateTime.Now;
            entity.CreationConfirmedBy = userId;

            this.dbSet.Update(entity);
            await this.context.SaveChangesAsync();
        }
        public async Task<int> GetRemainingCollections(int contractId)
        {
            using var command = context.Database.GetDbConnection().CreateCommand();

            command.CommandText = "SELECT [dbo].[GetRemainingCollections](@ContractId) as 'RemainingCollections'";
            command.Parameters.Add(new SqlParameter("@ContractId", contractId));

            context.Database.OpenConnection();

            using var result = await command.ExecuteReaderAsync();
            while (result.Read())
            {
                return await Task.Run(() => (int)result["RemainingCollections"]);
            }

            return await Task.Run(() => 0);
        }
        public async Task<int> GetTotalCollections(int contractId)
        {
            using var command = context.Database.GetDbConnection().CreateCommand();

            command.CommandText = "SELECT [dbo].[GetTotalCollections](@ContractId) as 'TotalCollections'";
            command.Parameters.Add(new SqlParameter("@ContractId", contractId));

            context.Database.OpenConnection();

            using var result = await command.ExecuteReaderAsync();
            while (result.Read())
            {
                return await Task.Run(() => (int)result["TotalCollections"]);
            }

            return await Task.Run(() => 0);
        }
        public async Task<ContractChangesEmailViewModel> GetContractChangesEmailViewModel(int contractId, List<int> residueIds)
        {
            return new ContractChangesEmailViewModel
            {
                Contract = await GetViewModelByIdAsync(contractId),
                Residues = await this.context.Residue.Where(x => residueIds.Contains(x.ResidueId)).AsNoTracking().Select(x => x.CopyToEntity<ResidueViewModel>()).ToListAsync()
            };
        }
        public async Task<bool> ContractIsSigned(int contractId)
        {
            var entity = await GetDataByIdAsync(contractId);
            var signedStatusId = (await contractStatusServices.GetDataByExternalCode("CONTRATOASSINADO"))?.ContractStatusId;

            return entity.ContractStatusId == signedStatusId;
        }
        public async Task<bool> Changed(int contractId, ContractViewModel model)
        {
            var entity = await GetDataByIdAsync(contractId);

            return (model.ParcelValue != entity.ParcelValue ||
                model.DueDay != entity.DueDay ||
                model.StartContract != entity.StartContract ||
                model.DueDate != entity.DueDate ||
                model.ContractPeriodicityId != entity.ContractPeriodicityId ||
                model.ContractedWeight != entity.ContractedWeight);
        }
        public async Task ResetConfirm(int contractId)
        {
            var entity = await GetDataByIdAsync(contractId);

            entity.CreationConfirmedBy = null;
            entity.CreationConfirmedDate = null;

            this.dbSet.Update(entity);
            await this.context.SaveChangesAsync();
        }

        /// <summary>
        /// Obtem o último contrato feito para determinado cliente
        /// </summary>
        public async Task<ApplicationDbContext.Models.Contract> GetContractByClient(int clientId)
        {
            var today = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);

            return await Task.Run(async () => (await GetDataAsNoTrackingAsync(x => x.ClientId == clientId && !x.IsDeleted && x.DueDate >= today)).OrderByDescending(x => x.StartContract).FirstOrDefault());
        }
        public async Task<bool> ClientHasAnyContract(int clientId) => await Task.Run(async () => await this.dbSet.AnyAsync(x => x.ClientId == clientId));
        public async Task<bool> ClientHasAnyContractOrService(int clientId) => await Task.Run(async () => await this.dbSet.AnyAsync(x => x.ClientId == clientId) || await this.context.Service.AnyAsync(x => x.ClientId == clientId));
        public async Task Close(int contractId, string closedReason)
        {
            var entity = await GetDataByIdAsync(contractId);
            entity.ClosedReason = closedReason;
            entity.ContractSituationId = (await this.context.ContractSituation.SingleAsync(x => x.ExternalCode == "ENCERRADO")).ContractSituationId;
            entity.ClosedDate = DateTime.Now;

            this.dbSet.Update(entity);
            await this.context.SaveChangesAsync();
        }
        public async Task Compliant(int contractId)
        {
            var entity = await GetDataByIdAsync(contractId);
            entity.ContractSituationId = (await this.context.ContractSituation.SingleAsync(x => x.ExternalCode == "ADIMPLENTE")).ContractSituationId;

            this.dbSet.Update(entity);
            await this.context.SaveChangesAsync();
        }
        public async Task Defaulting(int contractId)
        {
            var entity = await GetDataByIdAsync(contractId);
            entity.ContractSituationId = (await this.context.ContractSituation.SingleAsync(x => x.ExternalCode == "INADIMPLENTE")).ContractSituationId;

            this.dbSet.Update(entity);
            await this.context.SaveChangesAsync();
        }
        public async Task<DateTime?> GetClientCollectionAddressNextDateToDemand(int clientCollectionAddressId)
        {
            using var command = context.Database.GetDbConnection().CreateCommand();

            command.CommandText = "SELECT [dbo].[ClientCollectionAddressNextDateToDemand](@ClientCollectionAddressId) as 'NextCollection'";
            command.Parameters.Add(new SqlParameter("@ClientCollectionAddressId", clientCollectionAddressId));

            await context.Database.OpenConnectionAsync();

            using var result = await command.ExecuteReaderAsync();
            while (result.Read())
                return await Task.Run(() => result["NextCollection"].GetDateTimeFromDbDataReader());

            return await Task.Run(() => (DateTime?)null);
        }
        public async Task<DateTime?> GetNextDemandVisitedDateByContractId(int contractId, bool fromNow = true)
        {
            using var command = context.Database.GetDbConnection().CreateCommand();

            command.CommandText = "SELECT [dbo].[fn_GetNextDemandVisitedDateByContractId](@ContractId, @FromNow) as 'NextCollection'";
            command.Parameters.Add(new SqlParameter("@ContractId", contractId));
            command.Parameters.Add(new SqlParameter("@FromNow", fromNow));

            await context.Database.OpenConnectionAsync();

            using var result = await command.ExecuteReaderAsync();
            while (result.Read())
                return await Task.Run(() => result["NextCollection"].GetDateTimeFromDbDataReader());

            return await Task.Run(() => (DateTime?)null);
        }
        public async Task<int> GetContractThisMonth()
        {
            var signedStatusId = (await contractStatusServices.GetDataByExternalCode("CONTRATOASSINADO")).ContractStatusId;

            return await this.dbSet.CountAsync(x => x.CreatedDate.Month == DateTime.Now.Month && x.CreatedDate.Year == DateTime.Now.Year && !x.RenewFrom.HasValue && !x.IsDeleted && x.ContractStatusId == signedStatusId);
        }

        public async Task SignContract(int contractId, int userId)
        {
            var signedStatusId = (await contractStatusServices.GetDataByExternalCode("CONTRATOASSINADO")).ContractStatusId;

            var entity = await GetDataByIdAsync(contractId);

            entity.Signed = true;
            entity.SignedBy = userId;
            entity.ContractStatusId = signedStatusId;

            this.dbSet.Update(entity);
            await this.context.SaveChangesAsync();
        }

        public async Task<bool> ExistContractWithClient(int clientId, DateTime? date, int? contractId = null) => await this.dbSet.AnyAsync(x => x.ClientId == clientId && !x.IsDeleted && x.StartContract.Year == (date.HasValue ? date.Value.Year : DateTime.Now.Year) && (!contractId.HasValue || x.ContractId == contractId));
    }
}