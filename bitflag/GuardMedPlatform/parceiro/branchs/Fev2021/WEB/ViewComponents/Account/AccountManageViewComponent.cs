using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WEB.ViewComponents.Account
{
    public class AccountManageViewComponent : ViewComponent
    {
        public AccountManageViewComponent()
        {
        }

        public IViewComponentResult Invoke(Models.UserViewModel model)
        {
            return View(model);
        }
    }
}
