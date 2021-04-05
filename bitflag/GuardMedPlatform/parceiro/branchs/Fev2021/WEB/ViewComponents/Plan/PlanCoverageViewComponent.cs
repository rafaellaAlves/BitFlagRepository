using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WEB.ViewComponents.Plan
{
    public class PlanCoverageViewComponent : ViewComponent
    {
        public PlanCoverageViewComponent() { }

        public IViewComponentResult Invoke(WEB.Models.PlanViewModel plan)
        {
            return View(plan);
        }
    }
}
