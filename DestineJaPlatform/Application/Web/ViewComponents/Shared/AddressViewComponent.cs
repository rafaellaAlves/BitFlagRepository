using ApplicationDbContext.Models.Shared;
using DTO.Shared;
using DTO.Utils;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.ViewComponents.Shared
{
    public class AddressViewComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync(DTO.Shared.AddressBaseViewModel model, string formId) => await Task.Run(() => { model.FormId = formId; return View(model); });
    }
}
