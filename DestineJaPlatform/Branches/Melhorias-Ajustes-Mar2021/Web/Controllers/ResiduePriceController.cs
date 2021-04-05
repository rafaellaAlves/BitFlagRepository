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
using Web.Utils;
using Microsoft.AspNetCore.Authorization;

namespace Web.Controllers
{
    [Authorize(Roles = Constants.AllRolesExceptClient)]
    public class ResiduePriceController : Shared.BaseCRUDController<ResiduePrice, ResiduePriceViewModel, int>
    {
        private readonly ResiduePriceListServices residuePriceListServices;
        private readonly ResiduePriceServices residuePriceServices;
        public ResiduePriceController(ResiduePriceServices service, UserManager<User> userManager, ResiduePriceListServices residuePriceListServices) : base(service, userManager)
        {
            this.residuePriceListServices = residuePriceListServices;
            this.residuePriceServices = service;
        }

        public async Task<IActionResult> Index() => await Task.Run(() => View());

        [RequireRouteValues(new string[] { "recipientId" })]
        public async Task<IActionResult> List(DataTablesAjaxPostModel filter, int recipientId)
        {
            ListParameters.AddParameter("IsDeleted", false);
            ListParameters.AddParameter("RecipientId", recipientId);

            return await base.AlternativeList(filter, (filter, recordsTotal, recordsFiltered, query, parameters) => residuePriceListServices.ToViewModel(residuePriceListServices.GetDataFiltered(filter, out recordsTotal, out recordsFiltered, query, parameters)));
        }

        public override async Task<IActionResult> ManageAjax(ResiduePriceViewModel model)
        {
            if (await residuePriceServices.ExistResiduePrice(model)) return await Task.Run(() => Json(new { success = false, message = "Não foi possível salvar os dados, pois já existe um preço para este resíduo." }));

            return await base.ManageAjax(model);
        }

        public async Task<IActionResult> GetPriceVariationByFamilyId(int residueFamilyId, int unitOfMeasurement)
        {
            var r = await residuePriceServices.GetResiduePriceVariation(residueFamilyId, unitOfMeasurement);
            return await Task.Run(() => Json(r));
        }
    }
}