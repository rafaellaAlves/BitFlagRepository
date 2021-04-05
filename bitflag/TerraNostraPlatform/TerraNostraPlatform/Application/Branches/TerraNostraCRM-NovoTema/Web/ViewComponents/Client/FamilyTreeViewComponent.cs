using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.ViewComponents.Client
{
    public class FamilyTreeViewComponent : ViewComponent
    {
        public FamilyTreeViewComponent() { }

        public IViewComponentResult Invoke(int clientId)
        {
            return View(clientId);
        }
    }
}
