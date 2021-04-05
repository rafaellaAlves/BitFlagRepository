using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace AMaisImob_WEB.Controllers
{
    public class InsurancePolicyController : Controller
    {
        private readonly BLL.InsurancePolicyFunctions insurancePolicyFunctions;
        private readonly BLL.CompanyFunctions companyFunctions;
        private readonly BLL.CompanyTypeFunctions companyTypeFunctions;
        private readonly BLL.UserCompanyFunctions userCompanyFunctions;
        private readonly BLL.ProductFunctions productFunctions;
        private readonly BLL.CompanyOwnerTypeFunctions companyOwnerTypeFunctions;
        private readonly BLL.AuditLogFunctions auditLogFunctions;
        private readonly UserManager<AMaisImob_DB.Models.User> userManager;

        public InsurancePolicyController(AMaisImob_DB.Models.AMaisImob_HomologContext context, UserManager<AMaisImob_DB.Models.User> userManager)
        {
            this.insurancePolicyFunctions = new BLL.InsurancePolicyFunctions(context);
            this.companyFunctions = new BLL.CompanyFunctions(context);
            this.companyTypeFunctions = new BLL.CompanyTypeFunctions(context);
            this.userCompanyFunctions = new BLL.UserCompanyFunctions(context);
            this.productFunctions = new BLL.ProductFunctions(context);
            this.companyOwnerTypeFunctions = new BLL.CompanyOwnerTypeFunctions(context);
            this.auditLogFunctions = new BLL.AuditLogFunctions(context);
            this.userManager = userManager;
        }

        [Authorize(Roles = "Administrator, Corretor")]
        public async Task<IActionResult> Index()
        {
            var user = await userManager.GetUserAsync(User);
            var userCompany = userCompanyFunctions.GetDataByUserId(user.Id).FirstOrDefault();
            if (!User.IsInRole("Administrator") && userCompany == null) return RedirectToAction("NoCompany", "Account");

            return View();
        }

        [Authorize(Roles = "Administrator, Corretor")]
        public async Task<IActionResult> InsurancePolicyIndexComponent()
        {
            var user = await userManager.GetUserAsync(User);
            var userCompany = userCompanyFunctions.GetDataByUserId(user.Id).FirstOrDefault();
            if (!User.IsInRole("Administrator") && userCompany == null) return Forbid();

            return ViewComponent(typeof(ViewComponents.InsurancePolicy.InsurancePolicyIndexViewComponent));
        }

        [HttpPost]
        [ActionName("List")]
        [Authorize(Roles = "Administrator, Corretor")]
        public async Task<IActionResult> List(Models.DataTablesAjaxPostModel filter)
        {
            string query = "IsDeleted = 0";
            List<SqlParameter> param = new List<SqlParameter>();

            if (User.IsInRole("Corretor"))
            {
                var user = await userManager.GetUserAsync(User);
                var userCompany = userCompanyFunctions.GetDataByUserId(user.Id).FirstOrDefault();
                if (userCompany != null)
                {
                    query += " AND CompanyId = @CompanyId";
                    param.Add(new SqlParameter("@CompanyId", userCompany.CompanyId));
                }
                else
                {
                    return await Task.Run<IActionResult>(() => Json(new
                    {
                        recordsTotal = 0,
                        recordsFiltered = 0,
                        data = new List<AMaisImob_DB.Models.InsurancePolicy>()
                    }));
                }
            }

            IEnumerable<AMaisImob_DB.Models.InsurancePolicy> d = insurancePolicyFunctions.GetDataFiltered(filter, out int recordsTotal, out int recordsFiltered, query, param.ToArray());

            var r = insurancePolicyFunctions.GetDataListViewModel(d);

            return await Task.Run<IActionResult>(() => Json(new
            {
                recordsTotal = recordsTotal,
                recordsFiltered = recordsFiltered,
                data = r
            }));
        }

        [Authorize(Roles = "Administrator, Corretor")]
        public async Task<IActionResult> Manage(int? id)
        {
            var user = await userManager.GetUserAsync(User);

            if (User.IsInRole("Corretor"))
            {
                var userCompany = userCompanyFunctions.GetDataByUserId(user.Id).FirstOrDefault();
                if (userCompany == null) return Forbid();

                if (id.HasValue)
                {
                    var insurancePolicy = insurancePolicyFunctions.GetDataViewModel(insurancePolicyFunctions.GetDataByID(id));
                    if (userCompany != null && (insurancePolicy.CompanyId != userCompany.CompanyId)) return Forbid();
                }
            }

            return View(id);
        }

        [Authorize(Roles = "Administrator, Corretor")]
        public async Task<IActionResult> InsurancePolicyManageComponent(int? id)
        {
            Models.InsurancePolicyViewModel insurancePolicy = new Models.InsurancePolicyViewModel();
            if (id.HasValue)
                insurancePolicy = insurancePolicyFunctions.GetDataViewModel(insurancePolicyFunctions.GetDataByID(id));


            var corretoraTypeId = companyTypeFunctions.GetData().Single(x => x.ExternalCode == "CORRETORA").CompanyTypeId;

            var corretoras = companyFunctions.GetData(c => c.CompanyTypeId == corretoraTypeId && !c.IsDeleted);

            var user = await userManager.GetUserAsync(User);
            var userCompany = userCompanyFunctions.GetDataByUserId(user.Id).FirstOrDefault();

            if (User.IsInRole("Corretor"))
            {
                if (insurancePolicy.InsurancePolicyId.HasValue && insurancePolicy.CompanyId != userCompany.CompanyId) return Forbid();

                insurancePolicy.CompanyId = userCompany.CompanyId;
            }

            ViewData["Corretoras"] = corretoras.ToList();
            ViewData["Products"] = productFunctions.GetData(x => !x.IsDeleted).ToList();

            return ViewComponent(typeof(ViewComponents.InsurancePolicy.InsurancePolicyManageViewComponent), new { model = insurancePolicy });
        }

        [HttpPost]
        [ActionName("Manage")]
        [Authorize(Roles = "Administrator, Corretor")]
        public async Task<IActionResult> _Manage(Models.InsurancePolicyViewModel model)
        {
            if (!model.InsurancePolicyId.HasValue && insurancePolicyFunctions.ExistInsurancePolicyNumber(model.InsurancePolicyNumber))
            {
                return Json(new BLL.Shared.ReturnResult(0, "Número da apólice já utilizado", true));
            }

            Utils.DBActionType actionType;
            if (model.InsurancePolicyId.HasValue) actionType = Utils.DBActionType.UPDATE;
            else actionType = Utils.DBActionType.CREATE;

            model.InsurancePolicyId = insurancePolicyFunctions.CreateOrUpdate(model);

            var user = await userManager.GetUserAsync(User);
            auditLogFunctions.Log("InsurancePolicyViewModel", model.InsurancePolicyId.Value, "InsurancePolicyId", actionType, insurancePolicyFunctions.GetDataViewModel(insurancePolicyFunctions.GetDataByID(model.InsurancePolicyId)), user.Id);

            return Json(new BLL.Shared.ReturnResult(model.InsurancePolicyId.Value, "", false));
        }

        [HttpPost]
        [ActionName("RemoveInsurancePolicy")]
        [Authorize(Roles = "Administrator, Corretor")]
        public async Task<IActionResult> RemoveInsurancePolicy(int id)
        {
            if (!insurancePolicyFunctions.Exists(id)) return Json(new BLL.Shared.ReturnResult(0, "Apólice não encontrada para exclusão.", true));

            if (insurancePolicyFunctions.IsInCertificate(id))
            {
                return Json(new BLL.Shared.ReturnResult(0, "Não é possível excluir este apólice, pois ela está em um certificado", true));
            }

            insurancePolicyFunctions.Delete(id);
            var user = await userManager.GetUserAsync(User);
            auditLogFunctions.Log("InsurancePolicyViewModel", id, "InsurancePolicyId", Utils.DBActionType.DELETE, insurancePolicyFunctions.GetDataViewModel(insurancePolicyFunctions.GetDataByID(id)), user.Id, "Exclusão");

            return Json(new BLL.Shared.ReturnResult(0, "Apólice excluída com sucesso!", false));
        }

        [HttpPost]
        [ActionName("GetInsurancePoliciesByRealEstateAgencyId")]
        public IActionResult GetInsurancePoliciesByRealEstateAgencyId(int id, bool showExpired)
        {
            var insurancePolicies = insurancePolicyFunctions.GetInsurancePoliciesByRealEstateAgencyId(id, showExpired);
            return Json(insurancePolicies);
        }
    }
}