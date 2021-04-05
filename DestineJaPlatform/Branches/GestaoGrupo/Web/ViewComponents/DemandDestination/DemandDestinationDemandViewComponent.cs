using DTO.DemandDestination;
using DTO.Shared;
using Microsoft.AspNetCore.Mvc;
using Services.Demand;
using Services.DemandDestination;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.ViewComponents.DemandDestination
{
    public class DemandDestinationDemandViewComponent : ViewComponent
    {
        private readonly DemandDestinationDemandServices demandDestinationDemandServices;
        private readonly DemandListServices demandListServices;
        private readonly DemandDestinationServices demandDestinationServices;

        public DemandDestinationDemandViewComponent(DemandDestinationDemandServices demandDestinationDemandServices, DemandListServices demandListServices, DemandDestinationServices demandDestinationServices)
        {
            this.demandDestinationDemandServices = demandDestinationDemandServices;
            this.demandListServices = demandListServices;
            this.demandDestinationServices = demandDestinationServices;
        }

        public async Task<IViewComponentResult> InvokeAsync(int? residueFamilyId, int? demandDestinationId, ViewMode viewMode = ViewMode.Editable, bool loadFromController = false)
        {
            var demandDestinations = demandDestinationId.HasValue ? await demandDestinationDemandServices.GetDataAsNoTrackingAsync(x => x.DemandDestinationId == demandDestinationId) : new List<ApplicationDbContext.Models.DemandDestinationDemand>();
            var demandDestinationsIds = demandDestinations.Select(x => x.DemandId);

            var demandDestionation = demandDestinationId.HasValue ? await demandDestinationServices.GetViewModelByIdAsync(demandDestinationId.Value) : null;
            var sameFamily = !residueFamilyId.HasValue || (demandDestionation != null && demandDestionation.ResidueFamilyId == residueFamilyId);//caso a familia selecionada seja a mesma que já foi salva irá manter as demandas já escolhidas na listagem, caso a familia seja diferente significa que o usuário alterou a familia e então as demandas anteriormente escolhidas não aparecerão na lista

            return await Task.Run(async () => View(new EntityViewMode<DemandDestinationDemandParamenterViewModel>(viewMode, new DemandDestinationDemandParamenterViewModel(residueFamilyId, !sameFamily? new List<DTO.Demand.DemandListViewModel>() : await demandListServices.GetViewModelAsNoTrackingAsync(x => demandDestinationsIds.Contains(x.DemandId)), demandDestionation), loadFromController)));
        }
    }
}
