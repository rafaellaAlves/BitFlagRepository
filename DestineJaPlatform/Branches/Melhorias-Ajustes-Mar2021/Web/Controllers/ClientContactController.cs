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
using Microsoft.AspNetCore.Authorization;
using DTO.Shared;

namespace Web.Controllers
{
    [Authorize(Roles = Constants.AllRolesExceptClient)]
    public class ClientContactController : Shared.BaseCRUDController<ClientContact, ClientContactViewModel, int>
    {
        private readonly ClientContactListServices clientContactListServices;
        private readonly ClientContactServices clientContactServices;

        public ClientContactController(ClientContactServices service, UserManager<User> userManager, ClientContactListServices clientContactListServices) : base(service, userManager)
        {
            this.clientContactListServices = clientContactListServices;
            this.clientContactServices = service;
        }

        [RequireRouteValues(new string[] { "clientId" })]
        public async Task<IActionResult> List(DTO.Shared.DataTablesAjaxPostModel filter, int clientId)
        {
            this.ListParameters.AddParameter("IsDeleted", false);
            this.ListParameters.AddParameter("ClientId", clientId);

            return await base.AlternativeList(filter, (filter, recordsTotal, recordsFiltered, query, parameters) => clientContactListServices.GetDataFiltered(filter, out recordsTotal, out recordsFiltered, query, parameters));
        }

        public async Task<IActionResult> ExistMainContact(int clientId, int? clientContactId) => await Task.Run(async () => Json(await clientContactServices.ExistMainContact(clientId, clientContactId)));

    }
}