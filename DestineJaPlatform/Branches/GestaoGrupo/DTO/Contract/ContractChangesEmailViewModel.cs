using DTO.Residue;
using System;
using System.Collections.Generic;
using System.Text;

namespace DTO.Contract
{
    public class ContractChangesEmailViewModel
    {
        public ContractViewModel Contract { get; set; }
        public List<ResidueViewModel> Residues { get; set; }
    }
}
