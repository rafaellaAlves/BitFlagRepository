using DTO.Recipient;
using DTO.Residue;
using System;
using System.Collections.Generic;
using System.Text;

namespace DTO.DemandDestination
{
    public class NewDemandDestinationEmailViewModel
    {
        public DemandDestinationViewModel DemandDestination { get; set; }
        public ResidueFamilyViewModel ResidueFamily { get; set; }
        public RecipientViewModel Recipient { get; set; }
    }
}
