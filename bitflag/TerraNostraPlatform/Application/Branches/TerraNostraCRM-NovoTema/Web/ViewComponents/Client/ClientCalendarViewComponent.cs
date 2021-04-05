using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.ViewComponents.Client
{
    public class ClientCalendarViewComponent : ViewComponent
    {
        private readonly FUNCTIONS.Client.ClientFunctions clientFunctions;

        public ClientCalendarViewComponent(FUNCTIONS.Client.ClientFunctions clientFunctions)
        {
            this.clientFunctions = clientFunctions;
        }

        public IViewComponentResult Invoke(int? ClientId, int? clientTaskId)
        {
            ViewBag.ClientTaskId = clientTaskId;

            return View(ClientId.HasValue ? (object)clientFunctions.GetDataByID(ClientId) : null);
        }
    }
}
