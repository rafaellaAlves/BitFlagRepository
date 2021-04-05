using DTO.Service;
using Microsoft.AspNetCore.Mvc;
using Services.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.ViewComponents.Service
{
    public class ServiceManageViewComponent : ViewComponent
    {
        private readonly ServiceServices service;

        public ServiceManageViewComponent(ServiceServices service)
        {
            this.service = service;
        }

        public async Task<IViewComponentResult> InvokeAsync(int? id) => await Task.Run(async () => View(id.HasValue ? await service.GetViewModelByIdAsync(id.Value) : new ServiceViewModel()));
    }
}
