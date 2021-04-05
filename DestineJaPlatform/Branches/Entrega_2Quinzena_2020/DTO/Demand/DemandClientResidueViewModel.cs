using System;
using System.Collections.Generic;
using System.Text;
using DTO.Utils;

namespace DTO.Demand
{
    public class DemandClientResidueViewModel
    {
        public int? DemandClientResidueId { get; set; }
        public int DemandClientId { get; set; }
        public int? ResidueId { get; set; }
        public double? Weight { get; set; }
        public string _Weight { get => Weight.ToWeightPtBr(); set => Weight = value.FromDoublePtBR(); }
        public int? UnitOfMeasurementId { get; set; }
    }
}
