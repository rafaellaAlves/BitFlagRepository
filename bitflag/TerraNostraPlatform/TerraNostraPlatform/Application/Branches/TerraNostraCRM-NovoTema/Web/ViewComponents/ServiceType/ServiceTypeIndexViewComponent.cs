using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.ViewComponents.ServiceType
{
    public class ServiceTypeIndexViewComponent : ViewComponent
    {
        public ServiceTypeIndexViewComponent() { }

        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
