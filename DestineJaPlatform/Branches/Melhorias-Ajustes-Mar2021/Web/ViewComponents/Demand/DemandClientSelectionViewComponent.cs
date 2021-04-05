using ApplicationDbContext.Models;
using DTO.Demand;
using DTO.Shared;
using Microsoft.AspNetCore.Mvc;
using Services.Residue;
using Services.Route;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.ViewComponents.Demand
{
    public class DemandClientSelectionViewComponent : ViewComponent
    {
        private readonly RouteServices routeServices;
        private readonly ResidueFamilyListService residueFamilyListService;

        public DemandClientSelectionViewComponent(RouteServices routeServices, ResidueFamilyListService residueFamilyListService)
        {
            this.routeServices = routeServices;
            this.residueFamilyListService = residueFamilyListService;
        }

        public async Task<IViewComponentResult> InvokeAsync(int routeId, bool loadFromController = false) => await Task.Run(async () => View(new EntityViewMode<DemandClientSelectionViewModel>(ViewMode.Editable, new DemandClientSelectionViewModel(await routeServices.GetViewModelByIdAsync(routeId), residueFamilyListService.ToViewModel(await routeServices.GetResidueFamiliesByRouteId(routeId))), loadFromController)));
    }
}
