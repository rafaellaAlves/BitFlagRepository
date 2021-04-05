using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.ViewComponents.ServiceType
{
    public class ServiceTypeManageViewComponent : ViewComponent
    {
        public ServiceTypeManageViewComponent() { }

        public IViewComponentResult Invoke(DTO.ServiceType.ServiceTypeViewModel model)
        {
            return View(model);
        }
    }
}
