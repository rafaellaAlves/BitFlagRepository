using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.ViewComponents.Client
{
    [ViewComponent(Name = "ClientLicenseConditioning")]
    public class ClientLicenseConditioningIndexViewComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync(int clientLicense) => await Task.Run(() => View("Index", clientLicense));
    }
}
