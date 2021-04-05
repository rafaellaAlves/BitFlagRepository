using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.ViewComponents.Client
{

    [ViewComponent(Name = "ClientLicenseConditioningItem")]
    public class ClientLicenseConditioningItemIndexViewComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync(int clientLicenseConditioningId, bool loadFromController = false) => await Task.Run(() => View("Index", new DTO.Shared.EntityViewMode<int>(clientLicenseConditioningId, loadFromController)));
    }

}
