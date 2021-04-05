using ApplicationDbContext.Models;
using DTO.Residue;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Linq.Expressions;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace Services.Residue
{
    public class ResiduePriceServices : Shared.BaseServices<ResiduePrice, ResiduePriceViewModel, int>
    {
        private readonly ResidueServices residueServices;
        private readonly UnitOfMeasurementServices unitOfMeasurementServices;
        public ResiduePriceServices(ApplicationDbContext.Context.ApplicationDbContext context, AspNetIdentityDbContext.ApplicationDbContext identityContext, ResidueServices residueServices, UnitOfMeasurementServices unitOfMeasurementServices) : base(context, identityContext, "ResiduePriceId")
        {
            this.residueServices = residueServices;
            this.unitOfMeasurementServices = unitOfMeasurementServices;
        }

        public async Task<ResiduePriceVariationViewModel> GetResiduePriceVariation(int residueFamilyId, int unitOfMeasurement)
        {
            var prices = await this.GetDataAsNoTrackingAsync(c => c.ResidueFamilyId == residueFamilyId && !c.IsDeleted);

            Dictionary<int, double> convertedPrice = new Dictionary<int, double>(); //preco convertido para tipo de medido escolhido;
            prices.ForEach(c => convertedPrice.Add(c.ResiduePriceId, unitOfMeasurementServices.GetFactor(c.UnitOfMeasurementId, unitOfMeasurement) * c.Price));

            return new ResiduePriceVariationViewModel
            {
                MinimumPrice = prices.Count > 0 ? prices.Min(x => convertedPrice[x.ResiduePriceId]) : (double?)null,
                MediumPrice = prices.Count > 0 ? (prices.Sum(x => convertedPrice[x.ResiduePriceId]) / prices.Count) : (double?)null,
                MaximumPrice = prices.Count > 0 ? prices.Max(x => convertedPrice[x.ResiduePriceId]) : (double?)null,
            };
        }

        public async Task<bool> ExistResiduePrice(ResiduePriceViewModel model)
        {
            return await this.dbSet.AnyAsync(x => !model.ResiduePriceId.HasValue && x.ResidueFamilyId == model.ResidueFamilyId && x.RecipientId == model.RecipientId);
        }
    }
}
