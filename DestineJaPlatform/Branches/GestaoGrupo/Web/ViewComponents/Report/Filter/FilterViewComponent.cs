using DTO.Shared;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web.Models;

namespace Web.ViewComponents.Report.Filter
{

    [ViewComponent(Name = "Report\\Filter")]
    public class FilterViewComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync(List<ReportFilterModel> filters) => await Task.Run(() => View(filters));
    }
}
