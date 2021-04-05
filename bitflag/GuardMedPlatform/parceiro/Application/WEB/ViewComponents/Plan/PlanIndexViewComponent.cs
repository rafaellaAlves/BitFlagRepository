using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WEB.ViewComponents.Plan
{
    public class PlanIndexViewComponent : ViewComponent
    {
        public PlanIndexViewComponent() { }

        public IViewComponentResult Invoke(int? productId)
        {
            return View(productId);
        }
    }
}
