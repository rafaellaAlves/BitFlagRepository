using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLL.Question;
using DTO.Question;
using GLAS2Web.Models.Shared;
using GLAS2Web.Security;
using Microsoft.AspNetCore.Mvc;

namespace GLAS2Web.Controllers
{
    [AuthorizeRoles(BLL.User.ProfileNames.Administrator, BLL.User.ProfileNames.Master)]
    public class QuestionSubThemeController : Controller
    {
        readonly QuestionSubThemeFunctions questionSubThemeFunctions;
        readonly QuestionSubThemeListFunctions questionSubThemeListFunctions;
        public QuestionSubThemeController(QuestionSubThemeFunctions questionSubThemeFunctions, QuestionSubThemeListFunctions questionSubThemeListFunctions)
        {
            this.questionSubThemeFunctions = questionSubThemeFunctions;
            this.questionSubThemeListFunctions = questionSubThemeListFunctions;
        }

        public async Task<IActionResult> Index(int questionThemeId) => await Task.Run(() => View(questionThemeId));
        public async Task<IActionResult> LoadQuestionSubThemeManageViewComponent(int questionThemeId, int? questionSubThemeId, bool onlyView = false) => await Task.Run(() => ViewComponent(typeof(ViewComponents.Question.QuestionSubThemeManageViewComponent), new { questionThemeId, questionSubThemeId, onlyView }));

        public async Task<IActionResult> Manage(QuestionSubThemeViewModel model)
        {
            //** task 70 permitir alterar temas e  subtemas, mesmo que ele já faça parte do questionário

            //if(model.QuestionSubThemeId.HasValue && !await questionSubThemeFunctions.ValidateUpdate(model.QuestionSubThemeId.Value))
            //    return await Task.Run(() => Json(new { success= false, message = "Não é possível alterar este subtema por que ele já foi utilizado em um questionário." }));

            model.Name = model.Name.ToUpper();
            model.Cause = model.Cause.ToUpper();
            model.Effect = model.Effect.ToUpper();
            model.Control = model.Control.ToUpper();

            questionSubThemeFunctions.CreateOrUpdate(model);

            return await Task.Run(() => Json(new { success = true }));
        }
        public void Delete(int questionSubThemeId) => questionSubThemeFunctions.Delete(questionSubThemeId);

        public async Task<IActionResult> List(DTO.Shared.DataTablesAjaxPostModel filter, int questionThemeId)
        {
            var parameters = new SqlParameterList();
            parameters.AddParameter("IsDeleted", false);
            parameters.AddParameter("QuestionThemeIsDeleted", false);
            parameters.AddParameter("QuestionThemeId", questionThemeId);

            var d = this.questionSubThemeListFunctions.GetDataFiltered(filter, out int recordsTotal, out int recordsFiltered, parameters.GetQuery(), parameters.GetParameters());

            return await Task.Run(() => Json(new
            {
                draw = filter.draw,
                recordsTotal = recordsTotal,
                recordsFiltered = recordsFiltered,
                data = d
            }));
        }

        public async Task<IActionResult> GetDataByTheme(int questionThemeId) => await Task.Run(() => Json(questionSubThemeFunctions.GetDataAsNoTracking(x => x.QuestionThemeId == questionThemeId && !x.IsDeleted)));
    }
}