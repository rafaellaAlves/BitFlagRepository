using Microsoft.AspNetCore.Mvc;
using Services.Client;
using Services.Demand;
using Services.Home;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.ViewComponents.Home.HomeClient
{
    public class HomeClientCollectionsViewComponent : ViewComponent
    {
        private readonly ClientServices clientServices;
        private readonly HomeServices homeServices;

        public HomeClientCollectionsViewComponent(ClientServices clientServices, HomeServices homeServices)
        {
            this.clientServices = clientServices;
            this.homeServices = homeServices;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var clientId = await clientServices.GetClientIdByLoggedUser(HttpContext);

            return await Task.Run(async () => View(await homeServices.GetHomeDemandClientListViewModel(clientId)));
        }
    }
}
