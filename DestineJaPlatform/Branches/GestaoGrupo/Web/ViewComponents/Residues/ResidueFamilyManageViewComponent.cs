using Microsoft.AspNetCore.Mvc;
using Services.Residue;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.ViewComponents.Residues
{
    public class ResidueFamilyManageViewComponent : ViewComponent
    {
        private readonly ResidueFamilyServices residueFamilyServices;

        public ResidueFamilyManageViewComponent(ResidueFamilyServices residueFamilyServices)
        {
            this.residueFamilyServices = residueFamilyServices;
        }

        public async Task<IViewComponentResult> InvokeAsync(int? id) => await Task.Run(() => View(id.HasValue ? residueFamilyServices.GetViewModelByIdAsync(id.Value).Result : new DTO.Residue.ResidueFamilyViewModel()));
    }
}
