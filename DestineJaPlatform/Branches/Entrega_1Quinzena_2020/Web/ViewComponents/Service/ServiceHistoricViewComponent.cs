using DTO.Service;
using Microsoft.AspNetCore.Mvc;
using Services.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.ViewComponents.Service
{
    public class ServiceHistoricViewComponent : ViewComponent
    {
        private readonly ServiceHistoricServices serviceHistoricServices;

        public ServiceHistoricViewComponent(ServiceHistoricServices serviceHistoricServices)
        {
            this.serviceHistoricServices = serviceHistoricServices;
        }

        public async Task<IViewComponentResult> InvokeAsync(int clientId, bool loadFromController = false) => await Task.Run(async () => View(new DTO.Shared.EntityViewMode<List<ServiceHistoricViewModel>>(DTO.Shared.ViewMode.NonEditable, serviceHistoricServices.ToViewModel(await serviceHistoricServices.GetDataByClientIdAsync(clientId)), loadFromController)));
    }
}
