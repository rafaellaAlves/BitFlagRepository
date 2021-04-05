using DTO.Utils;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Services.Account;
using Services.Client;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web.Utils;

namespace Web.ViewComponents.User
{
    public class UserIndexViewComponent : ViewComponent
    {
        UserService userService;
        ClientUserServices clientUserServices;
        UserManager<AspNetIdentityDbContext.User> userManager;
        ClientServices clientServices;
        public UserIndexViewComponent(UserService userService, ClientUserServices clientUserServices, UserManager<AspNetIdentityDbContext.User> userManager, ClientServices clientServices)
        {
            this.userService = userService;
            this.clientUserServices = clientUserServices;
            this.userManager = userManager;
            this.clientServices = clientServices;
        }
        public async Task<IViewComponentResult> InvokeAsync(string q, int? userType)
        {
            var users = await userService.ListUsers(q);

            if (User.Identity.IsAuthenticated && HttpContext.User.IsClient())
                users = await FilterByClient(users);

            if (userType.HasValue)
            {
                if (userType == (int)DTO.User.UserType.Client) users = users.Where(x => x.RoleName == "Cliente").ToList();
                if (userType == (int)DTO.User.UserType.Adminsitrator) users = users.Where(x => x.RoleName != "Cliente").ToList();
            }

            return await Task.Run(() => View(users));
        }

        private async Task<List<DTO.User.UserViewModel>> FilterByClient(List<DTO.User.UserViewModel> users)
        {
            var userId = (await userManager.GetUserAsync(HttpContext.User)).Id;

            var clientId = await clientServices.GetClientIdByLoggedUser(HttpContext);
            var client = await clientServices.GetDataByIdAsync(clientId);

            if (client == null) users = new List<DTO.User.UserViewModel>();

            var userIds = (await clientUserServices.GetDataAsNoTrackingAsync(x => x.ClientId == client.ClientId)).Select(x => x.UserId);

            users = users.Where(x => userIds.Contains(x.UserId ?? 0)).ToList();

            return users;
        }
    }
}