using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.ViewComponents.Shared
{
    public class CompanyViewComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync(DTO.Shared.CompanyBaseViewModel model) => await Task.Run(() => View(model));
    }
}
