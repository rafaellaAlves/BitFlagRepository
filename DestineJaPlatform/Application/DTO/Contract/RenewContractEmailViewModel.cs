using System;
using System.Collections.Generic;
using System.Text;
using DTO.Utils;

namespace DTO.Contract
{
    public class RenewContractEmailViewModel
    {
        public ContractViewModel OldContract { get; set; }
        public ContractViewModel NewContract { get; set; }
        public DateTime? NextVisitDate { get; set; }
        public string _NextVisitDate => NextVisitDate.ToBrazilianDateFormat();
    }
}
