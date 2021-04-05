using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AMaisImob_WEB.ViewComponents.Plan
{
    public class PlanManageViewComponent : ViewComponent
    {
        public PlanManageViewComponent() { }

        public IViewComponentResult Invoke(AMaisImob_WEB.Models.PlanViewModel model)
        {
            return View(model);
        }
    }
}
