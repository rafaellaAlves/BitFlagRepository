using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GLAS2Web.ViewComponents.LawManagement
{
    public class CompanyLawListViewComponent : ViewComponent
    {
        public CompanyLawListViewComponent()
        {
        }

        public IViewComponentResult Invoke(int? companyId)
        {
            return View(companyId);
        }
    }
}
