using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.ViewComponents.RegistryOffice
{
    public class RegistryOfficeIndexViewComponent : ViewComponent
    {
        public RegistryOfficeIndexViewComponent() 
        {
        }

        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
