using System;
using System.Collections.Generic;
using System.Text;

namespace DTO.Demand
{
    public class DemandInfoItemViewModel
    {
        public DemandClientListViewModel DemandClient { get; set; }
        public List<DemandClientResidueListViewModel> DemandClientResidues { get; set; }

        public DemandInfoItemViewModel() { }
        public DemandInfoItemViewModel(DemandClientListViewModel demandClient, List<DemandClientResidueListViewModel> demandClientResidues)
        {
            DemandClient = demandClient;
            DemandClientResidues = demandClientResidues;
        }
    }
}
