using DTO.DemandDestination;
using DTO.Shared;
using Microsoft.AspNetCore.Mvc;
using Services.DemandDestination;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.ViewComponents.DemandDestination
{
    public class DemandDestinationManageViewComponent : ViewComponent
    {
        private readonly DemandDestinationServices demandDestinationService;

        public DemandDestinationManageViewComponent(DemandDestinationServices demandDestinationService)
        {
            this.demandDestinationService = demandDestinationService;
        }

        public async Task<IViewComponentResult> InvokeAsync(int? id, ViewMode viewMode) => await Task.Run(async () => View(new EntityViewMode<DemandDestinationViewModel>(viewMode, id.HasValue ? await demandDestinationService.GetViewModelByIdAsync(id.Value) : new DemandDestinationViewModel())));
    }
}
