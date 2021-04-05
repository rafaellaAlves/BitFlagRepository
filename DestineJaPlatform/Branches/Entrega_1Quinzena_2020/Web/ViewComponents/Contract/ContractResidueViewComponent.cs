using Microsoft.AspNetCore.Mvc;
using Services.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.ViewComponents.Contract
{
    public class ContractResidueViewComponent : ViewComponent
    {
        private readonly ContractResidueServices contractResidueServices;

        public ContractResidueViewComponent(ContractResidueServices contractResidueServices)
        {
            this.contractResidueServices = contractResidueServices;
        }

        public async Task<IViewComponentResult> InvokeAsync(int? contractId) => await Task.Run(() => View(contractId.HasValue ? contractResidueServices.ToViewModel(contractResidueServices.GetDataByContractId(contractId.Value).Result) : new List<DTO.Contract.ContractResidueViewModel>()));
    }
}
