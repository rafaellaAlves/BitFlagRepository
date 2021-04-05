using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.ViewComponents.Client
{
    public class ClientDependentsManageViewComponent : ViewComponent
    {
        private readonly FUNCTIONS.Client.ClientDependentFunctions clientDependentFunctions;

        public ClientDependentsManageViewComponent(FUNCTIONS.Client.ClientDependentFunctions clientDependentFunctions)
        {
            this.clientDependentFunctions = clientDependentFunctions;
        }

        public IViewComponentResult Invoke(int? clientDependentId, int clientId)
        {
            var model = new DTO.Client.ClientDependentViewModel();
            model.ClientId = clientId;

            if (!clientDependentId.HasValue) return View(model);

            return View(clientDependentFunctions.GetDataViewModel(clientDependentFunctions.GetDataByID(clientDependentId)));
        }
    }
}
