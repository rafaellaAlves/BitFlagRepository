using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AMaisImob_WEB.ViewComponents.CategoryGuarantorProduct
{
    
    public class CategoryGuarantorProductManageViewComponent : ViewComponent
    {

        public CategoryGuarantorProductManageViewComponent() { }

        public IViewComponentResult Invoke(Models.CategoryGuarantorProductTaxViewModel model)
        {
            return View(model);
        }

    }
}
