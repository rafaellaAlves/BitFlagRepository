using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WEB.ViewComponents.ProductCoverage
{
    public class ProductCoverageManageViewComponent : ViewComponent
    {
        public ProductCoverageManageViewComponent() { }

        public IViewComponentResult Invoke(Models.ProductCoverageViewModel model)
        {
            return View(model);
        }
    }
}
