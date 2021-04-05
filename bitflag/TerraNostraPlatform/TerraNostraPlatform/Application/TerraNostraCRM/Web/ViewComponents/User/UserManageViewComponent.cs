using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.ViewComponents.User
{
    public class UserManageViewComponent : ViewComponent
    {
        public UserManageViewComponent(){ }

        public IViewComponentResult Invoke(DTO.User.UserViewModel model)
        {
            return View(model);
        }
    }
}
