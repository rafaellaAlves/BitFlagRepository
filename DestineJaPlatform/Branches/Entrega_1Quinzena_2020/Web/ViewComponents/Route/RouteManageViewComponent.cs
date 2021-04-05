using DTO.Route;
using Microsoft.AspNetCore.Mvc;
using Services.Route;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.ViewComponents.Route
{
    public class RouteManageViewComponent : ViewComponent
    {
        private readonly RouteServices service;

        public RouteManageViewComponent(RouteServices service)
        {
            this.service = service;
        }

        public async Task<IViewComponentResult> InvokeAsync(int? id) => await Task.Run(async () => View(id.HasValue ? await service.GetViewModelByIdAsync(id.Value) : new RouteViewModel()));
    }
}
