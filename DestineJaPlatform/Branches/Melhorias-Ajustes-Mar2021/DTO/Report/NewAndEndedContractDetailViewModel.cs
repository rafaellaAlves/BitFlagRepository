using DTO.Contract;
using System;
using System.Collections.Generic;
using System.Text;

namespace DTO.Report
{
    public class NewAndEndedContractDetailViewModel
    {
        public List<ContractListViewModel> NewContract { get; set; }
        public List<ContractListViewModel> EndedContract { get; set; }

        public NewAndEndedContractDetailViewModel()
        {
            NewContract = new List<ContractListViewModel>();
            EndedContract = new List<ContractListViewModel>();
        }
    }
}
