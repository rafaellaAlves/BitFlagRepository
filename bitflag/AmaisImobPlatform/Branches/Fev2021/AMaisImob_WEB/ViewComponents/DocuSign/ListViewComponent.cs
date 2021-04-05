using AMaisImob_WEB.Models;
using AMaisImob_WEB.Models.Shared;
using AMaisImob_WEB.Utils;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AMaisImob_WEB.ViewComponents.DocuSign
{
    [ViewComponent(Name = "DocuSign")]
    public class ListViewComponent : ViewComponent
    {
        private readonly BLL.CompanyDocuSignFunctions companyDocuSignFunctions;
        private readonly UserManager<AMaisImob_DB.Models.User> userManager;
        private readonly BLL.UserCompanyFunctions userCompanyFunctions;

        public ListViewComponent(BLL.CompanyDocuSignFunctions companyDocuSignFunctions, UserManager<AMaisImob_DB.Models.User> userManager, BLL.UserCompanyFunctions userCompanyFunctions)
        {
            this.companyDocuSignFunctions = companyDocuSignFunctions;
            this.userManager = userManager;
            this.userCompanyFunctions = userCompanyFunctions;
        }

        public async Task<IViewComponentResult> InvokeAsync(DateTime referenceDate, int? realEstateAgencyId, int? realEstateId, int? categoryId, bool cutScript = true)
        {
            if (User.IsInRole("Corretor") && !realEstateAgencyId.HasValue)
            {
                var userId = (await userManager.GetUserAsync(HttpContext.User)).Id;
                var companyUser = userCompanyFunctions.GetDataByUserId(userId).FirstOrDefault();

                realEstateAgencyId = companyUser.CompanyId;
            }
            if (HttpContext.User.IsInRealEstate() && !realEstateId.HasValue)
            {
                var userId = (await userManager.GetUserAsync(HttpContext.User)).Id;
                var companyUser = userCompanyFunctions.GetDataByUserId(userId).FirstOrDefault();

                realEstateId = companyUser.CompanyId;
            }

            return await Task.Run(async () => View("List", new BaseViewModel<List<CompanyDocuSignViewModel>>(await companyDocuSignFunctions.GetDataByDate(referenceDate, realEstateAgencyId, realEstateId, categoryId), cutScript)));
        }
    }
}
