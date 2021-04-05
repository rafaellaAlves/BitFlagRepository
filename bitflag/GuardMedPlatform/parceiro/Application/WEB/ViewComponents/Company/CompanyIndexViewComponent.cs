using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WEB.ViewComponents.Company
{
    public class CompanyIndexViewComponent : ViewComponent
    {
        public CompanyIndexViewComponent()
        {
        }

        public IViewComponentResult Invoke(WEB.Models.CompanyViewModel model)
        {
            return View(model);
        }
    }
}
