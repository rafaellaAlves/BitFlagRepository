using DTO.Residue;
using System;
using System.Collections.Generic;
using System.Text;

namespace DTO.Demand
{
    public class DemandResidueFamilyViewModel
    {
        public int? DemandResidueFamilyId { get; set; }
        public int DemandId { get; set; }
        public int ResidueFamilyId { get; set; }
        public int ClientCollectionAddressId { get; set; }
        public ResidueFamilyViewModel ResidueFamily { get; set; }
    }
}
