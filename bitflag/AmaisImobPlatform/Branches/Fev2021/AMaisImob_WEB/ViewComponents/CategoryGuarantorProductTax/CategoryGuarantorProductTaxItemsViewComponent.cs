using AMaisImob_WEB.Utils;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AMaisImob_WEB.ViewComponents.CategoryGuarantorProductTax
{
    public class CategoryGuarantorProductTaxItemsViewComponent : ViewComponent
    {
        private readonly AMaisImob_WEB.BLL.CategoryGuarantorProductTaxFunctions categoryGuarantorProductTaxFunctions;
        private readonly AMaisImob_WEB.BLL.ResidenceTypeFunctions residenceTypeFunctions;
        private readonly AMaisImob_WEB.BLL.CompanyFunctions companyFunctions;
        private readonly AMaisImob_WEB.BLL.CertificateContractualFunctions certificateContractualFunctions;

        public CategoryGuarantorProductTaxItemsViewComponent(AMaisImob_WEB.BLL.CategoryGuarantorProductTaxFunctions categoryGuarantorProductTaxFunctions, BLL.ResidenceTypeFunctions residenceTypeFunctions, BLL.CertificateContractualFunctions certificateContractualFunctions, BLL.CompanyFunctions companyFunctions)
        {
            this.categoryGuarantorProductTaxFunctions = categoryGuarantorProductTaxFunctions;
            this.residenceTypeFunctions = residenceTypeFunctions;
            this.certificateContractualFunctions = certificateContractualFunctions;
            this.companyFunctions = companyFunctions;
        }

        //public async Task<IViewComponentResult> InvokeAsync(int? categoryId, string price, int? residenceTypeId, int? guarantorProductId)
        //{
        //    categoryId = categoryId ?? 1;

        //    ViewData["Price"] = price.FromDoublePtBR();

        //    var categoryGuarantorProductTaxes = categoryGuarantorProductTaxFunctions.GetDataViewModel(categoryGuarantorProductTaxFunctions.GetData(x => x.CategoryId == categoryId && (!guarantorProductId.HasValue || guarantorProductId == x.GuarantorProductId)));

        //    var notResidenceType = residenceTypeFunctions.GetByExternalCode("NAORESIDENCIAL").ResidenceTypeId;

        //    if(residenceTypeId == notResidenceType) //Caso seja não residencial, adiciona todos items não residenciais
        //    {
        //        categoryGuarantorProductTaxes.AddRange(categoryGuarantorProductTaxFunctions.GetDataViewModel(categoryGuarantorProductTaxFunctions.GetData(x => x.TipoImovel == notResidenceType && (!x.CategoryId.HasValue || x.CategoryId == categoryId) && (!guarantorProductId.HasValue || guarantorProductId == x.GuarantorProductId))));
        //    }

        //    return await Task.Run(() => View(categoryGuarantorProductTaxes));
        //}

        public async Task<IViewComponentResult> InvokeAsync(IEnumerable<int> ids, int? certificateContractualId, string price)
        {
            if (string.IsNullOrWhiteSpace(price))
            {
                var certificateContractual = certificateContractualFunctions.GetDataByID(certificateContractualId);
                var realEstate = companyFunctions.GetDataByID(certificateContractual.RealEstateId);

                ViewData["Price"] = certificateContractual.Aluguel;
            }
            else
            {
                ViewData["Price"] = price.FromDoublePtBR();
            }

            var categoryGuarantorProductTaxes = categoryGuarantorProductTaxFunctions.GetDataViewModel(categoryGuarantorProductTaxFunctions.GetData(x => ids.Contains(x.CategoryGuarantorProductTaxId)));

            return await Task.Run(() => View(categoryGuarantorProductTaxes));
        }
    }
}
