using DTO.Client.Report;
using DTO.Shared;
using Microsoft.AspNetCore.Mvc;
using Services.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.ViewComponents.Client.Report
{
    [ViewComponent(Name = "ClientReports")]
    public class DownloadViewComponent : ViewComponent
    {
        private readonly ClientReportServices clientReportServices;
        private readonly ClientServices clientServices;

        public DownloadViewComponent(ClientReportServices clientReportServices, ClientServices clientServices)
        {
            this.clientReportServices = clientReportServices;
            this.clientServices = clientServices;
        }

        public async Task<IViewComponentResult> InvokeAsync(bool loadFromController = false) => await Task.Run(async () => View("Download", new EntityViewMode<List<ClientReportDownloadViewModel>>(await clientReportServices.GetClientReportDownloadViewModel(await clientServices.GetClientIdByLoggedUser(HttpContext)), loadFromController)));
    }
}