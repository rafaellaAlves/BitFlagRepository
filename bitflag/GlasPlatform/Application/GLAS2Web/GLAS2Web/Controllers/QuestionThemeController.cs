using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLL.Question;
using DTO.Question;
using GLAS2Web.Security;
using Microsoft.AspNetCore.Mvc;

namespace GLAS2Web.Controllers
{
    [AuthorizeRoles(BLL.User.ProfileNames.Administrator, BLL.User.ProfileNames.Master)]
    public class QuestionThemeController : Controller
    {
        readonly QuestionThemeFunctions questionThemeFunctions;
        public QuestionThemeController(QuestionThemeFunctions questionThemeFunctions)
        {
            this.questionThemeFunctions = questionThemeFunctions;
        }

        public async Task<IActionResult> Index() => await Task.Run(() => View());

        public async Task<IActionResult> LoadQuestionThemeManageViewComponent(int? questionThemeId) => await Task.Run(() => ViewComponent(typeof(ViewComponents.Question.QuestionThemeManageViewComponent), new { questionThemeId }));
        public async Task<IActionResult> Manage(QuestionThemeViewModel model)
        {
            //** task 70 permitir alterar temas e  subtemas, mesmo que ele já faça parte do questionário
            //if (model.QuestionThemeId.HasValue && !await questionThemeFunctions.ValidateUpdate(model.QuestionThemeId.Value))
            //    return await Task.Run(() => Json(new { success = false, message = "Não é possível alterar este tema por que ele já foi utilizado em um questionário." }));

            model.Name = model.Name.ToUpper();
            questionThemeFunctions.CreateOrUpdate(model);

            return await Task.Run(() => Json(new { success = true }));

        }
        public void Delete(int questionThemeId) => questionThemeFunctions.Delete(questionThemeId);

        public async Task<IActionResult> List(DTO.Shared.DataTablesAjaxPostModel filter)
        {
            var d = this.questionThemeFunctions.GetDataFiltered(filter, out int recordsTotal, out int recordsFiltered, "IsDeleted = 0", whereParameter: null);

            return await Task.Run(() => Json(new
            {
                draw = filter.draw,
                recordsTotal = recordsTotal,
                recordsFiltered = recordsFiltered,
                data = d
            }));
        }
    }
}
