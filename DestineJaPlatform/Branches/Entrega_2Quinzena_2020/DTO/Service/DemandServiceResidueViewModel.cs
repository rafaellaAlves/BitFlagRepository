using DTO.Utils;
using System;
using System.Collections.Generic;
using System.Text;

namespace DTO.Service
{
    public class DemandServiceResidueViewModel
    {
        public string ResidueFamilyName { get; set; }
        public string ResidueFamilyNameAbbreviation { get; set; }
        public string IBAMACode { get; set; }
        public string ResidueName { get; set; }
        public string UnitOfMeasurementName { get; set; }
        public double Weight { get; set; }
        public string _Weight => Weight.ToWeightPtBr();
        public double Price { get; set; }
        public string _Price => Price.ToPtBR();
    }
}
