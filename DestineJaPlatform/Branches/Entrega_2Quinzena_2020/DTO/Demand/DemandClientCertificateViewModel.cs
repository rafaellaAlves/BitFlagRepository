using DTO.Client;
using System;
using System.Collections.Generic;
using System.Text;

namespace DTO.Demand
{
    public class DemandClientCertificateViewModel
    {
        public List<DTO.Demand.DemandClientResidueListViewModel> DemandClientResidue { get; set; }
        public ClientViewModel Client { get; set; }
        public DemandClientViewModel DemandClient { get; set; }
        public DemandViewModel Demand { get; set; }
        public bool PDF { get; set; }
    }
}
