using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AMaisImob_WEB.ViewComponents.UserCompany
{
    public class UserCompanyIndexViewComponent : ViewComponent
    {
        public UserCompanyIndexViewComponent()
        {
        }

        public IViewComponentResult Invoke(int companyId)
        {
            return View(companyId);
        }
    }
}
