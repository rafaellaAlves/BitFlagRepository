using DTO.Shared;
using Microsoft.AspNetCore.Mvc;
using Services.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.ViewComponents.Demand
{
    public class DemandClientSOSelectionViewComponent : ViewComponent
    {
        private readonly ServiceServices serviceServices;

        public DemandClientSOSelectionViewComponent(ServiceServices serviceServices)
        {
            this.serviceServices = serviceServices;
        }

        public async Task<IViewComponentResult> InvokeAsync(int addressId, bool loadFromController = false) => await Task.Run(async () => View(new EntityViewMode<List<ApplicationDbContext.Models.Service>>(await serviceServices.GetServicesByClientCollectionAddressId(addressId), loadFromController)));
    }
}
