using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.ViewComponents.Client
{
    public class ClientLogViewComponent : ViewComponent
    {
        public ClientLogViewComponent() { }

        public IViewComponentResult Invoke(DTO.Client.ClientLogDetalhadoViewModel model)
        {
            return View(model);
        }
    }
}
