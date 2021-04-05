using System;
using System.Collections.Generic;
using System.Text;
using DTO.Utils;

namespace DTO.Service
{
    public class ServiceHistoricViewModel
    {
        public int ServiceId { get; set; }
        public int ClientId { get; set; }
        public string Code { get; set; }
        public string DemandIds { get; set; }
        public string DemandDestinationIds { get; set; }
        public string CollectionDate { get; set; }
        public string Receptor { get; set; }
        public double Weight { get; set; }
        public string _Weight => Weight.ToWeightPtBr();
        public double TotalPrice { get; set; }
        public string _TotalPrice { get => TotalPrice.ToPtBR(); }
        public DateTime? CreatedDate { get; set; }
        public string _CreatedDate { get => CreatedDate.ToBrazilianDateFormat(); }
    }
}
