using FUNCTIONS.Client;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.ViewComponents.User
{
    public class UserCalendarViewComponent : ViewComponent
    {
        private UserManager<TerraNostraIdentityDbContext.User> userManager;
        private RoleManager<TerraNostraIdentityDbContext.Role> roleManager;
        private ClientCalendarFunctions clientCalendar;
        public UserCalendarViewComponent(UserManager<TerraNostraIdentityDbContext.User> userManager, RoleManager<TerraNostraIdentityDbContext.Role> roleManager, ClientCalendarFunctions clientCalendar)
        {
            this.userManager = userManager;
            this.roleManager = roleManager;
            this.clientCalendar = clientCalendar;
        }

        public async Task<IViewComponentResult> InvokeAsync(DateTime? startDate, DateTime? endDate)
        {
            var user = await userManager.FindByNameAsync(User.Identity.Name);
            var roles = await userManager.GetRolesAsync(user);

            var roleName = roles.First();
            var role = await roleManager.FindByNameAsync(roleName);

            int? responsibleId = User.IsInRole("Salesman") ? (int?)user.Id : null;
            var model = clientCalendar.GetByResponsibleId(responsibleId, startDate, endDate).OrderByDescending(x => x.TaskDate).ToList();

            return View(model);
        }
    }
}
