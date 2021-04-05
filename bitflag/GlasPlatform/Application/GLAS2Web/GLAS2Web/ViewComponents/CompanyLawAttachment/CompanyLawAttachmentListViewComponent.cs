using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GLAS2Web.ViewComponents.CompanyLawAttachment
{
    public class CompanyLawAttachmentListViewComponent : ViewComponent
    {
        private readonly BLL.Company.CompanyLawAttachmentFunctions companyLawAttachmentFunctions;

        public CompanyLawAttachmentListViewComponent(BLL.Company.CompanyLawAttachmentFunctions companyLawAttachmentFunctions)
        {
            this.companyLawAttachmentFunctions = companyLawAttachmentFunctions;
        }

        public async Task<IViewComponentResult> InvokeAsync(int companyLawId) => await Task.Run(() => View(companyLawId));

    }
}
