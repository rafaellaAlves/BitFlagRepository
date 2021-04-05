using DTO.Shared;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.ViewComponents.Report.Filter
{

    [ViewComponent(Name = "Report\\Filter")]
    public class UnitOfMeasurementViewComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync() => await Task.Run(() => View("UnitOfMeasurement"));
    }
}
