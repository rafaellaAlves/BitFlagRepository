using DTO.Demand;
using DTO.Recipient;
using DTO.Residue;
using DTO.Transporter;
using System;
using System.Collections.Generic;
using System.Text;

namespace DTO.DemandDestination
{
    public class DemandDestinationMTRFileViewModel
    {
        public int Via { get; set; }
        public DemandDestinationViewModel DemandDestination { get; set; }
        public RecipientViewModel Recipient { get; set; }
        public TransporterViewModel Transporter { get; set; }
        public List<DemandDestinationMTRFileResidueViewModel> Residues{ get; set; }
    }
}
