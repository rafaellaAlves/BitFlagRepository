using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    [Authorize(Roles = "Administrator")]
    public class ServiceTypeController : Controller
    {
        private readonly FUNCTIONS.ServiceType.ServiceTypeFunctions serviceTypeFunctions;
        private readonly FUNCTIONS.AuditLog.AuditLogFunctions auditLogFunctions;
        private readonly UserManager<TerraNostraIdentityDbContext.User> userManager;

        public ServiceTypeController(FUNCTIONS.ServiceType.ServiceTypeFunctions serviceTypeFunctions, FUNCTIONS.AuditLog.AuditLogFunctions auditLogFunctions, UserManager<TerraNostraIdentityDbContext.User> userManager)
        {
            this.serviceTypeFunctions = serviceTypeFunctions;
            this.auditLogFunctions = auditLogFunctions;
            this.userManager = userManager;
        }

        #region [PAGE]
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Manage(int? id)
        {
            if (!User.IsInRole("Administrator")) return Forbid();

            return View(id);
        }
        #endregion

        #region [ViewComponent]
        public IActionResult ServiceTypeIndexComponent()
        {
            return ViewComponent(typeof(ViewComponents.ServiceType.ServiceTypeIndexViewComponent));
        }

        public IActionResult ServiceTypeManageComponent(int? id)
        {
            var service = new DTO.ServiceType.ServiceTypeViewModel();
            if (id.HasValue) service = serviceTypeFunctions.GetDataViewModel(serviceTypeFunctions.GetDataByID(id));

            return ViewComponent(typeof(ViewComponents.ServiceType.ServiceTypeManageViewComponent), new { model = service });
        }
        #endregion

        #region [XHR]
        [HttpPost]
        [ActionName("List")]
        public async Task<IActionResult> List(DTO.Shared.DataTablesAjaxPostModel filter)
        {
            string query = "IsDeleted = 0";
            List<SqlParameter> param = new List<SqlParameter>();

            IEnumerable<DTO.ServiceType.ServiceTypeViewModel> d = serviceTypeFunctions.GetDataViewModel(serviceTypeFunctions.GetDataFiltered(filter, out int recordsTotal, out int recordsFiltered, query, param.ToArray()));

            return await Task.Run<IActionResult>(() => Json(new
            {
                recordsTotal = recordsTotal,
                recordsFiltered = recordsFiltered,
                data = d
            }));
        }

        [HttpPost]
        [ActionName("Manage")]
        public async Task<IActionResult> _Manage(DTO.ServiceType.ServiceTypeViewModel model)
        {
            var user = await userManager.GetUserAsync(User);

            FUNCTIONS.AuditLog.DBActionType dbActionType;
            if (model.ServiceTypeId.HasValue) dbActionType = FUNCTIONS.AuditLog.DBActionType.UPDATE;
            else dbActionType = FUNCTIONS.AuditLog.DBActionType.CREATE;

            if (serviceTypeFunctions.ExistExternalCode(model.ExternalCode, model.ServiceTypeId))
                return Json(new FUNCTIONS.Shared.ReturnResult(0, "Código já utilizado.", true, "ExternalCode"));

            model.ServiceTypeId = serviceTypeFunctions.CreateOrUpdate(model);

            auditLogFunctions.Log("ServiceTypeViewModel", model.ServiceTypeId.Value, "ServiceTypeId", dbActionType, serviceTypeFunctions.GetDataViewModel(serviceTypeFunctions.GetDataByID(model.ServiceTypeId)), user.Id);

            return Json(new FUNCTIONS.Shared.ReturnResult(model.ServiceTypeId.Value, "", false));
        }

        [HttpPost]
        [ActionName("RemoveServiceType")]
        public async Task<IActionResult> RemoveServiceType(int id)
        {
            if (!serviceTypeFunctions.Exists(id)) return Json(new FUNCTIONS.Shared.ReturnResult(0, "Serviço não encontrado para excluir.", true));
            if(!serviceTypeFunctions.CanDelete(id)) return Json(new FUNCTIONS.Shared.ReturnResult(0, "Não é possivel excluir este serviço, pois ele é utilizado em indicação.", true));

            var user = await userManager.GetUserAsync(User);

            serviceTypeFunctions.Delete(id);

            auditLogFunctions.Log("ServiceTypeViewModel", id, "ServiceTypeId", FUNCTIONS.AuditLog.DBActionType.DELETE, serviceTypeFunctions.GetDataViewModel(serviceTypeFunctions.GetDataByID(id)), user.Id, "Exclusão");

            return Json(new FUNCTIONS.Shared.ReturnResult(0, "Serviço excluído com sucesso!", false));
        }
#endregion
    }
}