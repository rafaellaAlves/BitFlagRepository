using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WEB.ViewComponents.Plan
{
    public class FreePlanCoverageViewComponent : ViewComponent
    {
        public FreePlanCoverageViewComponent() { }

        public IViewComponentResult Invoke(WEB.Models.PlanViewModel plan)
        {
            return View(plan);
        }
    }
}
