using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLL.Company;
using BLL.EmailLog;
using BLL.Permission;
using BLL.User;
using DAL.Identity;
using DTO.EmailLog;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace GLAS2Web.Controllers
{
    [Authorize]
    public class EmailLogController : Controller
    {
        private EmailLogFunctions emailLogFunctions;
        private CompanyUserRoleFunctions companyUserRoleFunctions;
        private UserManager<User> userManager;

        public EmailLogController(EmailLogFunctions emailLogFunctions, CompanyUserRoleFunctions companyUserRoleFunctions, UserManager<User> userManager)
        {
            this.emailLogFunctions = emailLogFunctions;
            this.companyUserRoleFunctions = companyUserRoleFunctions;
            this.userManager = userManager;
        }

        public async Task<IActionResult> Index(int? companyId)
        {
            List<EmailLogViewModel> emailLogs = new List<EmailLogViewModel>();

            var user = (await userManager.GetUserAsync(User));

            var userCompany = companyUserRoleFunctions.UserCompanies(user.Id);

            if (userCompany.Count > 0)
            {
                var companyIds = userCompany.Select(x => x.CompanyId);

                emailLogs = emailLogFunctions.GetDataViewModel(emailLogFunctions.GetData(x => companyIds.Contains(x.CompanyId)).OrderByDescending(x => x.CreatedDate));
            }
            else if (User.IsInRole(ProfileNames.Administrator) || User.IsInRole(ProfileNames.Master))
            {
                if(companyId.HasValue)
                    emailLogs = emailLogFunctions.GetDataViewModel(emailLogFunctions.GetData(x => x.CompanyId == companyId.Value).OrderByDescending(x => x.CreatedDate));
                else
                    emailLogs = emailLogFunctions.GetDataViewModel(emailLogFunctions.GetData().OrderByDescending(x => x.CreatedDate));
            }

            return await Task.Run(() => View(emailLogs));
        }

        public async Task<IActionResult> LoadEmailLogInfoViewComponent(int id) => await Task.Run(() => ViewComponent(typeof(ViewComponents.EmailLog.EmailLogInfoViewComponent), new { emailLogId = id }));
    }
}
