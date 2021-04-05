using DTO.Shared;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Web.ViewComponents.Report.Filter
{
    [ViewComponent(Name = "Report\\Filter")]
    public class StartAndEndYearViewComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync(int? startYear, int? endYear)
        {
            ViewBag.StartYear = startYear ?? DateTime.Now.Year;
            ViewBag.EndYear = endYear ?? DateTime.Now.Year;

            return await Task.Run(() => View("StartAndEndYear"));
        }
    }
}
