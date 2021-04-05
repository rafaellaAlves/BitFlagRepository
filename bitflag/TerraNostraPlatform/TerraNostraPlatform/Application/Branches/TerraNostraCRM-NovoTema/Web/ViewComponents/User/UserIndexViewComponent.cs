using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web.Utils;

namespace Web.ViewComponents.User
{
    public class UserIndexViewComponent : ViewComponent
    {
        public UserIndexViewComponent() { }

        public IViewComponentResult Invoke(List<Web.Utils.UserType> userTypes = null)
        {
            if (userTypes == null) userTypes = new List<UserType>();

            return View(userTypes);
        }
    }
}
