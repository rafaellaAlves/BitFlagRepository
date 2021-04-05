using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AMaisImob_WEB.Models;
using System.Data.SqlClient;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;

namespace AMaisImob_WEB.Controllers
{
    [Authorize(Roles = "Administrator")]
    public class UserCompanyController : Controller
    {
        //private readonly UserManager<AMaisImob_DB.Models.User> userManager;
        private readonly BLL.UserCompanyFunctions userCompanyFunctions;
        private readonly BLL.CompanyTypeFunctions companyTypeFunctions;
        private readonly BLL.UserFunctions userFunctions;
        private readonly BLL.RoleFunctions roleFunctions;

        public UserCompanyController(AMaisImob_DB.Models.AMaisImob_HomologContext context, UserManager<AMaisImob_DB.Models.User> userManager)
        {
            this.userCompanyFunctions = new BLL.UserCompanyFunctions(context);
            this.userFunctions = new BLL.UserFunctions(context, userManager);
            this.companyTypeFunctions = new BLL.CompanyTypeFunctions(context);
            this.roleFunctions = new BLL.RoleFunctions(context);
        }

        public IActionResult Manage(int? companyId)
        {
            if (!companyId.HasValue) return Forbid();

            return View(companyId);
        }

        public IActionResult UserCompanyManageComponent(int? companyId)
        {
            if (!companyId.HasValue) return Forbid();

            var model = userCompanyFunctions.GetDataManageViewModel(companyId.Value);

            var companyTypes = companyTypeFunctions.GetData();
            var corretoraId = companyTypes.Single(x => x.ExternalCode == "CORRETORA").CompanyTypeId;
            var imobiliariaId = companyTypes.Single(x => x.ExternalCode == "IMOBILIARIA").CompanyTypeId;
            
            if (model.Company.CompanyTypeId == corretoraId)
                ViewData["Users"] = userFunctions.GetUserWithoutCompanyByRoles(companyId.Value, "CORRETOR");
            else if(model.Company.CompanyTypeId == imobiliariaId)
                ViewData["Users"] = userFunctions.GetUserWithoutCompanyByRoles(companyId.Value, "IMOBILIARIAOPERACIONAL", "IMOBILIARIAFINANCEIRO", "IMOBILIARIOADMINISTRATIVO");

            return ViewComponent(typeof(ViewComponents.UserCompany.UserCompanyManageViewComponent), new { model = model });
        }

        [HttpPost]
        [ActionName("Manage")]
        public IActionResult _Manage(int? companyId, List<int> userIds)
        {
            if (!companyId.HasValue)
                return Json(new BLL.Shared.ReturnResult(0, "", true));


            userCompanyFunctions.DeleteByCompanyId(companyId.Value);
            userCompanyFunctions.Create(companyId.Value, userIds);

            return Json(new BLL.Shared.ReturnResult(companyId.Value, "", false));
        }

        public IActionResult Index(int? companyId)
        {
            if (!companyId.HasValue) return Forbid();

            return View(companyId);
        }

        public IActionResult UserCompanyIndexComponent(int? companyId)
        {
            if (!companyId.HasValue) return Forbid();

            return ViewComponent(typeof(ViewComponents.UserCompany.UserCompanyIndexViewComponent), new { companyId = companyId });
        }

        [HttpPost]
        [ActionName("List")]
        public async Task<IActionResult> List(Models.DataTablesAjaxPostModel filter, int companyId)
        {
            int recordsTotal = 0;
            int recordsFiltered = 0;

            IEnumerable<AMaisImob_DB.Models.UserCompany> d = this.userCompanyFunctions.GetDataFiltered(filter, out recordsTotal, out recordsFiltered, "CompanyId = @CompanyId", new SqlParameter("@CompanyId", companyId)).ToList();
            var users = this.userFunctions.GetData();

            var r = (from y in d
                     join u in users on y.UserId equals u.Id
                     select new UserCompanyViewModel
                     {
                         CompanyId = y.CompanyId,
                         UserCompanyId = y.UserCompanyId,
                         UserId = u.Id,
                         IsActive = u.IsActive,
                         Email = u.Email,
                         FirstName = u.FirstName,
                         LastName = u.LastName,
                         MobileNumber = u.MobileNumber,
                         PhoneNumber = u.PhoneNumber
                     });

            return await Task.Run<IActionResult>(() => Json(new
            {
                recordsTotal = recordsTotal,
                recordsFiltered = recordsFiltered,
                data = r
            }));
        }

        [HttpPost]
        [ActionName("RemoveUserCompany")]
        public IActionResult RemoveUserCompany(int id)
        {
            if (!userCompanyFunctions.Exists(id)) return null;

            userCompanyFunctions.Delete(id);
            return Json(true);
        }
    }
}