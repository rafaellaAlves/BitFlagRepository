using Microsoft.AspNetCore.Mvc;
using Services.DemandDestination;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.ViewComponents.DemandDestination
{
    public class DemandDestinationMTRFileViewComponent : ViewComponent
    {
        private readonly DemandDestinationServices demandDestinationServices;

        public DemandDestinationMTRFileViewComponent(DemandDestinationServices demandDestinationServices)
        {
            this.demandDestinationServices = demandDestinationServices;
        }

        public async Task<IViewComponentResult> InvokeAsync(int demandDestinationId, int via) => await Task.Run(async () => View(await demandDestinationServices.GetDemandDestinationMTRFileViewModel(demandDestinationId, via)));
    }
}
