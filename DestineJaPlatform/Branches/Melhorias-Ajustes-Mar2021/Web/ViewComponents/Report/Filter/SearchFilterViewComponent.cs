using DTO.Shared;
using System;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.ViewComponents.Report.Filter
{
    [ViewComponent(Name = "Report\\Filter")]
    public class SearchFilterViewComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            return await Task.Run(() => View("Search"));
        }
    }
}
