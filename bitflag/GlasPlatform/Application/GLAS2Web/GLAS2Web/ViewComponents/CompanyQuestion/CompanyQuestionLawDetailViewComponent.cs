using BLL.CompanyQuestion;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GLAS2Web.ViewComponents.CompanyQuestion
{
    public class CompanyQuestionLawDetailViewComponent : ViewComponent
    {
        readonly CompanyQuestionFunctions companyQuestionFunctions;
        public CompanyQuestionLawDetailViewComponent(CompanyQuestionFunctions companyQuestionFunctions)
        {
            this.companyQuestionFunctions = companyQuestionFunctions;
        }

        public async Task<IViewComponentResult> InvokeAsync(int companyId, List<int> questionAnswerId) => await Task.Run(async () => View(await companyQuestionFunctions.GetCompanyQuestionLawDetailViewModel(companyId, questionAnswerId)));
    }
}
