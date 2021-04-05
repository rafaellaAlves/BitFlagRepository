using Microsoft.AspNetCore.Mvc;
using Services.Demand;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.ViewComponents.Demand
{
    public class BlankMTRFileViewComponent : ViewComponent
    {
        private readonly DemandClientServices demandClientServices;

        public BlankMTRFileViewComponent(DemandClientServices demandClientServices)
        {
            this.demandClientServices = demandClientServices;
        }

        public async Task<IViewComponentResult> InvokeAsync(int id) => await Task.Run(async () => View(await demandClientServices.GetDemandMTRFileViewModel(id)));
    }
}
