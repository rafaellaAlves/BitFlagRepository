using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AMaisImob_WEB.ViewComponents.Company
{
    public class CompanyIndexViewComponent : ViewComponent
    {
        public CompanyIndexViewComponent()
        {
        }

        public IViewComponentResult Invoke(AMaisImob_WEB.Models.CompanyViewModel model)
        {
            return View(model);
        }
    }
}
