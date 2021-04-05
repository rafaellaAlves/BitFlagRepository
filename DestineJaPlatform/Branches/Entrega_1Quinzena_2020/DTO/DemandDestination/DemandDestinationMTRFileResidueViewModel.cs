using DTO.Residue;
using System;
using System.Collections.Generic;
using System.Text;

namespace DTO.DemandDestination
{
    public class DemandDestinationMTRFileResidueViewModel
    {
        public ResidueListViewModel Residue { get; set; }
        //public ResidueFamilyViewModel ResidueFamily { get; set; }
        public double Weight { get; set; }

        public DemandDestinationMTRFileResidueViewModel(ResidueListViewModel residue, double weight) //ResidueFamilyViewModel residueFamily, 
        {
            Residue = residue;
            //ResidueFamily = residueFamily;
            Weight = weight;
        }
    }
}
