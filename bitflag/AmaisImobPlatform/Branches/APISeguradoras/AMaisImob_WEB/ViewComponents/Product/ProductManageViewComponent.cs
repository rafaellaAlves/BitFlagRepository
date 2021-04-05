using AMaisImob_WEB.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AMaisImob_WEB.ViewComponents.Product
{
    public class ProductManageViewComponent : ViewComponent
    {
        public ProductManageViewComponent() { }

        public IViewComponentResult Invoke(ProductViewModel model)
        {
            return View(model);
        }
    }
}
