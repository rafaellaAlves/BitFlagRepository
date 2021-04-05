using BLL.CompanyQuestion;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GLAS2Web.ViewComponents.CompanyQuestion
{
    public class CompanyQuestionViewComponent : ViewComponent
    {
        readonly CompanyQuestionFunctions companyQuestionFunctions;
        public CompanyQuestionViewComponent(CompanyQuestionFunctions companyQuestionFunctions)
        {
            this.companyQuestionFunctions = companyQuestionFunctions;
        }

        public async Task<IViewComponentResult> InvokeAsync(int companyId) => await Task.Run(async () => View(await companyQuestionFunctions.GetCompanyQuestionAnswers(companyId)));
    }
}
