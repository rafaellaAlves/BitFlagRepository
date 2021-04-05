using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WEB.ViewComponents.Assistance
{
    public class AssistanceIndexViewComponent : ViewComponent
    {
        public AssistanceIndexViewComponent() { }

        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
