using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.ViewComponents.Client
{
    public class ClientQuickManageViewComponent : ViewComponent
    {
        public ClientQuickManageViewComponent() { }

        public IViewComponentResult Invoke(DTO.Client.ClientViewModel model)
        {
            return View(model);
        }
    }
}
