using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApplicationDbContext.Models;
using DTO.Residue;
using Microsoft.AspNetCore.Mvc;
using Services.Shared;
using Microsoft.AspNetCore.Identity;
using AspNetIdentityDbContext;
using Services.Residue;
using DTO.Shared;
using Microsoft.AspNetCore.Authorization;

namespace Web.Controllers
{
    [Authorize(Roles = Constants.AllRolesExceptClient)]
    public class ResidueFamilyController : Shared.BaseCRUDController<ResidueFamily, ResidueFamilyViewModel, int>
    {
        private readonly ResidueFamilyListService residueFamilyListService;
        private readonly ResidueServices residueServices;
        public ResidueFamilyController(ResidueFamilyServices service, UserManager<User> userManager, ResidueFamilyListService residueFamilyListService, ResidueServices residueServices) : base(service, userManager)
        {
            this.residueFamilyListService = residueFamilyListService;
            this.residueServices = residueServices;
        }

        public override Task<IActionResult> ManageForm(ResidueFamilyViewModel model)
        {
            model.AcceptDifferentFamilies = true;

            return base.ManageForm(model);
        }

        public override Task<IActionResult> ManageAjax(ResidueFamilyViewModel model)
        {
            model.AcceptDifferentFamilies = true;

            return base.ManageAjax(model);
        }

        public async Task<IActionResult> Index() => await Task.Run(() => View());

        public override async Task<IActionResult> List(DataTablesAjaxPostModel filter)
        {
            ListParameters.AddParameter("IsDeleted", false);

            return await base.AlternativeList(filter, (filter, recordsTotal, recordsFiltered, query, parameters) => residueFamilyListService.GetDataFiltered(filter, out recordsTotal, out recordsFiltered, query, parameters));
        }

        public override async Task Delete(int id)
        {
            await residueServices.DeleteByFamilyIdAsync(id, (await GetUser()).Id);
            await base.Delete(id);
        }
    }
}