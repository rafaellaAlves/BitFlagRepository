using DTO.Shared;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Web.ViewComponents.Report.Filter
{
    [ViewComponent(Name = "Report\\Filter")]
    public class MonthViewComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync(DateTime? date)
        {
            ViewBag.Date = date ?? new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);

            return await Task.Run(() => View("Month"));
        }
    }
}
