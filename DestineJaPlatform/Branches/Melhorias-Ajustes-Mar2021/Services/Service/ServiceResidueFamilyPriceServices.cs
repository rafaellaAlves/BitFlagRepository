using ApplicationDbContext.Models;
using DTO.Service;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Linq.Expressions;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using Services.Residue;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using DTO.Utils;

namespace Services.Service
{
    public class ServiceResidueFamilyPriceServices : Shared.BaseServices<ServiceResidueFamilyPrice, ServiceResidueFamilyPriceViewModel, int>
    {
        private readonly ResidueFamilyServices residueFamilyServices;
        public ServiceResidueFamilyPriceServices(ApplicationDbContext.Context.ApplicationDbContext context, AspNetIdentityDbContext.ApplicationDbContext identityContext, ResidueFamilyServices residueFamilyServices) : base(context, identityContext, "ServiceResidueFamilyPriceId")
        {
            this.residueFamilyServices = residueFamilyServices;
        }

        public override async Task<List<ServiceResidueFamilyPriceViewModel>> GetViewModelAsNoTrackingAsync(Expression<Func<ServiceResidueFamilyPrice, bool>> expr)
        {
            var models = await base.GetDataAsNoTrackingAsync(expr);
            var familiesIds = models.Select(x => x.ResidueFamilyId);

            var families = await residueFamilyServices.GetDataAsNoTrackingAsync(x => familiesIds.Contains(x.ResidueFamilyId));
            var unitOfMeasurement = this.context.UnitOfMeasurement.AsNoTracking();

            return (from y in models
                    join x in families on y.ResidueFamilyId equals x.ResidueFamilyId
                    join um in unitOfMeasurement on y.UnitOfMeasurementId equals um.UnitOfMeasurementId
                    select new ServiceResidueFamilyPriceViewModel
                    {
                        Price = y.Price,
                        ResidueFamily = residueFamilyServices.ToViewModel(x),
                        ServiceId = y.ServiceId,
                        ResidueFamilyId = y.ResidueFamilyId,
                        ServiceResidueFamilyPriceId = y.ServiceResidueFamilyPriceId,
                        UnitOfMeasurementId = y.UnitOfMeasurementId,
                        UnitOfMeasurementName = um.Name,
                        MaximumPrice = y.MaximumPrice,
                        MinimumPrice = y.MinimumPrice,
                        MediumPrice = y.MediumPrice
                    }).ToList();
        }

        public async Task DeleteDefinitilyByServiceId(int serviceId)
        {
            this.dbSet.RemoveRange(await GetDataAsync(x => x.ServiceId == serviceId));
            await this.context.SaveChangesAsync();
        }

        public async Task CreateRangeAsync(IEnumerable<ServiceResidueFamilyPriceViewModel> models)
        {
            await this.dbSet.AddRangeAsync(models.Select(x => x.CopyToEntity<ServiceResidueFamilyPrice>()));
            await this.context.SaveChangesAsync();
        }
    }
}
