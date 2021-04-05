using System;
using System.Collections.Generic;
using System.Text;

namespace DTO.Contract
{
    public class ContractManageParametersViewModel
    {
        public ContractViewModel Contract { get; set; }
        public bool Renewing { get; set; }

        public ContractManageParametersViewModel() { }
        public ContractManageParametersViewModel(ContractViewModel contract, bool renewing = false) {
            Contract = contract;
            Renewing = renewing;
        }
    }
}
