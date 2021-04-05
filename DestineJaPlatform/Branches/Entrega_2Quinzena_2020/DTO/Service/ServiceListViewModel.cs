using System;
using System.Collections.Generic;
using System.Text;
using DTO.Utils;

namespace DTO.Service
{
    public class ServiceListViewModel
    {
        public int ServiceId { get; set; }
        public string Code { get; set; }
        public int ClientId { get; set; }
        public string ClientName { get; set; }
        public string TradeName { get; set; }
        public double Weight { get; set; }
        public string WeightFormated => Weight.ToWeightPtBr();
        public DateTime? CollectionDate { get; set; }
        public string _CollectionDate { get => CollectionDate.ToBrazilianDateFormat(); set => CollectionDate = value.FromBrazilianDateFormatNullable(); }
        public int ServiceStatusId { get; set; }
        public int ServiceSituationId { get; set; }
        public string StatusName { get; set; }
        public bool IsDeleted { get; set; }
        public double TotalPrice { get; set; }
        public string _TotalPrice { get => TotalPrice.ToPtBR(); set => TotalPrice = value.FromDoublePtBR().Value; }
        public double FreightPrice { get; set; }
        public string _FreightPrice { get => FreightPrice.ToPtBR(); set => FreightPrice = value.FromDoublePtBR().Value; }
        public bool HasServiceOrderFile { get; set; }

        public DateTime? LastDemandDate { get; set; }
        public string _LastDemandDate => LastDemandDate.ToBrazilianDateFormat();

        public double? ResiduePrice { get; set; }
        public string _ResiduePrice => ResiduePrice.ToPtBR();

        public DateTime CreatedDate { get; set; }
        public string DemandIds { get; set; }
        public string DemandDestinationIds { get; set; }
        public bool IsActive { get; set; }
    }
}
