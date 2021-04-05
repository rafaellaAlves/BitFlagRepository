using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLL.Company;
using BLL.CompanyQuestion;
using DTO.CompanyQuestion;
using GLAS2Web.Security;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace GLAS2Web.Controllers
{
    [AllowAnonymous]
    public class CompanyQuestionController : Controller
    {
        readonly CompanyFunctions companyFunctions;
        readonly CompanyUserFunctions companyUserFunctions;
        readonly CompanyViewFunctions companyViewFunctions;
        readonly CompanyQuestionChoosenAnswerFunctions companyQuestionChoosenAnswerFunctions;
        readonly CompanyQuestionChoosenAnswerItemFunctions companyQuestionChoosenAnswerItemFunctions;
        readonly UserManager<DAL.Identity.User> userManager;

        public CompanyQuestionController(CompanyFunctions companyFunctions, CompanyQuestionChoosenAnswerFunctions companyQuestionChoosenAnswerFunctions, CompanyViewFunctions companyViewFunctions, CompanyUserFunctions companyUserFunctions, CompanyQuestionChoosenAnswerItemFunctions companyQuestionChoosenAnswerItemFunctions, UserManager<DAL.Identity.User> userManager)
        {
            this.companyFunctions = companyFunctions;
            this.companyUserFunctions = companyUserFunctions;
            this.companyQuestionChoosenAnswerFunctions = companyQuestionChoosenAnswerFunctions;
            this.companyQuestionChoosenAnswerItemFunctions = companyQuestionChoosenAnswerItemFunctions;
            this.companyViewFunctions = companyViewFunctions;
            this.userManager = userManager;
        }

        public async Task<IActionResult> Index(int companyId, string companyQuestionToken = null)
        {
            if (string.IsNullOrWhiteSpace(companyQuestionToken) && !(User.IsInRole(BLL.User.ProfileNames.Administrator) || User.IsInRole(BLL.User.ProfileNames.Master)) && companyUserFunctions.UserIsInCompany((await userManager.GetUserAsync(User)).Id, companyId))
                return await Task.Run(() => Forbid());

            if (!string.IsNullOrWhiteSpace(companyQuestionToken) && !await companyFunctions.ValidateCompanyQuestionToken(companyId, companyQuestionToken))
                return await Task.Run(() => Forbid());

            return await Task.Run(() => View(companyViewFunctions.GetDataByID(companyId)));
        }

        public async Task<IActionResult> Save(List<CompanyQuestionChoosenAnswerViewModel> models, int companyId, bool finish, string companyQuestionToken)
        {
            await companyQuestionChoosenAnswerFunctions.DeleteByCompany(companyId);

            models.RemoveAll(x => x.Answers.Count(c => c != null) == 0);

            foreach (var x in models)
            {
                x.CompanyId = companyId;

                x.Answers.RemoveAll(c => c == null);

                x.CompanyQuestionChoosenAnswerId = companyQuestionChoosenAnswerFunctions.Create(x);

                x.Answers.ForEach(c => c.CompanyQuestionChoosenAnswerId = x.CompanyQuestionChoosenAnswerId);

                companyQuestionChoosenAnswerItemFunctions.CreateRange(x.Answers);
            }

            if (finish)
                await companyFunctions.UpdateEndedQuestion(companyId);

            return await Task.Run(() => RedirectToAction("Index", new { companyId, finish, companyQuestionToken }));
        }

        [AuthorizeRoles(BLL.User.ProfileNames.Administrator, BLL.User.ProfileNames.Master)]
        public async Task<IActionResult> UpdateCompanyQuestion(int companyId)
        {
            await companyFunctions.CreateCompanyQuestion(companyId);

            return await Task.Run(() => RedirectToAction("Index", new { companyId, updated = true }));
        }

        public async Task<IActionResult> LoadCompanyQuestionLawDetailViewComponent(int companyId, List<int> questionAnswerId) => await Task.Run(() => ViewComponent(typeof(ViewComponents.CompanyQuestion.CompanyQuestionLawDetailViewComponent), new { companyId, questionAnswerId }));
    }
}
