using DTO.Client;
using DTO.Shared;
using Microsoft.AspNetCore.Mvc;
using Services.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.ViewComponents.Client
{
    [ViewComponent(Name = "ClientLicense")]
    public class ClientLicenseManageViewComponent : ViewComponent
    {
        private readonly ClientLicenseServices clientLicenseServices;

        public ClientLicenseManageViewComponent(ClientLicenseServices clientLicenseServices)
        {
            this.clientLicenseServices = clientLicenseServices;
        }
        public async Task<IViewComponentResult> InvokeAsync(int? clientLicenseId, bool loadFromController = false) => await Task.Run(async () => View("Manage", new EntityViewMode<ClientLicenseViewModel>(clientLicenseId.HasValue ? await clientLicenseServices.GetViewModelByIdAsync(clientLicenseId.Value) : new DTO.Client.ClientLicenseViewModel(), loadFromController)));
    }
}
