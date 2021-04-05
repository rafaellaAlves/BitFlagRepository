using DTO.Demand;
using DTO.Shared;
using Microsoft.AspNetCore.Mvc;
using Services.Demand;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.ViewComponents.Demand
{
    public class DemandClientManageViewComponent : ViewComponent
    {
        private readonly DemandClientServices demandClientServices;

        public DemandClientManageViewComponent(DemandClientServices demandClientServices)
        {
            this.demandClientServices = demandClientServices;
        }

        public async Task<IViewComponentResult> InvokeAsync(int demandClientId, ViewMode viewMode = ViewMode.Editable, bool loadFromController = false) => await Task.Run(async () => View(new EntityViewMode<DemandClientViewModel>(viewMode, await demandClientServices.GetViewModelByIdAsync(demandClientId), loadFromController)));
    }
}
