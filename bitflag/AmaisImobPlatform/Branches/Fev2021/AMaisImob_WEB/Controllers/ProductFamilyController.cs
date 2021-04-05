using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AMaisImob_WEB.BLL;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace AMaisImob_WEB.Controllers
{
    public class ProductFamilyController : Controller
    {
        private readonly ProductFamilyFunctions productFamilyFunctions;
        private readonly UserManager<AMaisImob_DB.Models.User> userManager;
        private readonly BLL.AuditLogFunctions auditLogFunctions;

        public ProductFamilyController(ProductFamilyFunctions productFamilyFunctions, UserManager<AMaisImob_DB.Models.User> userManager, BLL.AuditLogFunctions auditLogFunctions)
        {
            this.productFamilyFunctions = productFamilyFunctions;
            this.userManager = userManager;
            this.auditLogFunctions = auditLogFunctions;
        }

        public async Task<IActionResult> Index() => await Task.Run(() => View());
        public async Task<IActionResult> Manage(int? id) => await Task.Run(() => View(id));

        [HttpPost]
        [ActionName("Manage")]
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> _Manage(Models.ProductFamilyViewModel model)
        {
            Utils.DBActionType actionType;
            if (model.ProductFamilyId.HasValue) actionType = Utils.DBActionType.UPDATE;
            else actionType = Utils.DBActionType.CREATE;

            var user = await userManager.GetUserAsync(User);
            model.ModifiedBy = user.Id;

            var productFamilyId = productFamilyFunctions.CreateOrUpdate(model);

            auditLogFunctions.Log("ProductFamilyViewModel", productFamilyId, "ProductFamilyId", actionType, productFamilyFunctions.GetDataViewModel(productFamilyFunctions.GetDataByID(productFamilyId)), user.Id);

            return Json(new BLL.Shared.ReturnResult(productFamilyId, "", false));
        }

        [HttpPost]
        [ActionName("List")]
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> List(Models.DataTablesAjaxPostModel filter)
        {
            int recordsTotal = 0;
            int recordsFiltered = 0;

            var d = productFamilyFunctions.GetDataViewModel(productFamilyFunctions.GetDataFiltered(filter, out recordsTotal, out recordsFiltered, "IsDeleted = 0", whereParameters: null));

            return await Task.Run<IActionResult>(() => Json(new
            {
                recordsTotal = recordsTotal,
                recordsFiltered = recordsFiltered,
                data = d
            }));
        }

        [HttpPost]
        [ActionName("RemoveProductFamily")]
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> RemoveProductFamily(int id)
        {
            if (!productFamilyFunctions.Exists(id)) return Json(new BLL.Shared.ReturnResult(0, "Família não encontrada para remover.", true));

            if (await productFamilyFunctions.IsInProduct(id))
            {
                return Json(new BLL.Shared.ReturnResult(id, "Não é possível excluir esta família, pois está em um ou mais produtos.", true));
            }

            var user = await userManager.GetUserAsync(User);

            productFamilyFunctions.Delete(id, user.Id);

            auditLogFunctions.Log("ProductFamilyViewModel", id, "ProductFamilyId", Utils.DBActionType.DELETE, productFamilyFunctions.GetDataViewModel(productFamilyFunctions.GetDataByID(id)), user.Id, "Exclusão");
            return Json(new BLL.Shared.ReturnResult(id, "Família excluída com sucesso!", false));
        }

    }
}
