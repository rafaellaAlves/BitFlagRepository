using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.ViewComponents.Indication
{
    public class IndicationIndexViewComponent : ViewComponent
    {
        public IndicationIndexViewComponent() { }

        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
