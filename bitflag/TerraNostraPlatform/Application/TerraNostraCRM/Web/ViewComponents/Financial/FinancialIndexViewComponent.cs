using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.ViewComponents.Financial
{
        public class FinancialIndexViewComponent : ViewComponent
        {
            public IViewComponentResult Invoke()
            {
                return View();
            }
        }
}
