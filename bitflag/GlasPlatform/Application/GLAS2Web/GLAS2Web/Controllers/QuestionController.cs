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
    public class QuestionController : Controller
    {
        readonly QuestionFunctions questionFunctions;
        public QuestionController(QuestionFunctions questionFunctions)
        {
            this.questionFunctions = questionFunctions;
        }

        public async Task<IActionResult> Index() => await Task.Run(() => View());

        public async Task<IActionResult> LoadQuestionManageViewComponent(int? questionId) => await Task.Run(() => ViewComponent(typeof(ViewComponents.Question.QuestionManageViewComponent), new { questionId }));
        public async Task<IActionResult> Manage(QuestionViewModel model)
        {
            //TODO: remover o comentário das duas linhas abaixo para não deixar editar questões já vinculadas.

            //if (model.QuestionId.HasValue && !await questionFunctions.ValidateUpdate(model.QuestionId.Value))
            //return await Task.Run(() => RedirectToAction("Index", new { saved = false, alreadyUsed = true }));

            model.QuestionText = model.QuestionText.ToUpper();

            questionFunctions.CreateOrUpdate(model);

            return await Task.Run(() => RedirectToAction("Index", new { saved = true }));
        }
        public void SaveOrder(List<QuestionViewModel> models) => questionFunctions.UpdateOrder(models);

        public async Task<IActionResult> Delete(int questionId)
        {
            questionFunctions.Delete(questionId);

            return await Task.Run(() => RedirectToAction("Index", new { deleted = true }));
        }

        public async Task<IActionResult> List(DTO.Shared.DataTablesAjaxPostModel filter)
        {
            var parameters = new SqlParameterList();
            parameters.AddParameter("IsDeleted", false);

            var d = this.questionFunctions.GetDataFiltered(filter, out int recordsTotal, out int recordsFiltered, parameters.GetQuery(), parameters.GetParameters());

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
