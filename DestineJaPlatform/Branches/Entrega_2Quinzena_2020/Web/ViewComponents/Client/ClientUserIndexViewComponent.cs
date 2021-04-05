using DTO.Client;
using DTO.Shared;
using Microsoft.AspNetCore.Mvc;
using Services.Account;
using Services.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.ViewComponents.Client
{
    public class ClientUserIndexViewComponent : ViewComponent
    {
        private readonly ClientUserServices clientUserServices;
        private readonly UserService userService;

        public ClientUserIndexViewComponent(ClientUserServices clientUserServices, UserService userService)
        {
            this.clientUserServices = clientUserServices;
            this.userService = userService;
        }

        public async Task<IViewComponentResult> InvokeAsync(int clientId, bool loadFromController = false)
        {
            var userIds = (await clientUserServices.GetDataAsNoTrackingAsync(x => x.ClientId == clientId)).Select(x => x.UserId);

            return await Task.Run(async () => View(new EntityViewMode<ClientUserListViewModel>(ViewMode.Editable, new ClientUserListViewModel
            {
                ClientId = clientId,
                Users = (await userService.ListUsers()).Where(x => userIds.Contains(x.UserId ?? 0)).ToList()
            }, loadFromController)));
        }

    }
}
