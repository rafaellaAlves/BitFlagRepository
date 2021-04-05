using Microsoft.AspNetCore.Mvc;
using Services.Account;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.ViewComponents.User
{
    public class UserManageViewComponent : ViewComponent
    {
        UserService userService;
        public UserManageViewComponent(UserService userService)
        {
            this.userService = userService;
        }
        public async Task<IViewComponentResult> InvokeAsync(int? id, bool loadFromController = false)
        {
            ViewBag.LoadFromController = loadFromController;

            DTO.User.UserViewModel model = id.HasValue ? await userService.GetUser(id.Value) : new DTO.User.UserViewModel();

            return await Task.Run(() => View(model));
        }
    }
}
