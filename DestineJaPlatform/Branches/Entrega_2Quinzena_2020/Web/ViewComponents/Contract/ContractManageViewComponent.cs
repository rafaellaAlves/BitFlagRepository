using DTO.Contract;
using Microsoft.AspNetCore.Mvc;
using Services.Account;
using Services.Client;
using Services.Contract;
using System.Threading.Tasks;

namespace Web.ViewComponents.Contract
{
    public class ContractManageViewComponent : ViewComponent
    {
        private readonly ContractServices service;

        public ContractManageViewComponent(ContractServices service)
        {
            this.service = service;
        }

        public async Task<IViewComponentResult> InvokeAsync(int? contractId, bool renewing = false)
        {
            ContractViewModel model = new ContractViewModel();
            if (contractId.HasValue) model = await service.GetViewModelByIdAsync(contractId.Value);

            model.Renewing = renewing;

            return await Task.Run(() => View(model));
        }
    }
}
