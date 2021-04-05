using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AMaisImob_WEB.Utils;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AMaisImob_WEB.Controllers
{
    [Authorize(Roles = ClaimUtils.AllRolesExceptSeller)]
    public class DocuSignController : Controller
    {
        private readonly BLL.CompanyDocuSignFunctions companyDocuSignFunctions;
        private readonly BLL.CategoryFunctions categoryFunctions;
        private readonly BLL.UserCompanyFunctions userCompanyFunctions;
        private readonly BLL.CompanyFunctions companyFunctions;
        private readonly UserManager<AMaisImob_DB.Models.User> userManager;

        public DocuSignController(BLL.CompanyDocuSignFunctions companyDocuSignFunctions, UserManager<AMaisImob_DB.Models.User> userManager, BLL.CategoryFunctions categoryFunctions, BLL.UserCompanyFunctions userCompanyFunctions, BLL.CompanyFunctions companyFunctions)
        {
            this.companyDocuSignFunctions = companyDocuSignFunctions;
            this.userManager = userManager;
            this.categoryFunctions = categoryFunctions;
            this.userCompanyFunctions = userCompanyFunctions;
            this.companyFunctions = companyFunctions;
        }

        public async Task<IActionResult> Index() => await Task.Run(() => View());
        public async Task<IActionResult> LoadListViewComponent(DateTime referenceDate, int? realEstateAgencyId, int? realEstateId, int? categoryId)
        {
            if (!await ValidateUser(realEstateAgencyId, realEstateId))
                return Forbid();

            return await Task.Run(() => ViewComponent(typeof(ViewComponents.DocuSign.ListViewComponent), new { referenceDate, realEstateAgencyId, realEstateId, categoryId, cutScript = false }));
        }

        public async Task<IActionResult> SaveCompanyDocuSign(int? docuSignId, int companyId, int amount, DateTime referenceDate)
        {
            if (!User.IsInRole("Administrator"))
                return Forbid();

            var data = (await companyDocuSignFunctions.GetDataByDate(referenceDate, null, companyId, null)).First(); //Uma imobiliria não tem como aparecer duas vezes no mesmo mês de referencia
            var userId = (await userManager.GetUserAsync(User)).Id;
            var vipCategoryId = (await categoryFunctions.GetDataAsNoTracking(x => x.ExternalCode == "VIP").FirstAsync()).CategoryId;

            if (!docuSignId.HasValue)
                companyDocuSignFunctions.TryDelete(companyId, referenceDate);

            var totalPrice = data.Price * amount;
            if (vipCategoryId == data.CategoryId)
            {
                if (amount < 10) totalPrice = 0;
                else totalPrice = data.Price * (amount - 10);
            }

            return await Task.Run(() => Json(new
            {
                companyDocuSignId = companyDocuSignFunctions.CreateOrUpdate(new Models.CompanyDocuSignViewModel
                {
                    CompanyDocuSignId = docuSignId,
                    Amount = amount,
                    Price = data.Price,
                    ReferenceDate = referenceDate,
                    CategoryId = data.CategoryId,
                    CreatedBy = userId,
                    CompanyId = companyId
                }),
                TotalPrice = totalPrice.ToPtBR()
            }));
        }

        private async Task<bool> ValidateUser(int? realEstateAgencyId, int? realEstateId)
        {
            if (User.IsInRole("Administrator")) return true;

            var userId = (await userManager.GetUserAsync(User)).Id;
            var companyUser = userCompanyFunctions.GetDataByUserId(userId).FirstOrDefault();

            if (User.IsInRole("Corretor"))
            {
                if (realEstateAgencyId.HasValue && companyUser.CompanyId != realEstateAgencyId)
                    return false;

                if (realEstateId.HasValue)
                {
                    var realState = companyFunctions.GetDataByID(realEstateId);

                    if (realState.ParentCompanyId != companyUser.CompanyId) // verifica se o corretor tem acesso a imobiliria informada
                        return false;
                }
            }
            else if (!realEstateId.HasValue || companyUser.CompanyId != realEstateId)
                return false;

            return true;
        }
    }
}
