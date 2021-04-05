using DTO.Service;
using Microsoft.AspNetCore.Mvc;
using Services.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.ViewComponents.Service
{
    public class ServiceResidueFamilyPriceViewComponent : ViewComponent
    {
        private readonly ServiceResidueFamilyPriceServices serviceResidueFamilyPriceServices;

        public ServiceResidueFamilyPriceViewComponent(ServiceResidueFamilyPriceServices serviceResidueFamilyPriceServices)
        {
            this.serviceResidueFamilyPriceServices = serviceResidueFamilyPriceServices;
        }

        public async Task<IViewComponentResult> InvokeAsync(int? serviceId) => await Task.Run(async () => View(serviceId.HasValue? new ServiceResidueViewModel(serviceId.Value, await serviceResidueFamilyPriceServices.GetViewModelAsNoTrackingAsync(x => x.ServiceId == serviceId)) : new ServiceResidueViewModel()));
    }
}
