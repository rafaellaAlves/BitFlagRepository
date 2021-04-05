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
    public class QuestionAnswerController : Controller
    {
        readonly QuestionAnswerFunctions questionAnswerFunctions;
        public QuestionAnswerController(QuestionAnswerFunctions questionAnswerFunctions)
        {
            this.questionAnswerFunctions = questionAnswerFunctions;
        }

        public async Task<IActionResult> Index(int questionId) => await Task.Run(() => View(questionId));
        public async Task<IActionResult> LoadQuestionAnswerManageViewComponent(int questionId, int? questionAnswerId) => await Task.Run(() => ViewComponent(typeof(ViewComponents.Question.QuestionAnswerManageViewComponent), new { questionId, questionAnswerId }));
        public async Task<IActionResult> Manage(QuestionAnswerViewModel model)
        {

            //***Ticket 69 Permitir alterar as respostas, mesmo que ele já faça parte do questionário

            //if (model.QuestionAnswerId.HasValue && !await questionAnswerFunctions.ValidateUpdate(model.QuestionAnswerId.Value))
            //return await Task.Run(() => RedirectToAction("Index", new { questionId = model.QuestionId, saved = false, alreadyUsed = true }));

            model.Answer = model.Answer.ToUpper();

            questionAnswerFunctions.CreateOrUpdate(model);

            return await Task.Run(() => RedirectToAction("Index", new { questionId = model.QuestionId, saved = true }));
        }

        public void SaveOrder(List<QuestionAnswerViewModel> models) => questionAnswerFunctions.UpdateOrder(models);

        public async Task<IActionResult> Delete(int questionAnswerId)
        {
            var entity = questionAnswerFunctions.GetDataByID(questionAnswerId);
            questionAnswerFunctions.Delete(questionAnswerId);

            return await Task.Run(() => RedirectToAction("Index", new { questionId = entity.QuestionId, deleted = true }));
        }
    }
}
