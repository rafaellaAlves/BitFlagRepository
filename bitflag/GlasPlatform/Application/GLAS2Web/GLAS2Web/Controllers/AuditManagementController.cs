using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace GLAS2Web.Controllers
{
    public class AuditManagementController : Controller
    {
        private readonly DAL.GLAS2Context _context;
        private readonly BLL.Audit.AuditFunctions _auditFunctions;
        private readonly BLL.Audit.AuditItemFunctions _auditItemFunctions;
        private readonly BLL.Company.CompanyFunctions _companyFunctions;
        private readonly BLL.Permission.CompanyUserRoleFunctions _companyUserRoleFunctions;
        private readonly UserManager<DAL.Identity.User> _userManager;
        private int ConclusionStatusId { get; }

        public AuditManagementController(DAL.GLAS2Context context, UserManager<DAL.Identity.User> userManager)
        {
            this._context = context;
            this._auditFunctions = new BLL.Audit.AuditFunctions(context);
            this._auditItemFunctions = new BLL.Audit.AuditItemFunctions(context);
            this._companyFunctions = new BLL.Company.CompanyFunctions(context);
            this._companyUserRoleFunctions = new BLL.Permission.CompanyUserRoleFunctions(context);
            this._userManager = userManager;


            ConclusionStatusId = new BLL.Audit.AuditStatusFunctions(context).GetData().Where(x => x.ExternalCode == "COMPLETED").Single().AuditStatusId;
        }

        public async Task<IActionResult> Index(int? companyId)
        {
            if (!this._companyFunctions.Exists(companyId)) return NotFound();
            ViewData["Company"] = this._companyFunctions.GetDataViewModel(this._companyFunctions.GetDataByID(companyId));

            if (User.IsInRole(BLL.User.ProfileNames.Administrator) || User.IsInRole(BLL.User.ProfileNames.Master)) return View(companyId);

            var user = await this._userManager.GetUserAsync(User);
            if (this._companyUserRoleFunctions.UserCompanyHasRole(user.Id, companyId.Value, BLL.User.ProfileNames.BioteraAuditor) || this._companyUserRoleFunctions.UserCompanyHasRole(user.Id, companyId.Value, BLL.User.ProfileNames.ClienteAdministrador) ||
                this._companyUserRoleFunctions.UserCompanyHasRole(user.Id, companyId.Value, BLL.User.ProfileNames.ClienteSupervisor)) return View(companyId);

            return Forbid();
        }

        public async Task<IActionResult> Manage(int? auditId, int? companyId)
        {
            if (!this._companyFunctions.Exists(companyId)) return NotFound();
            ViewData["Company"] = this._companyFunctions.GetDataViewModel(this._companyFunctions.GetDataByID(companyId));

            if (User.IsInRole(BLL.User.ProfileNames.Administrator) || User.IsInRole(BLL.User.ProfileNames.Master)) return View(auditId);

            var user = await this._userManager.GetUserAsync(User);
            if (this._companyUserRoleFunctions.UserCompanyHasRole(user.Id, companyId.Value, BLL.User.ProfileNames.BioteraAuditor) || this._companyUserRoleFunctions.UserCompanyHasRole(user.Id, companyId.Value, BLL.User.ProfileNames.ClienteAdministrador) ||
                this._companyUserRoleFunctions.UserCompanyHasRole(user.Id, companyId.Value, BLL.User.ProfileNames.ClienteSupervisor)) return View(auditId);

            return Forbid();
        }

        [HttpPost]
        public IActionResult Remove(int? auditId)
        {
            if (!auditId.HasValue) return Json(false);
            this._auditFunctions.Delete(auditId.Value);

            return Json(true);
        }

        #region [ViewComponent]
        public IActionResult AuditListViewComponent(int? companyId)
        {
            if (!this._companyFunctions.Exists(companyId)) NotFound();
            return ViewComponent(typeof(ViewComponents.AuditManagement.AuditListViewComponent), new { companyId = companyId });
        }

        public IActionResult AuditManageViewComponent(int? auditId, int? companyId)
        {
            if (!auditId.HasValue && !companyId.HasValue) return BadRequest();

            var _model = new DTO.Audit.AuditViewModel();
            if (companyId.HasValue) _model.CompanyId = companyId.Value;

            if (this._auditFunctions.Exists(auditId))
                _model = this._auditFunctions.GetDataViewModel(this._auditFunctions.GetDataByID(auditId));

            return ViewComponent(typeof(ViewComponents.AuditManagement.AuditManageViewComponent), new { model = _model });
        }

        public IActionResult AuditCompanyLawSelectViewComponent(int? companyId, int? segmentoId, int? esferaId, int? lawTypeId, int? orgaoId)
        {
            if (!this._companyFunctions.Exists(companyId)) NotFound();
            return ViewComponent(typeof(ViewComponents.AuditManagement.AuditCompanyLawSelectViewComponent), new { companyId = companyId, segmentoId = segmentoId, esferaId = esferaId, lawTypeId = lawTypeId, orgaoId = orgaoId });
        }
        #endregion

        [HttpPost]
        [ActionName("List")]
        public IActionResult _List(DTO.Shared.DataTablesAjaxPostModel filter, int? companyId)
        {
            if (!companyId.HasValue)
                return Json(null);

            int recordsTotal = 0;
            int recordsFiltered = 0;
            //var d = this.companyLaw.GetDataViewModel(this.companyLaw.GetDataFiltered(filter, out recordsTotal, out recordsFiltered, "CompanyId = @CompanyId AND IsDeleted = 0", new System.Data.SqlClient.SqlParameter("@CompanyId", companyId)));//x => x.CompanyId == companyId && !x.IsDeleted));
            var d = this._auditFunctions.GetDataViewModel(this._auditFunctions.GetDataFiltered(filter, out recordsTotal, out recordsFiltered, "CompanyId = @CompanyId AND IsDeleted = 0", new System.Data.SqlClient.SqlParameter("@CompanyId", companyId)));

            return Json(new
            {
                draw = filter.draw,
                recordsTotal = recordsTotal,
                recordsFiltered = recordsFiltered,
                data = d
            });
        }

        public IActionResult ManageAjax([FromForm] DTO.Audit.AuditViewModel model)
        {
            int? oldAuditStatusId = null;
            if (model.AuditId.HasValue)
            {
                oldAuditStatusId = this._auditFunctions.GetDataByID(model.AuditId).AuditStatusId;
            }

            int auditId = this._auditFunctions.CreateOrUpdate(model);
            if (!model.AuditId.HasValue)
            {
                foreach (var companyLaw in model.CompanyLaws)
                {
                    this._auditItemFunctions.Create(new DTO.Audit.AuditItemViewModel()
                    {
                        AuditId = auditId,
                        CompanyLawId = companyLaw,
                        CompanyLawActionId = null,
                        AuditItemStatusId = null,
                        Comments = null
                    });
                }
            }
            else
            {
                auditId = model.AuditId.Value;

                if (ConclusionStatusId == model.AuditStatusId && oldAuditStatusId != model.AuditStatusId) //Se estiver sendo Concluido agora
                {
                    foreach (var auditItem in _auditItemFunctions.GetDataViewModel(_auditItemFunctions.GetDataAsNoTracking(x => x.AuditId == auditId)))
                    {
                        if (auditItem.CompanyLawView.LawIsDeleted || auditItem.CompanyLawView.LawRevokedDate.HasValue)//se estiver deletado ou renovado será removido da lista;
                        {
                            if (auditItem.AuditItemId.HasValue) this._auditItemFunctions.DeleteDefinitively(auditItem.AuditItemId);
                            continue;
                        }
                    }
                }
            }
            return Json(auditId);
        }
    }
}