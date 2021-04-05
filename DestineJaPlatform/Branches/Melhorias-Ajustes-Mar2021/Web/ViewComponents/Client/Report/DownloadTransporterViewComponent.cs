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
    public class DownloadTransporterViewComponent : ViewComponent
    {
        private readonly ClientReportServices clientReportServices;
        private readonly ClientServices clientServices;

        public DownloadTransporterViewComponent(ClientReportServices clientReportServices, ClientServices clientServices)
        {
            this.clientReportServices = clientReportServices;
            this.clientServices = clientServices;
        }

        public async Task<IViewComponentResult> InvokeAsync(int demandId, bool loadFromController = false)
        {
            return await Task.Run(async () => View("DownloadTransporter", new EntityViewMode<List<ClientReportDownloadTransporterViewModel>>(await clientReportServices.GetClientReportDownloadTransporterViewModel(demandId, await clientServices.GetClientIdByLoggedUser(HttpContext)), loadFromController)));
        }
    }
}
