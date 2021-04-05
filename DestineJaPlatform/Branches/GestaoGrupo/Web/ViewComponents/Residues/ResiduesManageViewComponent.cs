using ApplicationDbContext.Models;
using Microsoft.AspNetCore.Mvc;
using Services.Account;
using Services.Residue;
using System.Threading.Tasks;

namespace Web.ViewComponents
{
    public class ResiduesManageViewComponent : ViewComponent
    {
        private readonly ResidueServices residueServices;

        public ResiduesManageViewComponent(ResidueServices residueServices)
        {
            this.residueServices = residueServices;
        }

        public async Task<IViewComponentResult> InvokeAsync(int residueFamilyId, int? id) => await Task.Run(() => View(id.HasValue ? residueServices.GetViewModelByIdAsync(id.Value).Result : new DTO.Residue.ResidueViewModel { ResidueFamilyId = residueFamilyId }));
    }
}
