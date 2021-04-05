using DTO.Shared;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.ViewComponents.Service
{
    public class ServiceIndexViewComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync(int? clientId, ViewMode viewMode = ViewMode.Editable) => await Task.Run(() => View(new DTO.Shared.EntityViewMode<int?>(viewMode, clientId)));
    }
}
