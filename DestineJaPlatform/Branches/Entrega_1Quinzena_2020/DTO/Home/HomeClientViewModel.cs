using System;
using System.Collections.Generic;
using System.Text;
using DTO.Utils;

namespace DTO.Home
{
    public class HomeClientViewModel
    {
        public int? FinishedCollections { get; set; }
        public int? TotalCollections { get; set; }
        public int? RemainingCollections { get; set; }
        public double? CollectedWeight { get; set; }
        public string _CollectedWeight => CollectedWeight.ToWeightPtBr();
        public int? ContractedWeight { get; set; }
        public double? RemainingWeight { get; set; }
        public string _RemainingWeight => RemainingWeight.ToWeightPtBr();
        public double? ContractMonthlyPrice { get; set; }
        public string _ContractMonthlyPrice => ContractMonthlyPrice.ToPtBR() ?? "-";
        public DateTime? NextColletionDate { get; set; }
        public string _NextColletionDate => NextColletionDate.ToBrazilianDateFormat() ?? "-";
        public int? Route { get; set; }

        public HomeClientViewModel()
        {
        }
    }
}
