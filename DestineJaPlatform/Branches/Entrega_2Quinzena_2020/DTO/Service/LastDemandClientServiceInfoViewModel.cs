using System;
using System.Collections.Generic;
using System.Text;
using DTO.Utils;

namespace DTO.Service
{
    public class LastDemandClientServiceInfoViewModel
    {
        public int ClientId { get; set; }
        public string DestineJaDemandId => string.IsNullOrWhiteSpace(AlternativeDemandId)? $"{DemandId}/{DemandCreatedDate:yyyy}" : AlternativeDemandId;
        public int DemandId { get; set; }
        public string AlternativeDemandId { get; set; }
        public int? ContractId { get; set; }
        public int? ServiceId { get; set; }
        public DateTime? DemandCreatedDate { get; set; }
        public DateTime? VisitedDate { get; set; }
        public string _VisitedDate => VisitedDate.ToBrazilianDateFormat();
        public double? Weight { get; set; }
        public string _Weight => Weight.ToWeightPtBr();
        public double? Price { get; set; }
        public string _Price => Price.ToPtBR();
    }
}
