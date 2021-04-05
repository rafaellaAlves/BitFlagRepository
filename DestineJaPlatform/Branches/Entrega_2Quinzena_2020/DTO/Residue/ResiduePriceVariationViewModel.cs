using DTO.Utils;
using System;
using System.Collections.Generic;
using System.Text;

namespace DTO.Residue
{
    public class ResiduePriceVariationViewModel
    {
        public int ResidueFamilyId { get; set; }
        public string Name { get; set; }
        public string IBAMACode { get; set; }
        public double? MinimumPrice { get; set; }
        public string _MinimumPrice { get { return MinimumPrice.ToPtBR(); } set { MinimumPrice = value.FromDoublePtBR(); } }
        public double? MediumPrice { get; set; }
        public string _MediumPrice { get { return MediumPrice.ToPtBR(); } set { MediumPrice = value.FromDoublePtBR(); } }
        public double? MaximumPrice { get; set; }
        public string _MaximumPrice { get { return MaximumPrice.ToPtBR(); } set { MaximumPrice = value.FromDoublePtBR(); } }
    }
}
