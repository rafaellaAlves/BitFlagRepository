using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WEB.ViewComponents.Assistance
{
    public class ProductAssistanceViewComponent : ViewComponent
    {
        public ProductAssistanceViewComponent() { }

        public IViewComponentResult Invoke(Models.ProductAssistanceManageViewModel model)
        {
            return View(model);
        }
    }
}
