using ApplicationDbContext.Models;
using DTO.Transporter;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Services.Transporter
{
    public class TransporterDriverServices : Shared.BaseServices<TransporterDriver, TransporterDriverViewModel, int>
    {
        public TransporterDriverServices(ApplicationDbContext.Context.ApplicationDbContext context, AspNetIdentityDbContext.ApplicationDbContext identityContext) : base(context, identityContext, "TransporterDriverId")
        {
        }
        public async Task BasicUpdateCNHFileAsync(TransporterDriverViewModel model)
        {
            var entity = GetDataById(model.TransporterDriverId.Value);

            entity.CNHGuidName = model.CNHGuidName;
            entity.CNHFileName = model.CNHFileName;
            entity.CNHMimeType = model.CNHMimeType;

            this.dbSet.Update(entity);
            await this.context.SaveChangesAsync();
        }
        public async Task BasicUpdateMOPPFileAsync(TransporterDriverViewModel model)
        {
            var entity = GetDataById(model.TransporterDriverId.Value);

            entity.MOPPGuidName = model.MOPPGuidName;
            entity.MOPPFileName = model.MOPPFileName;
            entity.MOPPMimeType = model.MOPPMimeType;

            this.dbSet.Update(entity);
            await this.context.SaveChangesAsync();
        }

        public async Task BasicUpdateASOFileAsync(TransporterDriverViewModel model)
        {
            var entity = GetDataById(model.TransporterDriverId.Value);

            entity.ASOGuidName = model.ASOGuidName;
            entity.ASOFileName = model.ASOFileName;
            entity.ASOMimeType = model.ASOMimeType;

            this.dbSet.Update(entity);
            await this.context.SaveChangesAsync();
        }

        public async Task ChangeActivity(int id, bool isActive)
        {
            var entity = await GetDataByIdAsync(id);

            entity.IsActive = isActive;

            this.dbSet.Update(entity);
            await this.context.SaveChangesAsync();
        }
    }
}
