using DTO.Demand;
using System;
using System.Collections.Generic;
using System.Text;

namespace DTO.DemandDestination
{
    public class DemandDestinationDemandParamenterViewModel
    {
        public int? ResidueFamilyId { get; set; }
        public List<DemandListViewModel> DemandList { get; set; }
        public DemandDestinationViewModel DemandDestination { get; set; }

        public DemandDestinationDemandParamenterViewModel(int? residueFamilyId, List<DemandListViewModel> demandList, DemandDestinationViewModel demandDestination)
        {
            DemandList = demandList;
            ResidueFamilyId = residueFamilyId;
            DemandDestination = demandDestination == null ? new DemandDestinationViewModel() : demandDestination;
        }
    }
}
