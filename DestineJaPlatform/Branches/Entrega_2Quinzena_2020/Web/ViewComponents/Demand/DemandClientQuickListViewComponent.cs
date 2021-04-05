using Microsoft.AspNetCore.Mvc;
using Services.Demand;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.ViewComponents.Demand
{
    [ViewComponent(Name = "DemandClient")]
    public class DemandClientQuickListViewComponent : ViewComponent
    {
        private readonly DemandClientServices demandClientServices;

        public DemandClientQuickListViewComponent(DemandClientServices demandClientServices)
        {
            this.demandClientServices = demandClientServices;
        }

        public async Task<IViewComponentResult> InvokeAsync(int demandId) => await Task.Run(async () => View("QuickList", await demandClientServices.GetClientsByDemandId(demandId)));
    }
}
