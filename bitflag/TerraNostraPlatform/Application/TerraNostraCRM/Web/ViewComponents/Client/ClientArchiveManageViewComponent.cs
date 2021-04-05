using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.ViewComponents.Client
{
    public class ClientArchiveManageViewComponent : ViewComponent
    {
        public ClientArchiveManageViewComponent() { }

        public IViewComponentResult Invoke(int clientId)
        {
            return View(clientId);
        }
    }
}
