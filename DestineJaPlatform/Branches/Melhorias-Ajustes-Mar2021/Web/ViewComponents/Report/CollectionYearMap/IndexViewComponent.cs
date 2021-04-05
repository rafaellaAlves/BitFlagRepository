using DTO.Client.Report;
using DTO.Shared;
using Microsoft.AspNetCore.Mvc;
using Services.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.ViewComponents.Report.CollectionYearMap
{
    [ViewComponent(Name = "Report\\CollectionYearMap")]
    public class IndexViewComponent : ViewComponent
    {

        private readonly ClientReportServices clientReportServices;
        private readonly ClientServices clientServices;

        public IndexViewComponent(ClientReportServices clientReportServices, ClientServices clientServices)
        {
            this.clientReportServices = clientReportServices;
            this.clientServices = clientServices;
        }

        public async Task<IViewComponentResult> InvokeAsync(bool loadFromController = false, int? startYear = null, int? endYear = null, int? clientId = null, int? residueFamilyId = null, List<int> residueIds = null)
        {
            if (User.IsInRole("Administrator"))
                return await Task.Run(async () => View("Index", new EntityViewMode<List<ClientReportCollectionYearMapViewModel>>(await clientReportServices.GetClientReportCollectionYearMapViewModel(clientId, startYear, endYear, residueFamilyId, residueIds), loadFromController)));


            return await Task.Run(async () => View("Index", new EntityViewMode<List<ClientReportCollectionYearMapViewModel>>(await clientReportServices.GetClientReportCollectionYearMapViewModel(await clientServices.GetClientIdByLoggedUser(HttpContext), startYear, endYear, residueFamilyId, residueIds), loadFromController)));
        }
    }
}
