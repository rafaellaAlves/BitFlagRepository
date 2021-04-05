using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace AMaisImob_WEB.ViewComponents.Company
{
    public class CompanyAcceptTermViewComponent : ViewComponent
    {
        private readonly BLL.CompanyFunctions companyFunctions;

        public CompanyAcceptTermViewComponent(BLL.CompanyFunctions companyFunctions)
        {
            this.companyFunctions = companyFunctions;
        }

        public async Task<IViewComponentResult> InvokeAsync(int companyId) => await Task.Run(() => View(companyFunctions.GetDataViewModel(companyFunctions.GetDataByID(companyId))));
    }
}
