using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.ViewComponents.Client
{
    public class ClientDependentsViewComponent : ViewComponent
    { 
        private readonly FUNCTIONS.Client.ClientDependentFunctions clientDependentFunctions;

        public ClientDependentsViewComponent(FUNCTIONS.Client.ClientDependentFunctions clientDependentFunctions)
        {
            this.clientDependentFunctions = clientDependentFunctions;
        }

        public IViewComponentResult Invoke(int clientId)
        {
            ViewBag.ClientId = clientId;

            return View(clientDependentFunctions.GetDataByClient(clientId));
        }
    }
}
