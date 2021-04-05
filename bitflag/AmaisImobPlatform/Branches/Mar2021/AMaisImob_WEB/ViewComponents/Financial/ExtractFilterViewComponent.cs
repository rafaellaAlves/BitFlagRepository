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
    public class ExtractFilterViewComponent : ViewComponent
    {
        private readonly CompanyFunctions companyFunctions;

        public ExtractFilterViewComponent(CompanyFunctions companyFunctions)
        {
            this.companyFunctions = companyFunctions;
        }

        public async Task<IViewComponentResult> InvokeAsync(DateTime? startDate = null, DateTime? endDate = null)
        {
            if (!endDate.HasValue)
                endDate = startDate;

            return await Task.Run(() => View("ExtractFilter", new FinancialFilterViewModel { StartDate = startDate, EndDate = endDate }));
        }
    }
}
