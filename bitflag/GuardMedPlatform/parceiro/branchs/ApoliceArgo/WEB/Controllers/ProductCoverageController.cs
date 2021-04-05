using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace WEB.Controllers
{
    [Authorize]
    public class ProductCoverageController : Controller
    {
        private readonly BLL.ProductCoverageFunctions productCoverageFunctions;
        private readonly BLL.ProductFunctions productFunctions;
        private readonly BLL.AuditLogFunctions auditLogFunctions;
        private readonly UserManager<DB.Models.AspNetUser> userManager;

        public ProductCoverageController(DB.Models.Insurance_HomologContext context, UserManager<DB.Models.AspNetUser> userManager)
        {
            this.productCoverageFunctions = new BLL.ProductCoverageFunctions(context);
            this.productFunctions = new BLL.ProductFunctions(context);
            this.auditLogFunctions = new BLL.AuditLogFunctions(context);
            this.userManager = userManager;
        }

        [Authorize(Roles = "Administrator")]
        public IActionResult Index(int? productId)
        {
            if (!productId.HasValue) return Forbid();

            return View(productId);
        }

        [Authorize(Roles = "Administrator")]
        public IActionResult ProductCoverageIndexComponent(int productId)
        {
            return ViewComponent(typeof(ViewComponents.ProductCoverage.ProductCoverageIndexViewComponent), new { productId });
        }

        [HttpPost]
        [ActionName("List")]
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> List(Models.DataTablesAjaxPostModel filter, int productId)
        {
            IEnumerable<DB.Models.ProductCoverage> d = productCoverageFunctions.GetDataFiltered(filter, out int recordsTotal, out int recordsFiltered, "IsDeleted = 0 AND ProductId = @ProductId", new SqlParameter("@ProductId", productId)).ToList();

            var r = productCoverageFunctions.GetDataViewModel(d);

            return await Task.Run<IActionResult>(() => Json(new
            {
                recordsTotal = recordsTotal,
                recordsFiltered = recordsFiltered,
                data = r
            }));
        }

        [Authorize(Roles = "Administrator")]
        public IActionResult Manage(int? id, int? productId)
        {
            if (!id.HasValue && !productId.HasValue) return Forbid();

            Models.ProductCoverageViewModel model = new Models.ProductCoverageViewModel();
            if (id.HasValue)
                model = productCoverageFunctions.GetDataViewModel(productCoverageFunctions.GetDataByID(id));
            if (productId.HasValue)
                model.ProductId = productId.Value;

            return View(model);
        }

        [Authorize(Roles = "Administrator")]
        public IActionResult ProductCoverageManageComponent(int? id, int? productId)
        {
            Models.ProductCoverageViewModel model = new Models.ProductCoverageViewModel();
            if (id.HasValue)
                model = productCoverageFunctions.GetDataViewModel(productCoverageFunctions.GetDataByID(id));
            if (productId.HasValue)
                model.ProductId = productId.Value;

            ViewData["IsBasicUsed"] = productCoverageFunctions.GetData().Any(x => x.IsBasic && x.ProductId == model.ProductId);

            return ViewComponent(typeof(ViewComponents.ProductCoverage.ProductCoverageManageViewComponent), new { model });
        }

        [HttpPost]
        [ActionName("Manage")]
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> _Manage(Models.ProductCoverageViewModel model)
        {
            Utils.DBActionType dbActionType;
            if (model.ProductCoverageId.HasValue) dbActionType = Utils.DBActionType.UPDATE;
            else dbActionType = Utils.DBActionType.CREATE;

            var productCoverageId = productCoverageFunctions.CreateOrUpdate(model);

            var user = await userManager.GetUserAsync(User);
            auditLogFunctions.Log("ProductCoverageViewModel", productCoverageId, "ProductCoverageId", dbActionType, productCoverageFunctions.GetDataViewModel(productCoverageFunctions.GetDataByID(productCoverageId)), user.Id);

            return Json(productCoverageId);
        }

        [HttpPost]
        [ActionName("RemoveProductCoverage")]
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> RemoveProductCoverage(int id)
        {
            if (!productCoverageFunctions.Exists(id)) return Json(new BLL.Shared.ReturnResult(0, "Cobertura não encontrada para remover.", true));

            var productCoverage = productCoverageFunctions.GetDataByID(id);

            if (productFunctions.IsInInsurancePolicy(productCoverage.ProductId))
            {
                return Json(new BLL.Shared.ReturnResult(id, "Não é possível excluir esta cobertura, pois o produto a qual pertence esta em uma apólice.", true));
            }

            productCoverageFunctions.Delete(id);

            var user = await userManager.GetUserAsync(User);
            auditLogFunctions.Log("ProductCoverageViewModel", id, "ProductCoverageId", Utils.DBActionType.DELETE, productCoverageFunctions.GetDataViewModel(productCoverageFunctions.GetDataByID(id)), user.Id, "Exclusão");

            return Json(new BLL.Shared.ReturnResult(id, "Cobertura excluída com sucesso!", false));
        }
    }
}