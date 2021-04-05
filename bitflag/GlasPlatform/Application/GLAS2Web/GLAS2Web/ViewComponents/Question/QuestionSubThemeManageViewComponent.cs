using BLL.Question;
using DTO.Question;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GLAS2Web.ViewComponents.Question
{
    public class QuestionSubThemeManageViewComponent : ViewComponent
    {
        readonly QuestionSubThemeFunctions questionSubThemeFunctions;

        public QuestionSubThemeManageViewComponent(QuestionSubThemeFunctions questionSubThemeFunctions)
        {
            this.questionSubThemeFunctions = questionSubThemeFunctions;
        }

        public async Task<IViewComponentResult> InvokeAsync(int questionThemeId, int? questionSubThemeId, bool onlyView = false)
        {
            ViewBag.OnlyView = onlyView;

            return await Task.Run(() => View(questionSubThemeId.HasValue ? questionSubThemeFunctions.GetDataViewModel(questionSubThemeFunctions.GetDataByID(questionSubThemeId)) : new QuestionSubThemeViewModel() { QuestionThemeId = questionThemeId }));
        }
    }
}
