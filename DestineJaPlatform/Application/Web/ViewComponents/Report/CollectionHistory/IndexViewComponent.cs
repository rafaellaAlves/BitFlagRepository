using DTO.Client.Report;
using DTO.Shared;
using Microsoft.AspNetCore.Mvc;
using Services.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.ViewComponents.Report.CollectionHistory
{
    [ViewComponent(Name = "Report\\CollectionHistory")]
    public class IndexViewComponent : ViewComponent
    {
        private readonly ClientReportServices clientReportServices;
        private readonly ClientServices clientServices;

        public IndexViewComponent(ClientReportServices clientReportServices, ClientServices clientServices)
        {
            this.clientReportServices = clientReportServices;
            this.clientServices = clientServices;
        }

        public async Task<IViewComponentResult> InvokeAsync(bool loadFromController = false, DateTime? startDate = null, DateTime? endDate = null, int? clientId = null)
        {
            if (User.IsInRole("Administrator"))
                return await Task.Run(async () => View("Index", new EntityViewMode<List<ClientReportCollectionHistoryViewModel>>(await clientReportServices.GetClientReportCollectionHistoryViewModel(clientId, startDate, endDate), loadFromController)));

            return await Task.Run(async () => View("Index", new EntityViewMode<List<ClientReportCollectionHistoryViewModel>>(await clientReportServices.GetClientReportCollectionHistoryViewModel(await clientServices.GetClientIdByLoggedUser(HttpContext), startDate, endDate), loadFromController)));
        }
    }
}
