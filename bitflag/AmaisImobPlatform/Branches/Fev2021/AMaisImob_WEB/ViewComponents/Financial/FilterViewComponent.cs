using AMaisImob_WEB.BLL;
using AMaisImob_WEB.Models.Charge;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AMaisImob_WEB.ViewComponents.Financial
{
    [ViewComponent(Name = "Financial")]
    public class FilterViewComponent : ViewComponent
    {
        private readonly CompanyFunctions companyFunctions;

        public FilterViewComponent(CompanyFunctions companyFunctions)
        {
            this.companyFunctions = companyFunctions;
        }

        public async Task<IViewComponentResult> InvokeAsync(DateTime? referenceDate = null, int? realEstateId = null, bool? chargeContractualGuarantee = null)
        {
            int? realEstateAgencyId = null;
            if (realEstateId.HasValue)
            {
                var realEstate = companyFunctions.GetDataByID(realEstateId);
                realEstateAgencyId = realEstate.ParentCompanyId;
            }

            return await Task.Run(() => View("Filter", new FinancialFilterViewModel { ReferenceDate = referenceDate, RealEstateId = realEstateId, RealEstateAgencyId = realEstateAgencyId, ChargeContractualGuarantee = chargeContractualGuarantee }));
        }
    }
}
