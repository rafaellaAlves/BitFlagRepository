using System;
using System.Collections.Generic;
using System.Text;

namespace DTO.DemandDestination
{
    public class DemandDestionationDemandSelectViewModel
    {
        public int DemandId { get; set; }
        public int ResidueFamilyId { get; set; }

        public DemandDestionationDemandSelectViewModel(int demandId, int residueFamilyId)
        {
            DemandId = demandId;
            ResidueFamilyId = residueFamilyId;
        }
    }
}
