using DTO.Shared;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Web.ViewComponents.Report.Filter
{
    [ViewComponent(Name = "Report\\Filter")]
    public class OptionalStartAndEndDateViewComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync(DateTime? startDate, DateTime? endDate)
        {
            return await Task.Run(() => View("OptionalStartAndEndDate"));
        }
    }
}
