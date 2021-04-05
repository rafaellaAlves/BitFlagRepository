using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AMaisImob_WEB.ViewComponents.Guarantor
{
    public class GuarantorManageViewComponent : ViewComponent
    {
        public GuarantorManageViewComponent() { }

        public IViewComponentResult Invoke(Models.GuarantorViewModel model)
        {
            return View(model);
        }
    }
}
