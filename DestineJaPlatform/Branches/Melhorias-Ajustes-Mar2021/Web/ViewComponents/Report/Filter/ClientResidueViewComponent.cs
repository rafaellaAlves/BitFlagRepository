using DTO.Shared;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.ViewComponents.Report.Filter
{

    [ViewComponent(Name = "Report\\Filter")]
    public class ClientResidueViewComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync(int? clientId)
        {
            return await Task.Run(() => View("ClientResidue", clientId));
        }
    }
}
