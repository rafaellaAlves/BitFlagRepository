using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WEB.ViewComponents.InsurancePolicy
{
    public class InsurancePolicyIndexViewComponent : ViewComponent
    {
        public InsurancePolicyIndexViewComponent() { }

        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
