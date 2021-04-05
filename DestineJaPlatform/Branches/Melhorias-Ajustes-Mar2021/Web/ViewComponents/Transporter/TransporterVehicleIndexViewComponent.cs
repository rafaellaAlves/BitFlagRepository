using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.ViewComponents.Transporter
{
    public class TransporterVehicleIndexViewComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync(int transporterId) => await Task.Run(() => View(transporterId));
    }
}
