using DTO.Client.Report;
using DTO.DemandDestination;
using DTO.Shared;
using Microsoft.AspNetCore.Mvc;
using Services.Client;
using Services.DemandDestination;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.ViewComponents.Client.Report
{
    [ViewComponent(Name = "ClientReports")]
    public class DownloadDestinationViewComponent : ViewComponent
    {
        private readonly ClientReportServices clientReportServices;

        public DownloadDestinationViewComponent(ClientReportServices clientReportServices)
        {
            this.clientReportServices = clientReportServices;
        }

        public async Task<IViewComponentResult> InvokeAsync(int demandId, bool loadFromController = false)
        {
            return await Task.Run(async () => View("DownloadDestination", new EntityViewMode<List<ClientReportDownloadDestinationViewModel>>(await clientReportServices.GetClientReportDownloadDestinationViewModel(demandId), loadFromController)));
        }
    }
}
