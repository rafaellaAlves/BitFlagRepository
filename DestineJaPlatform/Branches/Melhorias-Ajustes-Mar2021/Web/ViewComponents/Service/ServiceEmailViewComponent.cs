using Microsoft.AspNetCore.Mvc;
using Services.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.ViewComponents.Service
{
    public class ServiceEmailViewComponent : ViewComponent
    {
        private readonly ServiceServices serviceServices;

        public ServiceEmailViewComponent(ServiceServices serviceServices)
        {
            this.serviceServices = serviceServices;
        }

        public async Task<IViewComponentResult> InvokeAsync(int id) => await Task.Run(async () => View(await serviceServices.GetViewModelByIdAsync(id)));
    }
}
