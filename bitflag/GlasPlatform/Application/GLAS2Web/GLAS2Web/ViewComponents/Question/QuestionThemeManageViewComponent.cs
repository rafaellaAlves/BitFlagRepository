using BLL.Question;
using DTO.Question;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GLAS2Web.ViewComponents.Question
{
    public class QuestionThemeManageViewComponent : ViewComponent
    {
        readonly QuestionThemeFunctions questionThemeFunctions;

        public QuestionThemeManageViewComponent(QuestionThemeFunctions questionThemeFunctions)
        {
            this.questionThemeFunctions = questionThemeFunctions;
        }

        public async Task<IViewComponentResult> InvokeAsync(int? questionThemeId) => await Task.Run(() => View(questionThemeId.HasValue? questionThemeFunctions.GetDataViewModel(questionThemeFunctions.GetDataByID(questionThemeId)) : new QuestionThemeViewModel()));
    }
}
