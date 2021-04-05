using DTO.Client;
using Microsoft.AspNetCore.Mvc;
using Services.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.ViewComponents.Client
{
    [ViewComponent(Name = "ClientLicenseConditioning")]
    public class ClientLicenseConditioningManageViewComponent : ViewComponent
    {
        private ClientLicenseConditioningService clientLicenseConditioningService;

        public ClientLicenseConditioningManageViewComponent(ClientLicenseConditioningService clientLicenseConditioningService)
        {
            this.clientLicenseConditioningService = clientLicenseConditioningService;
        }

        public async Task<IViewComponentResult> InvokeAsync(int? clientLicenseConditioningId, int clientLicenseId, bool loadFromController = false) => await Task.Run(async () => View("Manage", new DTO.Shared.EntityViewMode<ClientLicenseConditioningViewModel>(clientLicenseConditioningId.HasValue ? await clientLicenseConditioningService.GetViewModelByIdAsync(clientLicenseConditioningId.Value) : new ClientLicenseConditioningViewModel() { ClientLicenseId = clientLicenseId }, loadFromController)));
    }
}