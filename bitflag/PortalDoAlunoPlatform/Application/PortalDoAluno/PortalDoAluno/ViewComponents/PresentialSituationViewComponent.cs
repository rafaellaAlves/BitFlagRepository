using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Web.ViewComponents
{
    public class PresentialSituationViewComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync(int classStudentId) => await Task.Run(() => View(classStudentId));
    }
}


