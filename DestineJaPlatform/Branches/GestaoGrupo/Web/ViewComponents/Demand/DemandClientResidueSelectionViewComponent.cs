using DTO.Demand;
using DTO.Shared;
using Microsoft.AspNetCore.Mvc;
using Services.Demand;
using Services.Residue;
using Services.Route;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.ViewComponents.Demand
{
    public class DemandClientResidueSelectionViewComponent : ViewComponent
    {
        public readonly DemandClientResidueListServices demandClientResidueListServices;
        public readonly DemandClientServices demandClientServices;
        public readonly DemandServices demandServices;
        public readonly RouteServices routeServices;
        public readonly RouteTypeServices routeTypeServices;
        public readonly ResidueFamilyServices residueFamilyServices;
        public readonly DemandResidueFamilyServices demandResidueFamilyServices;

        public DemandClientResidueSelectionViewComponent(DemandClientResidueListServices demandClientResidueListServices, RouteServices routeServices, DemandServices demandServices, DemandClientServices demandClientServices, RouteTypeServices routeTypeServices, ResidueFamilyServices residueFamilyServices, DemandResidueFamilyServices demandResidueFamilyServices)
        {
            this.demandClientResidueListServices = demandClientResidueListServices;
            this.routeServices = routeServices;
            this.demandClientServices = demandClientServices;
            this.demandServices = demandServices;
            this.routeTypeServices = routeTypeServices;
            this.residueFamilyServices = residueFamilyServices;
            this.demandResidueFamilyServices = demandResidueFamilyServices;
        }

        public async Task<IViewComponentResult> InvokeAsync(DemandClientResidueListViewModel model, bool loadFromController)
        {

            var demandClient = await demandClientServices.GetViewModelByIdAsync(model.DemandClientId);
            //var demand = await demandServices.GetViewModelByIdAsync(demandClient.DemandId);
            //var route = await routeServices.GetDataByIdAsync(demand.RouteId);

            //if(route.RouteTypeId == (await routeTypeServices.GetDataByExternalCode("CONTRATO"))?.RouteTypeId)
            //{
            //    familiesIDs = (await routeServices.GetResidueFamiliesByRouteId(route.RouteId)).Select(x => x.ResidueFamilyId);
            //}
            //else // se a rota for de serviço pega todos as familias 
            //{
            //    familiesIDs = (await residueFamilyServices.GetDataAsNoTrackingAsync(x => !x.IsDeleted)).Select(x => x.ResidueFamilyId);
            //}

            IEnumerable<int> familiesIDs = (await demandResidueFamilyServices.GetDataAsNoTrackingAsync(x => x.ClientCollectionAddressId == demandClient.ClientCollectionAddressId && x.DemandId == demandClient.DemandId)).Select(x => x.ResidueFamilyId);

            if (model.DemandClientResidueId.HasValue)
            {
                var demandClientResidue = await demandClientResidueListServices.GetViewModelByIdAsync(model.DemandClientResidueId.Value);
                var r = new DemandClientResidueSelectionParameters(demandClientResidue, demandClient, familiesIDs);
                return await Task.Run(() => View(new EntityViewMode<DemandClientResidueSelectionParameters>(ViewMode.Editable, r, loadFromController)));
            }
            else
            {
                var demandClientResidue = new DemandClientResidueListViewModel();
                if (model.ResidueFamilyId.HasValue)
                {
                    demandClientResidue.ResidueFamilyId = model.ResidueFamilyId;
                    demandClientResidue.ResidueId = model.ResidueId;
                    demandClientResidue.Weight = model.Weight;
                    demandClientResidue.UnitOfMeasurementId = model.UnitOfMeasurementId;
                }

                var r = new DemandClientResidueSelectionParameters(demandClientResidue, demandClient, familiesIDs);
                return await Task.Run(() => View(new EntityViewMode<DemandClientResidueSelectionParameters>(ViewMode.Editable, r, loadFromController)));
            }

        }
    }
}
