using Microsoft.AspNetCore.Mvc;
using Services.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.ViewComponents.Client
{
    public class ClientContactIndexViewComponent : ViewComponent
    {
        private readonly ClientContactServices service;
        public ClientContactIndexViewComponent(ClientContactServices service)
        {
            this.service = service;
        }

        public async Task<IViewComponentResult> InvokeAsync(int clientId) => await Task.Run(() => View(clientId));
    }
}
