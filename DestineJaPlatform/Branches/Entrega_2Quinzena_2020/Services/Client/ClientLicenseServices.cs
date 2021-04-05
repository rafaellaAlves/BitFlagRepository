using ApplicationDbContext.Models;
using DTO.Client;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Services.Client
{
    public class ClientLicenseServices : Shared.BaseServices<ClientLicense, ClientLicenseViewModel, int>
    {
        public ClientLicenseServices(ApplicationDbContext.Context.ApplicationDbContext context, AspNetIdentityDbContext.ApplicationDbContext identityContext) : base(context, identityContext, "ClientLicenseId")
        {
        }

        public async Task BasicUpdateAsync(ClientLicenseViewModel model)
        {
            var entity = GetDataById(model.ClientLicenseId.Value);

            if (model.DueDate.HasValue) entity.DueDate = model.DueDate.Value;

            entity.Issuer = model.Issuer;
            entity.IssueDate = model.IssueDate;
            entity.Name = model.Name;
            entity.DueDate = model.DueDate;
            entity.License = model.License;
            entity.DaysToNotify = model.DaysToNotify;
            entity.Email = model.Email;
            entity.Activity = model.Activity;

            this.dbSet.Update(entity);
            await this.context.SaveChangesAsync();
        }
    }
}
