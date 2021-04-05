using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AMaisImob_WEB.ViewComponents.Assistance
{
    public class AssistanceReportViewComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync() => await Task.Run(() => View());
    }
}
