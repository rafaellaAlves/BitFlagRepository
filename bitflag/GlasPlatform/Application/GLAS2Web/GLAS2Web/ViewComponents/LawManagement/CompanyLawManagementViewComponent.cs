using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GLAS2Web.ViewComponents.LawManagement
{
    public class CompanyLawManagementViewComponent : ViewComponent
    {
        public CompanyLawManagementViewComponent()
        {
        }

        public IViewComponentResult Invoke(DTO.Company.CompanyLawViewModel model)
        {
            return View(model);
        }
    }
}
