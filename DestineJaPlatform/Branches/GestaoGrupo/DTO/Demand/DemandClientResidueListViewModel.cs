using System;
using System.Collections.Generic;
using System.Text;
using DTO.Utils;

namespace DTO.Demand
{
    public class DemandClientResidueListViewModel
    {
        public int? DemandClientResidueId { get; set; }
        public int DemandClientId { get; set; }
        public int DemandId { get; set; }
        public int RouteId { get; set; }
        public int ResidueId { get; set; }
        public string IBAMACode { get; set; }
        public string ResidueName { get; set; }
        public double? Weight { get; set; }
        public string _Weight => Weight.ToWeightPtBr();
        public string ResidueFamilyNameAbbreviation { get; set; }
        public string ResidueFamilyName { get; set; }
        public int? ResidueFamilyId { get; set; }
        public string RecipientName { get; set; }
        public string RecipientDocument { get; set; }
        public int UnitOfMeasurementId { get; set; }
        public string UnitOfMeasurementName { get; set; }
    }
}
