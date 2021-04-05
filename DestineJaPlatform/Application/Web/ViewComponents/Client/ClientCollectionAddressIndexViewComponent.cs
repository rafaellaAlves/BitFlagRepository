using DTO.Shared;
using Microsoft.AspNetCore.Mvc;
using Services.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.ViewComponents.Client
{
    public class ClientCollectionAddressIndexViewComponent  : ViewComponent
    {
        private readonly ClientCollectionAddressServices service;
        public ClientCollectionAddressIndexViewComponent(ClientCollectionAddressServices service)
        {
            this.service = service;
        }

        public async Task<IViewComponentResult> InvokeAsync(int clientId, ViewMode? viewMode, bool loadFromController = false) => await Task.Run(() => View(new EntityViewMode<int>(viewMode??ViewMode.Editable, clientId, loadFromController)));
    }
}
