using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApplicationDbContext.Models;
using DTO.Client;
using Microsoft.AspNetCore.Mvc;
using Services.Shared;
using Microsoft.AspNetCore.Identity;
using AspNetIdentityDbContext;
using Services.Client;
using Web.Utils;
using DTO.Shared;
using Microsoft.AspNetCore.Authorization;

namespace Web.Controllers
{
    [Authorize(Roles = Constants.AllRolesExceptClient)]
    public class ClientCollectionAddressController : Shared.BaseCRUDController<ClientCollectionAddress, ClientCollectionAddressViewModel, int>
    {
        private readonly ClientCollectionAddressServices clientCollectionAddressServices;

        public ClientCollectionAddressController(ClientCollectionAddressServices service, UserManager<User> userManager) : base(service, userManager)
        {
            clientCollectionAddressServices = service;
        }

        [RequireRouteValues(new string[] { "clientId" })]
        public async Task<IActionResult> List(DTO.Shared.DataTablesAjaxPostModel filter, int clientId)
        {
            this.ListParameters.AddParameter("IsDeleted", false);
            this.ListParameters.AddParameter("ClientId", clientId);

            return await base.List(filter);
        }
        public async Task<IActionResult> LoadIndexComponent(int clientId, ViewMode viewMode) => await Task.Run(() => ViewComponent(typeof(ViewComponents.Client.ClientCollectionAddressIndexViewComponent), new { clientId, viewMode, loadFromController = true }));

        public async Task<IActionResult> ExistMainAddress(int clientId, int? clientCollectionAddressId) => await Task.Run(async () => Json(await clientCollectionAddressServices.ExistMainAddress(clientId, clientCollectionAddressId)));

        public override async Task<IActionResult> ManageAjax(ClientCollectionAddressViewModel model)
        {
            if (model.Main) await clientCollectionAddressServices.RemoveMainAddressFromClient(model.ClientId);

            return await base.ManageAjax(model);
        }
    }
}