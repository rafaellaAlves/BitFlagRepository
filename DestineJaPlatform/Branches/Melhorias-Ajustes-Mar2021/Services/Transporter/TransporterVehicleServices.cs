using ApplicationDbContext.Models;
using DTO.Transporter;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Services.Transporter
{
    public class TransporterVehicleServices : Shared.BaseServices<TransporterVehicle, TransporterVehicleViewModel, int>
    {
        public TransporterVehicleServices(ApplicationDbContext.Context.ApplicationDbContext context, AspNetIdentityDbContext.ApplicationDbContext identityContext) : base(context, identityContext, "TransporterVehicleId")
        {
        }

        public async Task<int> BasicUpdateAsync(TransporterVehicleViewModel model)
        {
            var entity = GetDataById(model.TransporterVehicleId.Value);

            entity.LicensePlate = model.LicensePlate;
            entity.DUT = model.DUT;
            entity.Model = model.Model;
            entity.Manufacturer = model.Manufacturer;
            entity.ManufacturingDate = model.ManufacturingDate;
            entity.CIV = model.CIV;
            entity.CIVDueDate = model.CIVDueDate;
            entity.CIPPModel = model.CIPPModel;
            entity.CIPPDueDate = model.CIPPDueDate;

            this.dbSet.Update(entity);
            await this.context.SaveChangesAsync();

            return model.TransporterVehicleId.Value;
        }

        public async Task BasicUpdateLicensePlateFileAsync(TransporterVehicleViewModel model)
        {
            var entity = GetDataById(model.TransporterVehicleId.Value);

            entity.LicensePlateGuidName = model.LicensePlateGuidName;
            entity.LicensePlateFileName = model.LicensePlateFileName;
            entity.LicensePlateMimeType = model.LicensePlateMimeType;

            this.dbSet.Update(entity);
            await this.context.SaveChangesAsync();
        }

        public async Task BasicUpdateDUTFileAsync(TransporterVehicleViewModel model)
        {
            var entity = GetDataById(model.TransporterVehicleId.Value);

            entity.DUTGuidName = model.DUTGuidName;
            entity.DUTFileName = model.DUTFileName;
            entity.DUTMimeType = model.DUTMimeType;

            this.dbSet.Update(entity);
            await this.context.SaveChangesAsync();
        }

        public async Task BasicUpdateCIVFileAsync(TransporterVehicleViewModel model)
        {
            var entity = GetDataById(model.TransporterVehicleId.Value);

            entity.CIVGuidName = model.CIVGuidName;
            entity.CIVFileName = model.CIVFileName;
            entity.CIVMimeType = model.CIVMimeType;

            this.dbSet.Update(entity);
            await this.context.SaveChangesAsync();
        }

        public async Task BasicUpdateCIPPFileAsync(TransporterVehicleViewModel model)
        {
            var entity = GetDataById(model.TransporterVehicleId.Value);

            entity.CIPPGuidName = model.CIPPGuidName;
            entity.CIPPFileName = model.CIPPFileName;
            entity.CIPPMimeType = model.CIPPMimeType;

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
