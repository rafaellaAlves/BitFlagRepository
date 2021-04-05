using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApplicationDbContext.Models;
using DTO.Recipient;
using Microsoft.AspNetCore.Mvc;
using Services.Shared;
using Microsoft.AspNetCore.Identity;
using AspNetIdentityDbContext;
using Services.Recipient;
using Web.Utils;
using DTO.Shared;
using Microsoft.AspNetCore.Authorization;

namespace Web.Controllers
{
    [Authorize(Roles = Constants.AllRolesExceptClient)]
    public class RecipientContactController : Shared.BaseCRUDController<RecipientContact, RecipientContactViewModel, int>
    {
        private readonly RecipientContactServices recipientContactServices;
        public RecipientContactController(RecipientContactServices service, UserManager<User> userManager) : base(service, userManager)
        {
            recipientContactServices = service;
        }

        [RequireRouteValues(new string[] { "recipientId" })]
        public async Task<IActionResult> List(DataTablesAjaxPostModel filter, int recipientId)
        {
            ListParameters.AddParameter("RecipientId", recipientId);

            return await base.List(filter);
        }
    }
}
