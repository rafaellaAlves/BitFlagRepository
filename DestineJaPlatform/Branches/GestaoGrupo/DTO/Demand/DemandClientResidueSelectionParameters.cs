using System;
using System.Collections.Generic;
using System.Text;

namespace DTO.Demand
{
    public class DemandClientResidueSelectionParameters
    {
        public DemandClientViewModel DemandClient { get; set; }
        public DemandClientResidueListViewModel DemandClientResidue { get; set; }
        public IEnumerable<int> ResidueFamilyIds { get; set; }

        public DemandClientResidueSelectionParameters() { }
        public DemandClientResidueSelectionParameters(DemandClientResidueListViewModel demandClientResidue, DemandClientViewModel demandClient, IEnumerable<int> residueFamilyIds)
        {
            this.DemandClientResidue = demandClientResidue;
            this.DemandClient = demandClient;
            this.ResidueFamilyIds = residueFamilyIds;
        }
        public DemandClientResidueSelectionParameters(DemandClientViewModel demandClient, IEnumerable<int> residueFamilyIds)
        {
            this.DemandClientResidue = new DemandClientResidueListViewModel();
            this.DemandClient = demandClient;
            this.ResidueFamilyIds = residueFamilyIds;
        }
    }
}
