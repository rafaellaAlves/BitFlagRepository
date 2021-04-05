using Microsoft.AspNetCore.Mvc;
using Services.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.ViewComponents.Contract
{
    public class ContractEmailViewComponent : ViewComponent
    {
        private readonly ContractServices contractServices;

        public ContractEmailViewComponent(ContractServices contractServices)
        {
            this.contractServices = contractServices;
        }

        public async Task<IViewComponentResult> InvokeAsync(int id) => await Task.Run(async () => View(await contractServices.GetViewModelByIdAsync(id)));
    }
}
