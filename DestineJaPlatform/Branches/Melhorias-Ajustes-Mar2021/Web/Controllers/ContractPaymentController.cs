using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApplicationDbContext.Models;
using DTO.Contract;
using Microsoft.AspNetCore.Mvc;
using Services.Shared;
using Microsoft.AspNetCore.Identity;
using AspNetIdentityDbContext;
using Services.Contract;
using Microsoft.AspNetCore.Authorization;
using DTO.Shared;

namespace Web.Controllers
{
    [Authorize(Roles = Constants.AllRolesExceptClient)]
    public class ContractPaymentController : Shared.BaseCRUDController<ContractPayment, ContractPaymentViewModel, int>
    {
        public ContractPaymentController(ContractPaymentServices service, UserManager<User> userManager) : base(service, userManager)
        {
        }

        public async Task<IActionResult> Index(int contractId) => await Task.Run(() => View());
    }
}