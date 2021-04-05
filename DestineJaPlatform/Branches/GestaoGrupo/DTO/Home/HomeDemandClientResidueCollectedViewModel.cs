using DTO.Utils;
using System;
using System.Collections.Generic;
using System.Text;

namespace DTO.Home
{
    public class HomeDemandClientResidueCollectedViewModel
    {
        public int ResidueId { get; set; }
        public string ResidueName { get; set; }
        public string ResidueFamilyName { get; set; }
        public double Weight { get; set; }
        public string _Weight => Weight.ToWeightPtBr();
    }
}
