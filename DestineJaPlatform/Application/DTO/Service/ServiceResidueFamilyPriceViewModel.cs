using System;
using System.Collections.Generic;
using System.Text;
using DTO.Residue;
using DTO.Utils;

namespace DTO.Service
{
    public class ServiceResidueFamilyPriceViewModel
    {
        public int ServiceResidueFamilyPriceId { get; set; }
        public int ServiceId { get; set; }
        public int ResidueFamilyId { get; set; }
        public double? Price { get; set; }
        public string _Price { get => Price.ToPtBR(); set => Price = value.FromDoublePtBR(); }
        public int UnitOfMeasurementId { get; set; }
        public double? MinimumPrice { get; set; }
        public string _MinimumPrice { get => MinimumPrice.ToPtBR(); set => MinimumPrice = value.FromDoublePtBR(); }
        public double? MediumPrice { get; set; }
        public string _MediumPrice { get => MediumPrice.ToPtBR(); set => MediumPrice = value.FromDoublePtBR(); }
        public double? MaximumPrice { get; set; }
        public string _MaximumPrice { get => MaximumPrice.ToPtBR(); set => MaximumPrice = value.FromDoublePtBR(); }
        public ResidueFamilyViewModel ResidueFamily { get; set; }
        public string UnitOfMeasurementName { get; set; }
        public ServiceResidueFamilyPriceViewModel()
        {
            ResidueFamily = new ResidueFamilyViewModel();
        }
    }
}
