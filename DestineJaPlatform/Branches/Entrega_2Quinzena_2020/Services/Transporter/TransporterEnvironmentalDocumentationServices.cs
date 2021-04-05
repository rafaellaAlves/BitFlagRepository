using ApplicationDbContext.Models;
using DTO.Transporter;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Linq;

namespace Services.Transporter
{
    public class TransporterEnvironmentalDocumentationServices : Shared.BaseServices<TransporterEnvironmentalDocumentation, TransporterEnvironmentalDocumentationViewModel, int>
    {
        private readonly TransporterEnvironmentalDocumentationLicenseResidueFamilyServices transporterEnvironmentalDocumentationLicenseResidueFamilyServices;

        public TransporterEnvironmentalDocumentationServices(ApplicationDbContext.Context.ApplicationDbContext context, AspNetIdentityDbContext.ApplicationDbContext identityContext, TransporterEnvironmentalDocumentationLicenseResidueFamilyServices transporterEnvironmentalDocumentationLicenseResidueFamilyServices) : base(context, identityContext, "TransporterEnvironmentalDocumentationId")
        {
            this.transporterEnvironmentalDocumentationLicenseResidueFamilyServices = transporterEnvironmentalDocumentationLicenseResidueFamilyServices;
        }
        public async Task BasicUpdateAsync(TransporterEnvironmentalDocumentationViewModel model)
        {
            var entity = GetDataById(model.TransporterEnvironmentalDocumentationId.Value);

            if (model.DueDate.HasValue) entity.DueDate = model.DueDate.Value;

            entity.ActivityName = model.ActivityName;
            entity.Issuer = model.Issuer;
            entity.IssuerDate = model.IssuerDate;
            entity.Name = model.Name;
            entity.IsRSSFile = model.IsRSSFile;
            entity.License = model.License;
            entity.Email = model.Email;
            entity.DaysToNotify = model.DaysToNotify;

            this.dbSet.Update(entity);
            await this.context.SaveChangesAsync();
        }
        public async Task RemoveRSSFlag(int transporterId)
        {
            var entities = await GetDataAsync(x => x.TransporterId == transporterId && x.IsRSSFile);
            entities.ForEach(x => x.IsRSSFile = false);

            this.dbSet.UpdateRange(entities);
            await this.context.SaveChangesAsync();
        }
        public async Task<TransporterEnvironmentalDocumentation> GetDataByTransporterAndResidueFamily(int transporterId, int residueFamilyId)
        {
            var transporterEnvironmentalDocumentations = (await GetDataAsNoTrackingAsync(x => x.TransporterId == transporterId && x.IsRSSFile)).Select(x => x.TransporterEnvironmentalDocumentationId);

            var licensesResidueFamilies = await transporterEnvironmentalDocumentationLicenseResidueFamilyServices.GetDataAsNoTrackingAsync(x => transporterEnvironmentalDocumentations.Contains(x.TransporterEnvironmentalDocumentationId));

            var license = licensesResidueFamilies.FirstOrDefault(x => x.LicenseResidueFamilyId == residueFamilyId);

            return license == null ? null : await GetDataByIdAsync(license.TransporterEnvironmentalDocumentationId);
        }
    }
}
