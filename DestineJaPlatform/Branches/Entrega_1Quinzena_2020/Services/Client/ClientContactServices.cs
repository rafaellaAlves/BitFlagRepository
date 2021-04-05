using ApplicationDbContext.Models;
using DTO.Client;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using DTO.Contract;
using Microsoft.EntityFrameworkCore.Internal;
using DTO.Service;
using DTO.Utils;

namespace Services.Client
{
    public class ClientContactServices : Shared.BaseServices<ClientContact, ClientContactViewModel, int>
    {
        private readonly ClientContactTypeServices clientContactTypeServices;

        public ClientContactServices(ApplicationDbContext.Context.ApplicationDbContext context, AspNetIdentityDbContext.ApplicationDbContext identityContext, ClientContactTypeServices clientContactTypeServices) : base(context, identityContext, "ClientContactId")
        {
            this.clientContactTypeServices = clientContactTypeServices;
        }

        public async Task<bool> Exist(ClientContactViewModel model) => await this.dbSet.AnyAsync(x => x.Name.Replace(" ", String.Empty) == model.Name.Replace(" ", String.Empty) && x.Phone.Replace(" ", String.Empty) == model.Phone.Replace(" ", String.Empty) && x.Email.Replace(" ", String.Empty) == model.Email.Replace(" ", String.Empty));

        public bool Exist(ContractViewModel model, out ClientContactViewModel contact)
        {
            contact = new ClientContactViewModel();

            var entity = this.dbSet.FirstOrDefaultAsync(x => x.Name.Replace(" ", String.Empty) == model.ContactName.Replace(" ", String.Empty) && x.Phone.Replace(" ", String.Empty) == model.ContactPhone.Replace(" ", String.Empty) && x.Email.Replace(" ", String.Empty) == model.ContactEmail.Replace(" ", String.Empty) && !x.IsDeleted).Result;

            var clientContactTypeId = clientContactTypeServices.GetDataByExternalCodeAsync("ACOMPANHARCOLETA").Result?.ClientContactTypeId;

            if (entity != null)//For Update Contact Data
            {
                contact = ToViewModel(entity);
            }

            contact.ClientId = model.ClientId.Value;
            contact.Name = model.ContactName;
            contact.Email = model.ContactEmail;
            contact.Phone = model.ContactPhone;
            contact.MobilePhone = model.ContactMobilePhone;
            if (entity == null) contact.ClientContactTypeId = clientContactTypeId ?? 1;
            contact.MainContact = true;
            contact.Role = model.ContactRole;
            contact.CPF = model.ContactCpf;

            return entity != null;
        }

        public bool Exist(ServiceViewModel model, out ClientContactViewModel contact)
        {
            contact = new ClientContactViewModel();

            var contractName = model.ContactName?.Replace(" ", string.Empty);
            var contactPhone = model.ContactPhone?.Replace(" ", string.Empty);
            var contactEmail = model.ContactEmail?.Replace(" ", string.Empty);

            var entity = this.dbSet.FirstOrDefaultAsync(x => x.Name.Replace(" ", string.Empty) == contractName && x.Phone.Replace(" ", string.Empty) == contactPhone && x.Email.Replace(" ", string.Empty) == contactEmail).Result;

            if (entity != null)//For Update Contact Data
                contact = entity.CopyToEntity<ClientContactViewModel>();

            var clientContactTypeId = clientContactTypeServices.GetDataByExternalCodeAsync("ACOMPANHARCOLETA").Result?.ClientContactTypeId;

            contact.ClientId = model.ClientId.Value;
            contact.Name = model.ContactName;
            contact.Email = model.ContactEmail;
            contact.Phone = model.ContactPhone ?? "";
            contact.MobilePhone = model.ContactMobilePhone;
            if (entity == null) contact.ClientContactTypeId = clientContactTypeId ?? 1;
            contact.MainContact = true;
            contact.Role = model.ContactRole;
            contact.CPF = model.ContactCpf;

            return entity != null;
        }

        public async Task<bool> ClientHaveMainContact(int clientId) => await this.dbSet.AnyAsync(x => x.MainContact && x.ClientId == clientId);

        public async Task<bool> ExistMainContact(int clientId, int? clientContactId) => await this.dbSet.AnyAsync(x => x.MainContact && x.ClientId == clientId && (!clientContactId.HasValue || x.ClientContactId != clientContactId));

        public async Task<ClientContact> GetMainContact(int clientId) => await this.dbSet.FirstOrDefaultAsync(x => x.MainContact && x.ClientId == clientId);

        public async Task RemoveMainContract(int clientId)
        {
            var entities = await GetDataAsync(x => x.ClientId == clientId);

            entities.ForEach(x => x.MainContact = false);
            this.dbSet.UpdateRange(entities);
            await this.context.SaveChangesAsync();
        }
    }
}
