using System;
using System.Collections.Generic;
using System.Text;

namespace DTO.Demand
{
    public class DemandInfoViewModel
    {
        public List<DemandInfoItemViewModel> Items { get; set; }
        public int? ResidueFamilyId { get; set; }

        public DemandInfoViewModel() { }
        public DemandInfoViewModel(List<DemandInfoItemViewModel> items, int? residueFamilyId)
        {
            Items = items;
            ResidueFamilyId = residueFamilyId;
        }
    }
}
