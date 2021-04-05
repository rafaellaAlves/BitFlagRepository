using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.ViewComponents.Client
{
    public class ClientLogManageViewComponent : ViewComponent
    {
        public ClientLogManageViewComponent() { }

        public IViewComponentResult Invoke(DTO.Client.ClientLogViewModel model)
        {
            return View(model);
        }
    }
}
