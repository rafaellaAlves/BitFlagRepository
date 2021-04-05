using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WEB.ViewComponents.Assistance
{
    public class AssistanceManageViewComponent : ViewComponent
    {
        public AssistanceManageViewComponent() { }

        public IViewComponentResult Invoke(Models.AssistanceViewModel model)
        {
            return View(model);
        }
    }
}
