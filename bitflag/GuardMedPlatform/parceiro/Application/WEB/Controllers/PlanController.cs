using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using DB.Models;
using WEB.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace WEB.Controllers
{
    [Authorize]
    public class PlanController : Controller
    {
        private readonly BLL.ProductCoverageFunctions productCoverageFunctions;
        private readonly BLL.PlanFunctions planFunctions;
        private readonly BLL.PlanCoverageFunctions planCoverageFunctions;
        private readonly BLL.AssistanceFunctions assistanceFunctions;
        private readonly BLL.ProductAssistanceFunctions productAssistanceFunctions;
        private readonly BLL.ProductFunctions productFunctions;
        private readonly BLL.CertificateFunctions certificateFunctions;
        private readonly BLL.AuditLogFunctions auditLogFunctions;
        private readonly UserManager<DB.Models.AspNetUser> userManager;

        public PlanController(DB.Models.Insurance_HomologContext context, UserManager<DB.Models.AspNetUser> userManager)
        {
            this.productCoverageFunctions = new BLL.ProductCoverageFunctions(context);
            this.planFunctions = new BLL.PlanFunctions(context);
            this.planCoverageFunctions = new BLL.PlanCoverageFunctions(context);
            this.assistanceFunctions = new BLL.AssistanceFunctions(context);
            this.productAssistanceFunctions = new BLL.ProductAssistanceFunctions(context);
            this.productFunctions = new BLL.ProductFunctions(context);
            this.certificateFunctions = new BLL.CertificateFunctions(context);
            this.auditLogFunctions = new BLL.AuditLogFunctions(context);
            this.userManager = userManager;
        }

        [Authorize(Roles = "Administrator")]
        public IActionResult Index(int? productId)
        {
            return View(productId);
        }

        public IActionResult PlanIndexComponent(int? productId)
        {
            return ViewComponent(typeof(ViewComponents.Plan.PlanIndexViewComponent), new { productId });
        }

        [HttpPost]
        [ActionName("List")]
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> List(Models.DataTablesAjaxPostModel filter, int? productId)
        {
            var query = "IsDeleted = 0 AND CertificateId IS NULL";
            var sqlParam = new List<SqlParameter>();
            if (productId.HasValue)
            {
                query += " AND ProductId = @ProductId";
                sqlParam.Add(new SqlParameter("@ProductId", productId));
            }

            IEnumerable<DB.Models.Plan> d = this.planFunctions.GetDataFiltered(filter, out int recordsTotal, out int recordsFiltered, query, sqlParam.ToArray()).ToList();

            var r = (from y in d
                     select new PlanListViewModel
                     {
                         PlanId = y.PlanId,
                         Name = y.Name,
                         Description = y.Description,
                         IsDeleted = y.IsDeleted,
                     });

            return await Task.Run<IActionResult>(() => Json(new
            {
                recordsTotal = recordsTotal,
                recordsFiltered = recordsFiltered,
                data = r
            }));
        }

        [HttpPost]
        [ActionName("PlanCoverageList")]
        [Authorize]
        public async Task<IActionResult> PlanCoverageList(Models.DataTablesAjaxPostModel filter, int productId, int? planId)
        {
            IEnumerable<DB.Models.ProductCoverage> d = productCoverageFunctions.GetDataFiltered(filter, out int recordsTotal, out int recordsFiltered, "IsDeleted = 0 AND ProductId = @ProductId", new SqlParameter("@ProductId", productId)).ToList();

            var r = planCoverageFunctions.GetPlanCoverageListViewModel(d, planId, productId);

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

            PlanViewModel plan = new PlanViewModel();
            if (id.HasValue)
                plan = planFunctions.GetDataViewModel(planFunctions.GetDataByID(id));
            if (productId.HasValue)
                plan.ProductId = productId.Value;

            return View(plan);
        }

        [Authorize(Roles = "Administrator")]
        public IActionResult PlanManageComponent(int? id, int? productId)
        {
            if (!id.HasValue && !productId.HasValue) return Forbid();

            PlanViewModel plan = new PlanViewModel();
            if (id.HasValue)
                plan = planFunctions.GetDataViewModel(planFunctions.GetDataByID(id));
            if (productId.HasValue)
                plan.ProductId = productId.Value;

            return ViewComponent(typeof(ViewComponents.Plan.PlanManageViewComponent), new { model = plan });
        }

        [HttpPost]
        [ActionName("Manage")]
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> _Manage(PlanViewModel model, List<PlanCoverage> coverages)
        {
            Utils.DBActionType dbActionType;
            if (model.PlanId.HasValue) dbActionType = Utils.DBActionType.UPDATE;
            else dbActionType = Utils.DBActionType.CREATE;

            var planId = planFunctions.CreateOrUpdate(model);

            var user = await userManager.GetUserAsync(User);
            auditLogFunctions.Log("PlanViewModel", planId, "PlanId", dbActionType, planFunctions.GetDataViewModel(planFunctions.GetDataByID(planId)), user.Id);

            return Json(planId);
        }

        [HttpPost]
        [ActionName("RemovePlan")]
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> RemovePlan(int id)
        {
            if (!planFunctions.Exists(id)) return Json(new BLL.Shared.ReturnResult(0, "Plano não encontrado para remover.", true));

            if (planFunctions.IsInCertificate(id))
            {
                return Json(new BLL.Shared.ReturnResult(id, "Não é possível excluir este plano, pois ele é utilizado em um certificado.", true));
            }

            planFunctions.Delete(id);

            var user = await userManager.GetUserAsync(User);
            auditLogFunctions.Log("PlanViewModel", id, "PlanId", Utils.DBActionType.DELETE, planFunctions.GetDataViewModel(planFunctions.GetDataByID(id)), user.Id, "Exclusão");

            return Json(new BLL.Shared.ReturnResult(id, "Plano excluído com sucesso!", false));
        }

        [HttpPost]
        [ActionName("PlanCoverageSave")]
        [Authorize]
        public IActionResult PlanCoverageSave([FromBody]List<PlanCoverageViewModel> model)
        {
            var planId = model[0].PlanId;

            planCoverageFunctions.DeleteByPlanId(planId.Value);

            planCoverageFunctions.CreateRange(model.Select(x => new DB.Models.PlanCoverage
            {
                Garantia = x.Garantia,
                PlanId = planId.Value,
                ProductCoverageId = x.ProductCoverageId.Value,
                Used = x.Used
            }));

            return Json(new BLL.Shared.ReturnResult(planId.Value, "", false));
        }

        [HttpPost]
        [ActionName("FreePlanSave")]
        [Authorize]
        public async Task<IActionResult> FreePlanSave(int? productId)
        {
            if (!productId.HasValue) return Json(new BLL.Shared.ReturnResult(0, "", true));

            var planId = planFunctions.Create(new PlanViewModel
            {
                ProductId = productId.Value,
                Name = "Plano Livre"
            });

            var user = await userManager.GetUserAsync(User);
            auditLogFunctions.Log("PlanViewModel", planId, "PlanId", Utils.DBActionType.CREATE, planFunctions.GetDataViewModel(planFunctions.GetDataByID(planId)), user.Id);

            return Json(new BLL.Shared.ReturnResult(planId, "", false));
        }

        [HttpPost]
        [ActionName("SetFreePlanSaveCertificateId")]
        [Authorize]
        public IActionResult SetFreePlanSaveCertificateId(int? planId, int? certificateId)
        {
            if (!certificateId.HasValue || !planId.HasValue) return Json(new BLL.Shared.ReturnResult(0, "", true));

            planFunctions.UpdateCertificateId(planId.Value, certificateId.Value);

            return Json(new BLL.Shared.ReturnResult(planId.Value, "", false));
        }

        [Authorize(Roles = "Administrator")]
        public IActionResult PlanCoverage(int? planId)
        {
            if (!planId.HasValue) return Forbid();

            PlanViewModel plan = new PlanViewModel();
            plan = planFunctions.GetDataViewModel(planFunctions.GetDataByID(planId));

            return View(plan);
        }

        [Authorize(Roles = "Administrator")]
        public IActionResult PlanCoverageComponent(int? planId)
        {
            if (!planId.HasValue) return Forbid();

            PlanViewModel plan = planFunctions.GetDataViewModel(planFunctions.GetDataByID(planId));

            return ViewComponent(typeof(ViewComponents.Plan.PlanCoverageViewComponent), new { plan });
        }

        [Authorize]
        public IActionResult FreePlanCoverageComponent(int? planId, int? productId, int? certificateId)
        {
            if (!planId.HasValue && !productId.HasValue) return Forbid();

            PlanViewModel plan = new PlanViewModel();
            if (planId.HasValue) plan = planFunctions.GetDataViewModel(planFunctions.GetDataByID(planId));
            if (productId.HasValue) plan.ProductId = productId.Value;
            if (!planId.HasValue && certificateId.HasValue)
            {
                plan.CertificateId = certificateId;
                plan.Certificate = certificateFunctions.GetDataViewModel(certificateFunctions.GetDataByID(certificateId));
            }

            return ViewComponent(typeof(ViewComponents.Plan.FreePlanCoverageViewComponent), new { plan });
        }

        [Authorize(Roles = "Administrator")]
        public IActionResult PlanAssistanceComponent(int? planId)
        {
            if (!planId.HasValue) return Forbid();

            var plan = planFunctions.GetDataByID(planId);
            var assitanceIds = productAssistanceFunctions.GetDataByProductId(plan.ProductId).Select(x => x.AssistanceId);
            ViewData["Assistances"] = assistanceFunctions.GetData(x => assitanceIds.Contains(x.AssistanceId)).ToList();

            return ViewComponent(typeof(ViewComponents.PlanAssistance.PlanAssistanceViewComponent), new { model = plan });
        }

        [Authorize(Roles = "Administrator")]
        public IActionResult PlanAssistanceSave(int? planId, int? assistanceId)
        {
            if (!planId.HasValue) return Json(new BLL.Shared.ReturnResult(0, "", true));

            planFunctions.RemoveAssistance(planId.Value);
            if (assistanceId.HasValue) planFunctions.SaveAssistance(planId.Value, assistanceId.Value);

            return Json(new BLL.Shared.ReturnResult(0, "", false));
        }
    }
}