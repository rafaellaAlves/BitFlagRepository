using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WEB.Utils;

namespace WEB.ViewComponents.Report
{
    public class ReportIndexViewComponent : ViewComponent
    {
        private readonly UserManager<DB.Models.AspNetUser> userManager;
        private readonly BLL.UserCompanyFunctions userCompanyFunctions;
        private readonly BLL.CompanyFunctions companyFunctions;

        public ReportIndexViewComponent(UserManager<DB.Models.AspNetUser> userManager, BLL.UserCompanyFunctions userCompanyFunctions, BLL.CompanyFunctions companyFunctions)
        {
            this.userManager = userManager;
            this.userCompanyFunctions = userCompanyFunctions;
            this.companyFunctions = companyFunctions;
        }

        public async Task<IViewComponentResult> InvokeAsync(int status)
        {
            if (User.IsInRole("Corretor"))
            {
                var user = await userManager.GetUserAsync(HttpContext.User);
                var companyUser = userCompanyFunctions.GetDataByUserId(user.Id).FirstOrDefault();

                if (companyUser != null)
                {
                    ViewData["UserRealEstateAgencyId"] = companyUser.CompanyId;


                }
            }
            else if (HttpContext.User.IsInRealEstate())
            {
                var user = await userManager.GetUserAsync(HttpContext.User);
                var companyUser = userCompanyFunctions.GetDataByUserId(user.Id).FirstOrDefault();

                if (companyUser != null)
                {
                    var userRealEstateAgencyId = companyFunctions.GetDataByID(companyUser.CompanyId).ParentCompanyId;

                    ViewData["UserRealEstateAgencyId"] = userRealEstateAgencyId;
                    ViewData["UserRealEstateId"] = companyUser.CompanyId;
                }
            }

            return await Task.Run(() => View(status));
        }
    }
}
