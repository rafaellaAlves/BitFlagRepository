using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GLAS2Web.Security
{
    public class UserManagesAnyCompany : AuthorizationHandler<CompanyManagementRequirement>
    {
        private DAL.GLAS2Context context;
        private BLL.Permission.CompanyUserRoleFunctions companyUserRoleFunctions;
        private UserManager<DAL.Identity.User> userManager;
        public UserManagesAnyCompany(DAL.GLAS2Context context, UserManager<DAL.Identity.User> userManager)
        {
            this.context = context;
            this.companyUserRoleFunctions = new BLL.Permission.CompanyUserRoleFunctions(context);
            this.userManager = userManager;
        }

        protected override async Task HandleRequirementAsync(AuthorizationHandlerContext context, CompanyManagementRequirement requirement)
        {
            if (context.User.IsInRole(BLL.User.ProfileNames.Administrator) || context.User.IsInRole(BLL.User.ProfileNames.Master)) context.Succeed(requirement);

            var user = await userManager.GetUserAsync(context.User);
            if (companyUserRoleFunctions.UserHasCompanyRole(user.Id, requirement.Roles)) context.Succeed(requirement);
        }
    }
}
