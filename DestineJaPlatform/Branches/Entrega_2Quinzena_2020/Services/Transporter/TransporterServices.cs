using DTO.Transporter;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Services.Transporter
{
    public class TransporterServices : Shared.BaseServices<ApplicationDbContext.Models.Transporter, TransporterViewModel, int>
    {
        public TransporterServices(ApplicationDbContext.Context.ApplicationDbContext context, AspNetIdentityDbContext.ApplicationDbContext identityContext) : base(context, identityContext, "TransporterId")
        {
        }

        //public async Task UpdateLicence(int transpoterId, string licence, int? licenceResidueFamilyId)
        //{
        //    var entity = await GetDataByIdAsync(transpoterId);

        //    entity.Licence = licence;
        //    entity.LicenceResidueFamilyId = licenceResidueFamilyId;

        //    this.dbSet.Update(entity);
        //    await this.context.SaveChangesAsync();
        //}

        public async Task<bool> ExistTransporter(TransporterViewModel model)
        {
            return await Task.Run(async () => await this.dbSet.AnyAsync(x => ((!string.IsNullOrWhiteSpace(model.CPF) && x.CPF == model.CPF) || (!string.IsNullOrWhiteSpace(model.CNPJ) && x.CNPJ == model.CNPJ)) && x.TransporterId != model.TransporterId && !x.IsDeleted));
        }

        public async Task ChangeActivity(int id, bool isActive)
        {
            var entity = await GetDataByIdAsync(id);

            entity.IsActive = isActive;

            this.dbSet.Update(entity);
            await this.context.SaveChangesAsync();
        }

        public async Task CreationComplete(int id)
        {
            var entity = await GetDataByIdAsync(id);

            entity.CreationComplete = true;

            this.dbSet.Update(entity);
            await this.context.SaveChangesAsync();
        }
    }
}
