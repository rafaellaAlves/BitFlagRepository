using ApplicationDbContext.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Services.Transporter
{
    public class TransporterEnvironmentalDocumentationLicenseResidueFamilyServices : Shared.BaseServices<TransporterEnvironmentalDocumentationLicenseResidueFamily, TransporterEnvironmentalDocumentationLicenseResidueFamily, int>
    {
        public TransporterEnvironmentalDocumentationLicenseResidueFamilyServices(ApplicationDbContext.Context.ApplicationDbContext context, AspNetIdentityDbContext.ApplicationDbContext identityContext) : base(context, identityContext, "TransporterEnvironmentalDocumentationLicenseResidueFamilyId")
        {
        }
        public async Task CreateRange(IEnumerable<TransporterEnvironmentalDocumentationLicenseResidueFamily> datas)
        {
            await this.dbSet.AddRangeAsync(datas);
            await this.context.SaveChangesAsync();
        }

        public async Task DeleteDefinitivelyByTransporterEnvironmentalDocumentationId(int transporterEnvironmentalDocumentationId)
        {
            this.dbSet.RemoveRange(await GetDataAsync(x => x.TransporterEnvironmentalDocumentationId == transporterEnvironmentalDocumentationId));
            await this.context.SaveChangesAsync();
        }
    }
}
