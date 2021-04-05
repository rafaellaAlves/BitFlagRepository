using BLL.Question;
using DTO.Question;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GLAS2Web.ViewComponents.Question
{
    public class QuestionManageViewComponent : ViewComponent
    {
        readonly QuestionFunctions questionFunctions;

        public QuestionManageViewComponent(QuestionFunctions questionFunctions)
        {
            this.questionFunctions = questionFunctions;
        }

        public async Task<IViewComponentResult> InvokeAsync(int? questionId) => await Task.Run(() => View(questionId.HasValue ? questionFunctions.GetDataViewModel(questionFunctions.GetDataByID(questionId)) : new QuestionViewModel()));
    }
}
