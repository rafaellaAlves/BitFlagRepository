using Microsoft.AspNetCore.Mvc;
using Services.Residue;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.ViewComponents.Residues
{
    public class ResiduePriceManageViewComponent : ViewComponent
    {
        private readonly ResiduePriceServices residuePriceServices;

        public ResiduePriceManageViewComponent(ResiduePriceServices residuePriceServices)
        {
            this.residuePriceServices = residuePriceServices;
        }

        public async Task<IViewComponentResult> InvokeAsync(int? recipientId, int? id) => await Task.Run(() => View(id.HasValue? residuePriceServices.GetViewModelByIdAsync(id.Value).Result : new DTO.Residue.ResiduePriceViewModel { RecipientId = recipientId }));
    }
}
