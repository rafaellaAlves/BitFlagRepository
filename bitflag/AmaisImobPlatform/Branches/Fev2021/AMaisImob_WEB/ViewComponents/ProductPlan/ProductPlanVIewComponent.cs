using AMaisImob_WEB.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AMaisImob_WEB.ViewComponents.ProductPlan
{
    public class ProductPlanVIewComponent : ViewComponent
    {
        public ProductPlanVIewComponent() { }

        public IViewComponentResult Invoke(ProductPlanManageViewModel model)
        {
            return View(model);
        }
    }
}
