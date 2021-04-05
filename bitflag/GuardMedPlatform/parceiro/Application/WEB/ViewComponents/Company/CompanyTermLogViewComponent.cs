using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WEB.ViewComponents.Company
{
    public class CompanyTermLogViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke(int companyId)
        {
            return View(companyId);
        }

    }
}
