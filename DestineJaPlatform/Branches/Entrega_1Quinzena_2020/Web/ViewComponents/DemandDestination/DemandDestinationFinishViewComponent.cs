using Microsoft.AspNetCore.Mvc;
using Services.DemandDestination;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.ViewComponents.DemandDestination
{
    public class DemandDestinationFinishViewComponent : ViewComponent
    {
        private readonly DemandDestinationServices demandDestinationServices;

        public DemandDestinationFinishViewComponent(DemandDestinationServices demandDestinationServices)
        {
            this.demandDestinationServices = demandDestinationServices;
        }

        public async Task<IViewComponentResult> InvokeAsync(int demandDestinationId) => await Task.Run(async () => View(await demandDestinationServices.GetViewModelByIdAsync(demandDestinationId)));
    }
}
