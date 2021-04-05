using Microsoft.AspNetCore.Mvc;
using Services.Demand;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.ViewComponents.Demand
{
    public class DemandClientCloseViewComponent : ViewComponent
    {
        private readonly DemandClientListServices demandClientListServices;

        public DemandClientCloseViewComponent(DemandClientListServices demandClientListServices)
        {
            this.demandClientListServices = demandClientListServices;
        }

        public async Task<IViewComponentResult> InvokeAsync(int demandId) => await Task.Run(async() => View(await demandClientListServices.GetViewModelAsNoTrackingAsync(x => x.DemandId == demandId)));
    }
}
