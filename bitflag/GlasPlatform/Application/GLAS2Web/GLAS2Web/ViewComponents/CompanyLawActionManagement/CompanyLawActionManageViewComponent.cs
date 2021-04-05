using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GLAS2Web.ViewComponents.CompanyLawActionManagement
{
    public class CompanyLawActionManageViewComponent : ViewComponent
    {
        public CompanyLawActionManageViewComponent()
        {
        }

        public IViewComponentResult Invoke(DTO.Company.CompanyLawActionViewModel model)
        {
            return View(model);
        }
    }
}
