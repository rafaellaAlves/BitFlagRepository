using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace AMaisImob_WEB.ViewComponents.ContractualGuarantee
{
    public class ContractualGuaranteeIndexViewComponent : ViewComponent
    {
            public async Task<IViewComponentResult> InvokeAsync(int statusId) => await Task.Run(() => View(statusId));
    }
}
