using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using WEB.Models;
using WEB.Utils;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace WEB.Controllers
{
    [Authorize]
    public class ProductController : Controller
    {
        private readonly BLL.ProductPlanFunctions productPlanFunctions;
        private readonly BLL.ProductCoverageFunctions productCoverageFunctions;
        private readonly BLL.ProductFunctions productFunctions;
        private readonly BLL.PlanFunctions planFunctions;
        private readonly BLL.PlanCoverageFunctions planCoverageFunctions;
        private readonly BLL.AssistanceFunctions assistanceFunctions;
        private readonly BLL.AuditLogFunctions auditLogFunctions;
        private readonly UserManager<DB.Models.AspNetUser> userManager;

        public ProductController(DB.Models.Insurance_HomologContext context, UserManager<DB.Models.AspNetUser> userManager)
        {
            this.productPlanFunctions = new BLL.ProductPlanFunctions(context);
            this.productFunctions = new BLL.ProductFunctions(context);
            this.planFunctions = new BLL.PlanFunctions(context);
            this.productCoverageFunctions = new BLL.ProductCoverageFunctions(context);
            this.planCoverageFunctions = new BLL.PlanCoverageFunctions(context);
            this.assistanceFunctions = new BLL.AssistanceFunctions(context);
            this.auditLogFunctions = new BLL.AuditLogFunctions(context);
            this.userManager = userManager;
        }

        [Authorize(Roles = "Administrator")]
        public IActionResult Index()
        {
            return View();
        }

        [Authorize(Roles = "Administrator")]
        public IActionResult ProductIndexComponent()
        {
            return ViewComponent(typeof(ViewComponents.Product.ProductIndexViewComponent));
        }

        [HttpPost]
        [ActionName("List")]
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> List(Models.DataTablesAjaxPostModel filter)
        {
            int recordsTotal = 0;
            int recordsFiltered = 0;

            IEnumerable<DB.Models.Product> d = this.productFunctions.GetDataFiltered(filter, out recordsTotal, out recordsFiltered, "IsDeleted = 0", whereParameters: null).ToList();
            var plans = planFunctions.GetData();
            var coverages = productCoverageFunctions.GetData();

            var r = (from y in d
                     select new ProductListViewModel
                     {
                         ExternalCode = y.ExternalCode,
                         ProductId = y.ProductId,
                         Name = y.Name,
                         Description = y.Description,
                         QtdCoverage = coverages.Count(x => x.ProductId == y.ProductId && !x.IsDeleted),
                         QtdPlan = plans.Count(x => x.ProductId == y.ProductId && !x.CertificateId.HasValue && ((x.IsDeleted.HasValue && !x.IsDeleted.Value) || !x.IsDeleted.HasValue))
                     });

            return await Task.Run<IActionResult>(() => Json(new
            {
                recordsTotal = recordsTotal,
                recordsFiltered = recordsFiltered,
                data = r
            }));
        }

        [Authorize(Roles = "Administrator")]
        public IActionResult Manage(int? id)
        {
            return View(id);
        }

        [Authorize(Roles = "Administrator")]
        public IActionResult ProductManageComponent(int? id)
        {
            ProductViewModel product = new ProductViewModel();
            if (id.HasValue)
                product = productFunctions.GetDataViewModel(productFunctions.GetDataByID(id));

            return ViewComponent(typeof(ViewComponents.Product.ProductManageViewComponent), new { model = product });
        }

        [HttpPost]
        [ActionName("Manage")]
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> _Manage(Models.ProductViewModel model)
        {
            Utils.DBActionType dbActionType;
            if (model.ProductId.HasValue) dbActionType = Utils.DBActionType.UPDATE;
            else dbActionType = Utils.DBActionType.CREATE;

            var productId = productFunctions.CreateOrUpdate(model);

            var user = await userManager.GetUserAsync(User);
            auditLogFunctions.Log("ProductViewModel", productId, "ProductId", dbActionType, productFunctions.GetDataViewModel(productFunctions.GetDataByID(productId)), user.Id);

            return Json(productId);
        }

        [HttpPost]
        [ActionName("RemoveProduct")]
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> RemoveProduct(int id)
        {
            if (!productFunctions.Exists(id)) return Json(new BLL.Shared.ReturnResult(0, "Produto não encontrado para remover.", true));

            if (productFunctions.IsInInsurancePolicy(id))
            {
                return Json(new BLL.Shared.ReturnResult(id, "Não é possível excluir este produto, pois esta em uma apólice.", false));
            }

            productFunctions.Delete(id);

            var user = await userManager.GetUserAsync(User);
            auditLogFunctions.Log("ProductViewModel", id, "ProductId", DBActionType.DELETE, productFunctions.GetDataViewModel(productFunctions.GetDataByID(id)), user.Id, "Exclusão");
            return Json(new BLL.Shared.ReturnResult(id, "Produto excluído com sucesso!", false));
        }

        [Authorize(Roles = "Administrator")]
        public IActionResult ProductPlanComponent(int? productId)
        {
            if (!productId.HasValue) return Forbid();

            ProductPlanManageViewModel model = productPlanFunctions.GetDataManageViewModel(productId.Value);

            ViewData["Plans"] = planFunctions.GetData().ToList();

            return ViewComponent(typeof(ViewComponents.ProductPlan.ProductPlanVIewComponent), new { model = model });
        }

        [HttpPost]
        [Authorize(Roles = "Administrator")]
        public IActionResult ProductPlanSave(int? productId, List<int> planIds)
        {
            if (!productId.HasValue)
                return Json(new BLL.Shared.ReturnResult(0, "", true));

            productPlanFunctions.DeleteByProductId(productId.Value);
            productPlanFunctions.Create(productId.Value, planIds);

            return Json(new BLL.Shared.ReturnResult(productId.Value, "", false));
        }

        [HttpPost]
        [ActionName("GetPlansByProduct")]
        [Authorize]
        public IActionResult GetPlansByProduct(int productId, int? certificateId)
        {
            var plans = planFunctions.GetData().ToList();
            var planCoverages = planCoverageFunctions.GetData().ToList();
            var productCoverages = productCoverageFunctions.GetData().ToList();
            var assistances = assistanceFunctions.GetData().ToList();

            var r = (from y in plans
                     join p in planCoverages on y.PlanId equals p.PlanId
                     join _p in productCoverages on p.ProductCoverageId equals _p.ProductCoverageId
                     join a in assistances on y.AssistanceId equals a.AssistanceId into _a
                     from __a in _a.DefaultIfEmpty()
                     group new { y, p, _p, __a } by new { y.Name, y.PlanId, y.ProductId, y.Description, y.IsDeleted, y.CertificateId, y.AssistanceId, Value = (__a == null? 0 : (double?)__a.Value) } into c
                     where c.Key.ProductId == productId && (!c.Key.CertificateId.HasValue || (c.Key.CertificateId.HasValue && c.Key.CertificateId == certificateId)) && !c.Key.IsDeleted.Value
                     select new CertificatePlanViewModel
                     {
                         Description = c.Key.Description,
                         IsDeleted = c.Key.IsDeleted,
                         PlanId = c.Key.PlanId,
                         ProductId = c.Key.ProductId,
                         Name = c.Key.Name,
                         AssistanceId = c.Key.AssistanceId,
                         CertificateId = c.Key.CertificateId,
                         MonthlyPrice = c.Sum(x => (!x._p.IsOptional || x.p.Used) && x.p.Garantia.HasValue ? (x._p.Taxes / 100 * x.p.Garantia.Value) : 0),
                         AnnualPrice = c.Sum(x => (!x._p.IsOptional || x.p.Used) && x.p.Garantia.HasValue ? (x._p.Taxes / 100 * x.p.Garantia.Value) : 0) * 12,
                         AssitancePrice = c.Key.Value
                     }).OrderByDescending(x => !x.Name.ContainNumbers());

            return Json(r);
        }

       
    }
}