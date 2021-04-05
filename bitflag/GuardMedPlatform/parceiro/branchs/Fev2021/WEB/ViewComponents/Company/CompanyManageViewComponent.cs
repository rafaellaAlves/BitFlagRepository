using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WEB.ViewComponents.Company
{
    public class CompanyManageViewComponent : ViewComponent
    {
        public CompanyManageViewComponent()
        {
        }

        public IViewComponentResult Invoke(Models.CompanyViewModel model)
        {
            return View(model);
        }
    }
}
