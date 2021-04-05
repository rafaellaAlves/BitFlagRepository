using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WEB.ViewComponents.InsurancePolicy
{
    public class InsurancePolicyManageViewComponent : ViewComponent
    {
        public InsurancePolicyManageViewComponent() { }

        public IViewComponentResult Invoke(WEB.Models.InsurancePolicyViewModel model)
        {
            return View(model);
        }
    }
}
