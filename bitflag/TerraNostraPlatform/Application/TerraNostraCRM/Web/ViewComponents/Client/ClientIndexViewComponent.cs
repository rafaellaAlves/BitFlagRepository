using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web.Utils;

namespace Web.ViewComponents.Client
{
    public class ClientIndexViewComponent : ViewComponent
    {
        public ClientIndexViewComponent() { }

        public IViewComponentResult Invoke(ViewComponentType type)
        {
            return View(type);
        }
    }
}
