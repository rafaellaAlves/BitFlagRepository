using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AMaisImob_WEB.ViewComponents.Guarantor
{
    public class GuarantorIndexViewComponent : ViewComponent
    {
        public GuarantorIndexViewComponent() { }

        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
