using BLL.Company;
using BLL.EmailLog;
using BLL.Permission;
using DAL.Identity;
using DTO.EmailLog;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GLAS2Web.ViewComponents.EmailLog
{
    public class EmailLogInfoViewComponent : ViewComponent
    {
        private readonly EmailLogFunctions emailLogFunctions;
        private CompanyUserRoleFunctions companyUserRoleFunctions;
        private UserManager<User> userManager;

        public EmailLogInfoViewComponent(EmailLogFunctions emailLogFunctions, UserManager<User> userManager, CompanyUserRoleFunctions companyUserRoleFunctions)
        {
            this.emailLogFunctions = emailLogFunctions;
            this.userManager = userManager;
            this.companyUserRoleFunctions = companyUserRoleFunctions;
        }

        public async Task<IViewComponentResult> InvokeAsync(int emailLogId)
        {
            var emailLog = emailLogFunctions.GetDataViewModel(emailLogFunctions.GetDataByID(emailLogId));

            var user = (await userManager.GetUserAsync((System.Security.Claims.ClaimsPrincipal)User));

            var userCompany = companyUserRoleFunctions.UserCompanies(user.Id);

            if (userCompany.Count > 0)
            {
                var companyIds = userCompany.Select(x => x.CompanyId);

                if(!companyIds.Contains(emailLog.CompanyId)) return await Task.Run(() => View(new EmailLogViewModel()));
            }

            return await Task.Run(() => View(emailLog));
        }
    }
}
