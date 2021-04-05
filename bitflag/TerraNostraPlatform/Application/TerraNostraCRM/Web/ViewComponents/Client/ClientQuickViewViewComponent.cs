using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.ViewComponents.Client
{
    public class ClientQuickViewViewComponent : ViewComponent
    {
        public ClientQuickViewViewComponent() { }

        public IViewComponentResult Invoke(DTO.Client.ClientViewModel model)
        {
            return View(model);
        }
    }
}
