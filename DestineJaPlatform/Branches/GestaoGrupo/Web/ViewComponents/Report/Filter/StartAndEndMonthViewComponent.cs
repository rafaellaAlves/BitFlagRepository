using DTO.Shared;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Web.ViewComponents.Report.Filter
{
    [ViewComponent(Name = "Report\\Filter")]
    public class StartAndEndMonthViewComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync(DateTime? startDate, DateTime? endDate)
        {
            ViewBag.StartDate = startDate ?? new DateTime(DateTime.Now.AddMonths(-12).Year, DateTime.Now.AddMonths(-12).Month, 1);
            ViewBag.EndDate = endDate ?? new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);

            return await Task.Run(() => View("StartAndEndMonth"));
        }
    }
}
