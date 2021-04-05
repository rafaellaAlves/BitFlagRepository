using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AMaisImob_WEB.ViewComponents.PlanAssistance
{
    public class PlanAssistanceViewComponent : ViewComponent
    {
        public PlanAssistanceViewComponent() { }

        public IViewComponentResult Invoke(AMaisImob_DB.Models.Plan model)
        {
            return View(model);
        }
    }
}
