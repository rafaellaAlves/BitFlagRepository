using System;
using System.Collections.Generic;
using System.Text;

namespace DTO.Service
{
    public class ServiceResidueViewModel
    {
        public int ServiceId { get; set; }
        public List<ServiceResidueFamilyPriceViewModel> ServiceResidueFamilyPrices { get; set; }

        public ServiceResidueViewModel()
        {
            ServiceResidueFamilyPrices = new List<ServiceResidueFamilyPriceViewModel>();
        }

        public ServiceResidueViewModel(int serviceId, List<ServiceResidueFamilyPriceViewModel> models)
        {
            ServiceId = serviceId;
            ServiceResidueFamilyPrices = models;
        }
    }
}
