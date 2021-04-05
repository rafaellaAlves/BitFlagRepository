using DTO.Client;
using DTO.Residue;
using DTO.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
using System.Text;

namespace DTO.Contract
{
    public class ContractPrintViewModel
    {
        public ContractViewModel Contract { get; set; }
        public ClientViewModel Client { get; set; }
        public double PriceInKg { get; set; }
        public string _PriceInKg { get => PriceInKg.ToPtBR(); }
        public bool UsingForPdf { get; set; }
        public bool UsingForEmail { get; set; }
        public Dictionary<ResidueFamilyListViewModel, List<ContractResidueViewModel>> Residues { get; set; }
        public Dictionary<ResidueFamilyListViewModel, List<ContractResidueViewModel>> ResidueDeductFromFranchise => Residues.Where(x => x.Value.Any(c => c.DeductFromFranchise)).ToDictionary(x => x.Key, x => x.Value);
        public Dictionary<ResidueFamilyListViewModel, List<ContractResidueViewModel>> ResidueNoResiduePriceDeductFromFranchise => Residues.Where(x => !x.Value.Any(c => c.DeductFromFranchise)).ToDictionary(x => x.Key, x => x.Value);

        public int ContractMonthDuration { get { 
                var r = Math.Abs(((Contract.StartContract.Value.Year - Contract.DueDate.Value.Year) * 12) + Contract.StartContract.Value.Month - Contract.DueDate.Value.Month);

                return r < 1 ? 1 : r;
            } }
    }
}
