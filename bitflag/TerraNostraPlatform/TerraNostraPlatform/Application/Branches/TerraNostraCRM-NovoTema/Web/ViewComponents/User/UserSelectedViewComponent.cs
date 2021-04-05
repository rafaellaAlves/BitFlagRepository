using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.ViewComponents.User
{
    public class UserSelectedViewComponent : ViewComponent
    {
        public UserSelectedViewComponent() { }

        public IViewComponentResult Invoke(List<Web.Utils.UserType> userTypes = null)
        {
            if (userTypes == null) userTypes = new List<Utils.UserType>();

            return View(userTypes);
        }
    }
}
