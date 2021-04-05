using System.Threading.Tasks;
using ApplicationDbContext.Models;
using AspNetIdentityDbContext;
using DTO.Residue;
using DTO.Shared;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Services.Account;
using Services.Residue;
using Services.Shared;
using Web.Utils;

namespace Web.Controllers
{
    [Authorize]
    public class ResiduesController : Shared.BaseCRUDController<Residue, ResidueViewModel, int>
    {
        private readonly ResidueFamilyListService residueFamilyListService;
        private readonly ResidueListServices residueListServices;
        private readonly ResiduePriceServices residuePriceServices;
        private readonly ResidueServices residueServices;
        public ResiduesController(ResidueServices service, UserManager<User> userManager, ResidueListServices residueListServices, ResidueFamilyListService residueFamilyListService, ResiduePriceServices residuePriceServices) : base(service, userManager)
        {
            this.residueListServices = residueListServices;
            this.residueFamilyListService = residueFamilyListService;
            this.residuePriceServices = residuePriceServices;
            this.residueServices = service;
        }

    [Authorize(Roles = Constants.AllRolesExceptClient)]
        public async Task<IActionResult> Index(int residueFamilyId) => await Task.Run(() => View(residueFamilyListService.GetDataByIdAsync(residueFamilyId).Result));

        [RequireRouteValues(new string[] { "residueFamilyId" })]
    [Authorize(Roles = Constants.AllRolesExceptClient)]
        public async Task<IActionResult> List(DataTablesAjaxPostModel filter, int residueFamilyId)
        {
            ListParameters.AddParameter("IsDeleted", false);
            ListParameters.AddParameter("ResidueFamilyId", residueFamilyId);

            return await base.AlternativeList(filter, (filter, recordsTotal, recordsFiltered, query, parameters) => residueListServices.ToViewModel(residueListServices.GetDataFiltered(filter, out recordsTotal, out recordsFiltered, query, parameters)));
        }

        public async Task<IActionResult> GetDataByFamilyId(int residueFamilyId) => await Task.Run(async () => Json( await service.GetDataAsNoTrackingAsync(x => !x.IsDeleted && x.ResidueFamilyId == residueFamilyId)));

    [Authorize(Roles = Constants.AllRolesExceptClient)]
        public override async Task<IActionResult> ManageAjax(ResidueViewModel model)
        {
            //if (await residueServices.ExistResidue(model)) return await Task.Run(() => Json(new { success = false, message = "Não foi possível criar este resíduo, pois já existe um nesta família com o mesmo código IBAMA." }));

            return await base.ManageAjax(model);
        }
    }
}