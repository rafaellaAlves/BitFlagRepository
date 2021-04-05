using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApplicationDbContext.Models;
using DTO.Transporter;
using Microsoft.AspNetCore.Mvc;
using Services.Shared;
using Microsoft.AspNetCore.Identity;
using AspNetIdentityDbContext;
using Services.Transporter;
using Web.Utils;
using DTO.Shared;
using Microsoft.AspNetCore.Authorization;

namespace Web.Controllers
{
    [Authorize(Roles = Constants.AllRolesExceptClient)]
    public class TransporterContactController : Shared.BaseCRUDController<TransporterContact, TransporterContactViewModel, int>
    {
        private readonly TransporterContactServices transporterContactServices;
        public TransporterContactController(TransporterContactServices service, UserManager<User> userManager) : base(service, userManager)
        {
            transporterContactServices = service;
        }
        
        [RequireRouteValues(new string[] { "transporterId" })]
        public async Task<IActionResult> List(DataTablesAjaxPostModel filter, int transporterId)
        {
            ListParameters.AddParameter("TransporterId", transporterId);

            return await base.List(filter);
        }
    }
}
