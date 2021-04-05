using AMaisImob_DB.Models;
using BLL;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AMaisImob_WEB.BLL
{
    public class CertificateContractualQuoteFunctions : BLLBasicFunctions<CertificateContractualQuote, CertificateContractualQuote>
    {
        private readonly CategoryGuarantorProductTaxFunctions categoryGuarantorProductTaxFunctions;
        private readonly ResidenceTypeFunctions residenceTypeFunctions;

        public CertificateContractualQuoteFunctions(AMaisImob_HomologContext context, CategoryGuarantorProductTaxFunctions categoryGuarantorProductTaxFunctions, ResidenceTypeFunctions residenceTypeFunctions) : base(context, "CertificateContractualQuoteId")
        {
            this.categoryGuarantorProductTaxFunctions = categoryGuarantorProductTaxFunctions;
            this.residenceTypeFunctions = residenceTypeFunctions;
        }

        public override int Create(CertificateContractualQuote model)
        {
            this.dbSet.Add(model);
            this.context.SaveChanges();

            return model.CategoryGuarantorProductTaxId;
        }

        public void CreateRange(IEnumerable<CertificateContractualQuote> models)
        {
            this.dbSet.AddRange(models);
            this.context.SaveChanges();
        }

        public override void Delete(object id)
        {
            this.dbSet.Remove(GetDataByID(id));
            this.context.SaveChanges();
        }

        public void DeleteByCertificateContractualId(int certificateContractualId)
        {
            this.dbSet.RemoveRange(GetData(x => x.CertificateContractualId == certificateContractualId));
            this.context.SaveChanges();
        }

        public IEnumerable<CertificateContractualQuote> GetDataByCertificateContractualId(int certificateContractualId)
        {
            return GetData(x => x.CertificateContractualId == certificateContractualId).AsNoTracking();
        }

        public override List<CertificateContractualQuote> GetDataViewModel(IEnumerable<CertificateContractualQuote> data)
        {
            return data.ToList();
        }

        public override CertificateContractualQuote GetDataViewModel(CertificateContractualQuote data)
        {
            return data;
        }

        public override void Update(CertificateContractualQuote model)
        {
            throw new NotImplementedException();
        }

        protected override void SetDbSet()
        {
            this.dbSet = context.CertificateContractualQuote;
        }

        /// <summary>
        /// Obtem as cotações disponiveis no momento
        /// </summary>
        /// <param name="categoryId"></param>
        /// <param name="residenceTypeId"></param>
        /// <param name="guarantorProductId"></param>
        /// <returns></returns>
        public async Task<IEnumerable<int>> GetAvailableCategoryGuarantorProductTaxIds(int? categoryId, int? residenceTypeId, int? guarantorProductId, decimal? price = null, decimal? rentAndChargesPrice = null)
        {
            categoryId = categoryId ?? 1;

            var activeGuarantors = await this.context.Guarantor.Where(x => x.IsActive).AsNoTracking().Select(x => x.GuarantorId).ToListAsync();

            var categoryGuarantorProductTaxes = categoryGuarantorProductTaxFunctions.GetData(x => !x.Edited && x.TipoImovel == residenceTypeId && x.CategoryId == categoryId && activeGuarantors.Contains(x.GuarantorId) && (!guarantorProductId.HasValue || guarantorProductId == x.GuarantorProductId) && (!price.HasValue || !x.MaxRentPrice.HasValue || (price <= x.MaxRentPrice)) && (!rentAndChargesPrice.HasValue || !x.MaxRentAndChargesPrice.HasValue || (rentAndChargesPrice <= x.MaxRentAndChargesPrice))).ToList();

            //var notResidenceType = residenceTypeFunctions.GetByExternalCode("NAORESIDENCIAL").ResidenceTypeId;

            //if (residenceTypeId == notResidenceType) //Caso seja não residencial, adiciona todos items não residenciais
            //{
            //    categoryGuarantorProductTaxes.AddRange(categoryGuarantorProductTaxFunctions.GetData(x => !x.Edited  && x.TipoImovel == notResidenceType && activeGuarantors.Contains(x.GuarantorId) && (!x.CategoryId.HasValue || x.CategoryId == categoryId) && (!guarantorProductId.HasValue || guarantorProductId == x.GuarantorProductId)));
            //}

            return await Task.Run(() => categoryGuarantorProductTaxes.Select(x => x.CategoryGuarantorProductTaxId));
        }
    }
}
