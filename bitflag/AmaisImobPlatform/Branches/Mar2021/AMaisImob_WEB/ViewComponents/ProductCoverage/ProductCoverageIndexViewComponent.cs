using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AMaisImob_WEB.ViewComponents.ProductCoverage
{
    public class ProductCoverageIndexViewComponent : ViewComponent
    {
        public ProductCoverageIndexViewComponent() { }

        public IViewComponentResult Invoke(int productId)
        {
            return View(productId);
        }
    }
}
