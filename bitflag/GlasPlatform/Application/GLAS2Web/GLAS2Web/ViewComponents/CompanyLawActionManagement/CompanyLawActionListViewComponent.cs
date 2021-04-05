using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GLAS2Web.ViewComponents.CompanyLawActionManagement
{
    public class CompanyLawActionListViewComponent : ViewComponent
    {
        public CompanyLawActionListViewComponent()
        {
        }

        public IViewComponentResult Invoke(int? companyLawId)
        {
            return View(companyLawId);
        }
    }
}
