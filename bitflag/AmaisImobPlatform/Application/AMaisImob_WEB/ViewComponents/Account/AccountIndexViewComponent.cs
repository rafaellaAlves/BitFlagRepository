using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AMaisImob_WEB.ViewComponents.Account
{
    public class AccountIndexViewComponent : ViewComponent
    {
        public AccountIndexViewComponent()
        {
        }

        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
