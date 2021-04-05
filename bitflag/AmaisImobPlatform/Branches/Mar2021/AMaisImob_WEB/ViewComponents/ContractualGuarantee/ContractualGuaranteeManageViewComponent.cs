using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AMaisImob_WEB.ViewComponents.ContractualGuarantee
{
    
        public class ContractualGuaranteeManageViewComponent : ViewComponent
        {

            public ContractualGuaranteeManageViewComponent()
            {
            }

            public async Task<IViewComponentResult> InvokeAsync(AMaisImob_WEB.Models.CertificateContractualViewModel model) => await Task.Run(() => View(model));

        }
    
}
