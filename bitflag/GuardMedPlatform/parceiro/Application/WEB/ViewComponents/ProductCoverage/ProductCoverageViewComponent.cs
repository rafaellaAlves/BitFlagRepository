using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WEB.ViewComponents.ProductCoverage
{
    public class ProductCoverageViewComponent : ViewComponent
    {
        public ProductCoverageViewComponent() { }

        public IViewComponentResult Invoke(int? productId)
        {
            return View(productId);
        }
    }
}
