using DTO.Client;
using DTO.Residue;
using DTO.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DTO.Service
{
    public class ServicePrintViewModel
    {
        public ServiceViewModel Service { get; set; }
        public ClientViewModel Client { get; set; }
        public List<ServiceResidueFamilyPriceViewModel> ResidueFamilyPrice { get; set; }
        public string ServiceFreightPaymentTermDays { get; set; }
        public string ServiceResidueFamilyPriceDays { get; set; }
        public double PriceInKg { get; set; }
        public string _PriceInKg { get => PriceInKg.ToPtBR(); }
        public bool UsingForPdf { get; set; }
        public bool UsingForEmail { get; set; }
    }
}
