using System;
using System.Collections.Generic;
using System.Text;

namespace DTO.Contract
{
    public class ContractListPrintViewModel
    {
        public List<ContractListViewModel> Items { get; set; }
        public string Search { get; set; }
        public string RenewStatus { get; set; }
        public string ContractSituation { get; set; }
    }
}
