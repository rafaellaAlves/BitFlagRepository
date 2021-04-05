using DTO.Route;
using Microsoft.AspNetCore.Mvc;
using Services.Route;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.ViewComponents.Route
{
    public class RouteClientViewComponent : ViewComponent
    {
        private readonly RouteClientListServices routeClientListServices;
        private readonly RouteServices routeServices;

        public RouteClientViewComponent(RouteClientListServices routeClientListServices, RouteServices routeServices)
        {
            this.routeClientListServices = routeClientListServices;
            this.routeServices = routeServices;
        }

        public async Task<IViewComponentResult> InvokeAsync(int? routeId) => await Task.Run(async() => View(new RouteClientParametersViewModel(await routeClientListServices.GetViewModelAsNoTrackingAsync(x => x.RouteId == routeId), routeId.HasValue? await routeServices.GetViewModelByIdAsync(routeId.Value) : new RouteViewModel())));
    }
}
