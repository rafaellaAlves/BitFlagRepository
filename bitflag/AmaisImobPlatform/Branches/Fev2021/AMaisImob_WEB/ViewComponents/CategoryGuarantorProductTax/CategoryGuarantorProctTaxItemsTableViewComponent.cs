using AMaisImob_WEB.Utils;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AMaisImob_WEB.ViewComponents.CategoryGuarantorProductTax
{
    public class CategoryGuarantorProctTaxItemsTableViewComponent : ViewComponent
    {
        private readonly AMaisImob_WEB.BLL.CertificateContractualFunctions certificateContractualFunctions;
        private readonly AMaisImob_WEB.BLL.CategoryGuarantorProductTaxFunctions categoryGuarantorProductTaxFunctions;
        private readonly AMaisImob_WEB.BLL.ResidenceTypeFunctions residenceTypeFunctions;
        private readonly AMaisImob_WEB.BLL.CompanyFunctions companyFunctions;
        private readonly AMaisImob_WEB.BLL.CertificateContractualQuoteFunctions certificateContractualQuoteFunctions;

        public CategoryGuarantorProctTaxItemsTableViewComponent(AMaisImob_WEB.BLL.CategoryGuarantorProductTaxFunctions categoryGuarantorProductTaxFunctions, BLL.ResidenceTypeFunctions residenceTypeFunctions, BLL.CertificateContractualFunctions certificateContractualFunctions, BLL.CompanyFunctions companyFunctions, BLL.CertificateContractualQuoteFunctions certificateContractualQuoteFunctions)
        {
            this.categoryGuarantorProductTaxFunctions = categoryGuarantorProductTaxFunctions;
            this.residenceTypeFunctions = residenceTypeFunctions;
            this.certificateContractualFunctions = certificateContractualFunctions;
            this.companyFunctions = companyFunctions;
            this.certificateContractualQuoteFunctions = certificateContractualQuoteFunctions;
        }

        public async Task<IViewComponentResult> InvokeAsync(int certificateContractualId)
        {
            var certificateContractual = certificateContractualFunctions.GetDataByID(certificateContractualId);
            ViewData["Price"] = certificateContractual.Aluguel;

            //Obtem os ids das cotações existem no momento da criação deste certificado contratual
            var itemIds = certificateContractualQuoteFunctions.GetDataByCertificateContractualId(certificateContractualId).Select(x => x.CategoryGuarantorProductTaxId).ToList();

            var categoryGuarantorProductTaxes = categoryGuarantorProductTaxFunctions.GetDataViewModel(categoryGuarantorProductTaxFunctions.GetData(x => itemIds.Contains(x.CategoryGuarantorProductTaxId)));

            return await Task.Run(() => View(categoryGuarantorProductTaxes));
        }
    }
}
