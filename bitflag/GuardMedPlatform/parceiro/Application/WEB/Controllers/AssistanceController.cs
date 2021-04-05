using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace WEB.Controllers
{
    [Authorize]
    public class AssistanceController : Controller
    {
        private readonly BLL.AssistanceFunctions assistanceFunctions;
        private readonly BLL.ProductAssistanceFunctions productAssistanceFunctions;
        private readonly BLL.AuditLogFunctions auditLogFunctions;
        private readonly UserManager<DB.Models.AspNetUser> userManager;

        public AssistanceController(DB.Models.Insurance_HomologContext context, UserManager<DB.Models.AspNetUser> userManager)
        {
            this.assistanceFunctions = new BLL.AssistanceFunctions(context);
            this.productAssistanceFunctions = new BLL.ProductAssistanceFunctions(context);
            this.auditLogFunctions = new BLL.AuditLogFunctions(context);
            this.userManager = userManager;
        }

        [Authorize(Roles = "Administrator")]
        public IActionResult Manage(int? id)
        {
            return View(id);
        }

        [Authorize(Roles = "Administrator")]
        public IActionResult AssistanceManageComponent(int? id)
        {
            Models.AssistanceViewModel model = new Models.AssistanceViewModel();

            if (id.HasValue)
                model = assistanceFunctions.GetDataViewModel(assistanceFunctions.GetDataByID(id));

            return ViewComponent(typeof(ViewComponents.Assistance.AssistanceManageViewComponent), new { model = model });
        }

        [Authorize(Roles = "Administrator")]
        public IActionResult Index()
        {
            return View();
        }

        [Authorize(Roles = "Administrator")]
        public IActionResult AssistanceIndexComponent()
        {
            return ViewComponent(typeof(ViewComponents.Assistance.AssistanceIndexViewComponent));
        }

        [HttpPost]
        [ActionName("Manage")]
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> _Manage(Models.AssistanceViewModel model)
        {
            Utils.DBActionType actionType;
            if (model.AssistanceId.HasValue) actionType = Utils.DBActionType.UPDATE;
            else actionType = Utils.DBActionType.CREATE;

            var user = await userManager.GetUserAsync(User);

            var assistanceId = assistanceFunctions.CreateOrUpdate(model);

            auditLogFunctions.Log("AssistanceViewModel", assistanceId, "AssistanceId", actionType, assistanceFunctions.GetDataViewModel(assistanceFunctions.GetDataByID(assistanceId)), user.Id);

            return Json(new BLL.Shared.ReturnResult(assistanceId, "", false));
        }

        [HttpPost]
        [ActionName("List")]
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> List(Models.DataTablesAjaxPostModel filter)
        {
            int recordsTotal = 0;
            int recordsFiltered = 0;

            IEnumerable<WEB.Models.AssistanceViewModel> d = assistanceFunctions.GetDataViewModel(assistanceFunctions.GetDataFiltered(filter, out recordsTotal, out recordsFiltered, "IsDeleted = 0", whereParameters: null));

            return await Task.Run<IActionResult>(() => Json(new
            {
                recordsTotal = recordsTotal,
                recordsFiltered = recordsFiltered,
                data = d
            }));
        }

        [HttpPost]
        [ActionName("RemoveAssistance")]
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> RemoveAssistance(int id)
        {
            if (!assistanceFunctions.Exists(id)) return Json(new BLL.Shared.ReturnResult(0, "Assistência não encontrada para remover.", true));

            if (assistanceFunctions.IsInCertificate(id))
            {
                return Json(new BLL.Shared.ReturnResult(id, "Não é possível excluir esta assistência, pois esta em um certificado.", true));
            }

            assistanceFunctions.Delete(id);

            var user = await userManager.GetUserAsync(User);
            auditLogFunctions.Log("AssistanceViewModel", id, "AssistanceId", Utils.DBActionType.DELETE, assistanceFunctions.GetDataViewModel(assistanceFunctions.GetDataByID(id)), user.Id, "Exclusão");
            return Json(new BLL.Shared.ReturnResult(id, "Assistência excluída com sucesso!", false));
        }

        [Authorize(Roles = "Administrator")]
        public IActionResult ProductAssistanceComponent(int? productId)
        {
            if (!productId.HasValue) return Forbid();

            var model = productAssistanceFunctions.GetDataManageViewModel(productId.Value);
            ViewData["Assistances"] = assistanceFunctions.GetData(x => !x.IsDeleted).ToList();

            return ViewComponent(typeof(ViewComponents.Assistance.ProductAssistanceViewComponent), new { model = model });
        }

        [HttpPost]
        [ActionName("ProductAssistanceSave")]
        [Authorize(Roles = "Administrator")]
        public IActionResult ProductAssistanceSave(int? productId, List<int> assistanceIds)
        {
            if (!productId.HasValue)
                return Json(new BLL.Shared.ReturnResult(0, "", true));

            productAssistanceFunctions.DeleteByProductId(productId.Value);
            productAssistanceFunctions.Create(productId.Value, assistanceIds);

            return Json(new BLL.Shared.ReturnResult(productId.Value, "", false));
        }

        [HttpPost]
        [Authorize]
        public IActionResult GetAssistancesByProductId(int? productId)
        {
            if (!productId.HasValue) return Json(false);

            var productAssistances = productAssistanceFunctions.GetDataByProductId(productId.Value);
            var assistances = assistanceFunctions.GetData(x => !x.IsDeleted);

            var r = assistanceFunctions.GetDataViewModel((from y in productAssistances
                     join a in assistances on y.AssistanceId equals a.AssistanceId
                     select a));

            return Json(r);
        }
    }
}