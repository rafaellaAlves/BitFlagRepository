using DTO.Shared;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.ViewComponents
{
    public class ContractIndexViewComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync(int? clientId, ViewMode viewMode = ViewMode.Editable) => await Task.Run(() => View(new EntityViewMode<int?>(viewMode, clientId)));
    }
}

