using BLL.Question;
using DTO.Question;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GLAS2Web.ViewComponents.Question
{
    public class QuestionAnswerManageViewComponent : ViewComponent
    {
        readonly QuestionAnswerFunctions questionAnswerFunctions;

        public QuestionAnswerManageViewComponent(QuestionAnswerFunctions questionAnswerFunctions)
        {
            this.questionAnswerFunctions = questionAnswerFunctions;
        }

        public async Task<IViewComponentResult> InvokeAsync(int questionId, int? questionAnswerId) => await Task.Run(() => View(questionAnswerId.HasValue? questionAnswerFunctions.GetDataViewModel(questionAnswerFunctions.GetDataByID(questionAnswerId)) : new QuestionAnswerViewModel() { QuestionId = questionId }));
    }
}
