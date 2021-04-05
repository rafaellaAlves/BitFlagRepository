using DTO.Client.Report;
using DTO.Shared;
using Microsoft.AspNetCore.Mvc;
using Services.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.ViewComponents.Report.PGRS
{
    [ViewComponent(Name = "Report\\PGRS")]
    public class IndexViewComponent : ViewComponent
    {
        private readonly ClientReportServices clientReportServices;
        private readonly ClientServices clientServices;

        public IndexViewComponent(ClientReportServices clientReportServices, ClientServices clientServices)
        {
            this.clientReportServices = clientReportServices;
            this.clientServices = clientServices;
        }

        public async Task<IViewComponentResult> InvokeAsync(bool loadFromController = false, DateTime? startDate = null, DateTime? endDate = null, int? unitOfMeasurementId = null, int? clientId = null)
        {
            if (User.IsInRole("Administrator"))
                return await Task.Run(async () => View("Index", new EntityViewMode<List<ClientReportPGRSViewModel>>(await clientReportServices.GetClientReportPGRSViewModel(clientId, startDate, endDate, unitOfMeasurementId), loadFromController)));

            return await Task.Run(async () => View("Index", new EntityViewMode<List<ClientReportPGRSViewModel>>(await clientReportServices.GetClientReportPGRSViewModel(await clientServices.GetClientIdByLoggedUser(HttpContext), startDate, endDate, unitOfMeasurementId), loadFromController)));
        }
    }
}
