using DTO.Shared;
using Microsoft.AspNetCore.Mvc;
using Services.Demand;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.ViewComponents.Demand
{
    public class DemandManageViewComponent : ViewComponent
    {
        private readonly DemandServices demandServices;

        public DemandManageViewComponent(DemandServices demandServices)
        {
            this.demandServices = demandServices;
        }

        public async Task<IViewComponentResult> InvokeAsync(int? id, ViewMode viewMode) => await Task.Run(async () => View(new EntityViewMode<DTO.Demand.DemandViewModel>(viewMode, id.HasValue ? await demandServices.GetViewModelByIdAsync(id.Value) : new DTO.Demand.DemandViewModel(), false)));
    }
}
