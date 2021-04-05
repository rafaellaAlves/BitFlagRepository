using AMaisImob_WEB.Models.Charge;
using AMaisImob_WEB.Models.Shared;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AMaisImob_WEB.ViewComponents.Financial
{
    [ViewComponent(Name = "Financial")]
    public class ChargeAnalyseViewComponent : ViewComponent
    {
        private readonly BLL.FinancialFunctions financialFunctions;
        private readonly BLL.CompanyFunctions companyFunctions;
        private readonly BLL.ChargeFunctions chargeFunctions;

        public ChargeAnalyseViewComponent(BLL.FinancialFunctions financialFunctions, BLL.CompanyFunctions companyFunctions, BLL.ChargeFunctions chargeFunctions)
        {
            this.financialFunctions = financialFunctions;
            this.companyFunctions = companyFunctions;
            this.chargeFunctions = chargeFunctions;
        }

        public async Task<IViewComponentResult> InvokeAsync(DateTime? referenceDate, int? companyId, int? chargeId, bool cutScript = true)
        {
            if (chargeId.HasValue)
            {
                var charge = chargeFunctions.GetDataByID(chargeId);
                referenceDate = charge.ReferenceDate;
                companyId = charge.RealEstateId;
            }

            return await Task.Run(async () => View("ChargeAnalyse", new BaseViewModel<ChargeAnalyseViewModel>(new ChargeAnalyseViewModel(await financialFunctions.GetValuesForCharge(companyId, referenceDate.Value), companyFunctions.GetDataViewModel(companyFunctions.GetDataByID(companyId)), referenceDate.Value, chargeId), cutScript)));
        }
    }
}
