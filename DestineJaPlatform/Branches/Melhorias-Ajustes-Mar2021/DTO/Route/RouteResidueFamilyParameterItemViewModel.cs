using DTO.Residue;
using System;
using System.Collections.Generic;
using System.Text;

namespace DTO.Route
{
    public class RouteResidueFamilyParameterItemViewModel
    {
        public ResidueFamilyListViewModel ResidueFamily { get; set; }
        public List<ResidueViewModel> Residues { get; set; }
    }
}
