using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Identity;
using GLAS2Web.Security;

namespace GLAS2Web.Controllers
{
    [AuthorizeRoles(BLL.User.ProfileNames.Administrator, BLL.User.ProfileNames.Master, BLL.User.ProfileNames.Biotera, BLL.User.ProfileNames.Cliente)]
    public class HomeController : Controller
    {
        private readonly BLL.Company.CompanyFunctions company;
        private readonly BLL.Company.CompanyUserFunctions companyUser;
        private readonly BLL.Company.CompanyLawFunctions companyLawFunctions;
        private readonly BLL.Company.CompanyLawUserViewFunctions companyLawUserViewFunctions;
        private readonly BLL.Permission.CompanyUserRoleFunctions companyUserRoleFunctions;
        private readonly BLL.DB.Utils utils;
        private readonly UserManager<DAL.Identity.User> userManager;

        public HomeController(DAL.GLAS2Context context, UserManager<DAL.Identity.User> userManager)
        {
            this.company = new BLL.Company.CompanyFunctions(context);
            this.companyUser = new BLL.Company.CompanyUserFunctions(context);
            this.companyLawFunctions = new BLL.Company.CompanyLawFunctions(context);
            this.companyLawUserViewFunctions = new BLL.Company.CompanyLawUserViewFunctions(context);
            this.companyUserRoleFunctions = new BLL.Permission.CompanyUserRoleFunctions(context);
            this.utils = new BLL.DB.Utils(context);
            this.userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            var user = await this.userManager.GetUserAsync(User);

            if (User.IsInRole(BLL.User.ProfileNames.Administrator) || User.IsInRole(BLL.User.ProfileNames.Master))
                return View(company.GetDataViewModel(company.GetData(x => x.IsDeleted == false).OrderBy(x => x.NomeFantasia)));

            return View(this.companyUserRoleFunctions.UserCompanies(user.Id));
        }

        public async Task<IActionResult> Dashboard(int? companyId)
        {
            if (!company.Exists(companyId)) return NotFound();
            var user = await this.userManager.GetUserAsync(User);

            if (!await CanViewCompany(companyId.Value)) return Forbid();

            ViewData["CompanyLawUserViewCount"] = companyLawFunctions.GetCompanyLawUserViewCount(user.Id, companyId.Value);
            ViewData["Company"] = company.GetDataViewModel(company.GetDataByID(companyId));

            return View();
        }

        public async Task<string> GetKPI1(int? companyId)
        {
            if (!await CanViewCompany(companyId.Value)) return null;
            return J‌​sonConvert.Serialize‌​Object(this.utils.GetData("KPI1", new System.Data.SqlClient.SqlParameter[] { new System.Data.SqlClient.SqlParameter("@CompanyId", companyId) }));
        }

        public async Task<string> GetKPI2(int? companyId)
        {
            if (!await CanViewCompany(companyId.Value)) return null;
            return J‌​sonConvert.Serialize‌​Object(this.utils.GetData("KPI2", new System.Data.SqlClient.SqlParameter[] { new System.Data.SqlClient.SqlParameter("@CompanyId", companyId) }));
        }

        public async Task<string> GetKPI3(int? companyId)
        {
            if (!await CanViewCompany(companyId.Value)) return null;
            return J‌​sonConvert.Serialize‌​Object(this.utils.GetData("KPI3", new System.Data.SqlClient.SqlParameter[] { new System.Data.SqlClient.SqlParameter("@CompanyId", companyId) }));
        }

        public async Task<string> GetKPI4(int? companyId)
        {
            if (!await CanViewCompany(companyId.Value)) return null;
            return J‌​sonConvert.Serialize‌​Object(this.utils.GetData("KPI4", new System.Data.SqlClient.SqlParameter[] { new System.Data.SqlClient.SqlParameter("@CompanyId", companyId) }));
        }

        private async Task<bool> CanViewCompany(int companyId)
        {
            var user = await this.userManager.GetUserAsync(User);

            if (User.IsInRole(BLL.User.ProfileNames.Administrator) || User.IsInRole(BLL.User.ProfileNames.Master)) return true;
            if (this.companyUserRoleFunctions.UserIsInCompany(companyId, user.Id)) return true;

            return false;
        }
    }
}