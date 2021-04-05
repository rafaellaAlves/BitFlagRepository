using DTO.Demand;
using DTO.Shared;
using Microsoft.AspNetCore.Mvc;
using Services.Demand;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.ViewComponents.Demand
{
    public class DemandInfoViewComponent : ViewComponent
    {
        private readonly DemandServices demandServices;

        public DemandInfoViewComponent(DemandServices demandServices)
        {
            this.demandServices = demandServices;
        }

        public async Task<IViewComponentResult> InvokeAsync(int demandId, int? residueFamilyId = null, bool loadFromController = false) => await Task.Run(async () => View(new EntityViewMode<DemandInfoViewModel>(ViewMode.Editable, await demandServices.GetDemandInfoViewModel(demandId, residueFamilyId), loadFromController)));
    }
}
