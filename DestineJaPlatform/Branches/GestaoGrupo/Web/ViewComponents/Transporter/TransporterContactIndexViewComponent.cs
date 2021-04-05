using Microsoft.AspNetCore.Mvc;
using Services.Transporter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.ViewComponents.Transporter
{
    public class TransporterContactIndexViewComponent : ViewComponent
    {
        private readonly TransporterContactServices service;
        public TransporterContactIndexViewComponent(TransporterContactServices service)
        {
            this.service = service;
        }

        public async Task<IViewComponentResult> InvokeAsync(int transporterId) => await Task.Run(() =>
        View(transporterId));
    }
}
