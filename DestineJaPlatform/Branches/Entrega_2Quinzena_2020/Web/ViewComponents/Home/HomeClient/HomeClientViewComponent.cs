using DTO.Home;
using DTO.Shared;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.Client;
using Services.Contract;
using Services.Home;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Threading.Tasks;

namespace Web.ViewComponents.Home
{
    public class HomeClientViewComponent : ViewComponent
    {
        private readonly ContractServices contractServices;
        private readonly ClientServices clientServices;
        private readonly HomeServices homeServices;

        public HomeClientViewComponent(ContractServices contractServices, ClientServices clientServices, HomeServices homeServices)
        {
            this.contractServices = contractServices;
            this.clientServices = clientServices;
            this.homeServices = homeServices;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var clientId = await clientServices.GetClientIdByLoggedUser(HttpContext);
            var contract = await contractServices.GetContractByClient(clientId);

            var viewModel = new HomeClientViewModel();

            if (contract != null)
            {
                viewModel = await homeServices.GetHomeClientViewModel(clientId);
            }

            return await Task.Run(() => View(viewModel));
        }
    }
}
