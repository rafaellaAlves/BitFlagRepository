using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WEB.ViewComponents.UserCompany
{
    public class UserCompanyManageViewComponent : ViewComponent
    {
        public UserCompanyManageViewComponent() { }

        public IViewComponentResult Invoke(Models.UserCompanyManageViewModel model)
        {
            return View(model);
        }

    }
}
