using ApplicationDbContext.Models;
using DTO.Demand;
using DTO.Shared;
using DTO.Utils;
using Microsoft.AspNetCore.Mvc;
using Org.BouncyCastle.Math.EC.Rfc7748;
using Services.Demand;
using Services.Route;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.ViewComponents.Demand
{
    public class DemandClientViewComponent : ViewComponent
    {
        private readonly RouteClientListServices routeClientListServices;
        private readonly BaseDemandClientListServices baseDemandClientListServices;
        private readonly DemandClientListServices demandClientListServices;
        private readonly DemandServices demandServices;
        private readonly RouteServices routeServices;
        private readonly DemandNotUsedClientServices demandNotUsedClientServices;
        private readonly DemandResidueFamilyServices demandResidueFamilyServices;

        public DemandClientViewComponent(RouteClientListServices routeClientListServices, BaseDemandClientListServices baseDemandClientListServices, DemandClientListServices demandClientListServices, DemandServices demandServices, RouteServices routeServices, DemandNotUsedClientServices demandNotUsedClientServices, DemandResidueFamilyServices demandResidueFamilyServices)
        {
            this.routeClientListServices = routeClientListServices;
            this.baseDemandClientListServices = baseDemandClientListServices;
            this.demandClientListServices = demandClientListServices;
            this.demandServices = demandServices;
            this.routeServices = routeServices;
            this.demandNotUsedClientServices = demandNotUsedClientServices;
            this.demandResidueFamilyServices = demandResidueFamilyServices;
        }

        public async Task<IViewComponentResult> InvokeAsync(int routeId, int? demandId, bool loadFromController = false)
        {
            List<DemandClientListViewModel> demandClient = new List<DemandClientListViewModel>();
            List<DemandClientListViewModel> demandNotUsedClient = new List<DemandClientListViewModel>();
            List<DemandResidueFamilyViewModel> demandResidueFamily = new List<DemandResidueFamilyViewModel>();
            DemandViewModel demand;
            var route = await routeServices.GetViewModelByIdAsync(routeId);

            if (demandId.HasValue)
            {
                demand = await demandServices.GetViewModelByIdAsync(demandId.Value);
                demandClient = await demandClientListServices.GetViewModelAsNoTrackingAsync(x => x.DemandId == demandId);
                demandNotUsedClient = (from y in await demandNotUsedClientServices.GetViewModelAsNoTrackingAsync(x => x.DemandId == demandId) 
                                       join bdc in await baseDemandClientListServices.GetViewModelAsNoTrackingAsync() on y.ClientCollectionAddressId equals bdc.ClientCollectionAddressId 
                                       select bdc.CopyToEntity<DemandClientListViewModel>()).ToList();

                demandResidueFamily = await demandResidueFamilyServices.GetViewModelAsNoTrackingAsync(x => x.DemandId == demandId);
            }
            else
            {
                var routeClients = await routeClientListServices.GetDataAsNoTrackingAsync(x => x.RouteId == routeId);
                var addressIds = routeClients.Select(x => x.ClientCollectionAddressId);
                var demandClientList = (await baseDemandClientListServices.GetViewModelAsNoTrackingAsync(x => addressIds.Contains(x.ClientCollectionAddressId))).Select(x => x.CopyToEntity<DemandClientListViewModel>()).ToList();
                demandClientList.ForEach(x =>
                {
                    var routeClient = routeClients.SingleOrDefault(c => c.ClientCollectionAddressId == x.ClientCollectionAddressId);
                    x.DemandResidueFamilyIds = routeClient.RouteResidueFamilyIds;
                    x.ResidueFamilyName = routeClient.ResidueFamilyName;
                    x.Order = routeClient.Order;
                });

                demandClient = demandClientList.Where(x => x.TimeToDemand).ToList();
                demandNotUsedClient = demandClientList.Where(x => !x.TimeToDemand).ToList();

                demand = new DemandViewModel() { RouteId = routeId };
            }

            return await Task.Run(() => View(new EntityViewMode<DemandClientManageViewModel>(ViewMode.Editable, new DemandClientManageViewModel(demand, route, demandNotUsedClient, demandClient, demandResidueFamily), loadFromController)));
        }
    }
}
