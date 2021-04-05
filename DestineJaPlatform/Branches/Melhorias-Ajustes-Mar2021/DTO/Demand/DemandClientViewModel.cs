using System;
using System.Collections.Generic;
using System.Text;
using DTO.Utils;

namespace DTO.Demand
{
    public class DemandClientViewModel
    {
        public int? DemandClientId { get; set; }
        public int DemandId { get; set; }
        public int ClientCollectionAddressId { get; set; }
        public int? ContractId { get; set; }
        public int? ServiceId { get; set; }
        public int Order { get; set; }
        public bool? Visited { get; set; }
        public bool? Collected { get; set; }
        public string NonCollectingReason { get; set; }
        public TimeSpan? ArrivedTime { get; set; }
        public string _ArrivedTime { get => ArrivedTime.ToBrazilianTimeNoSecondsFormat(); set => ArrivedTime = value.FromBrazilianTimeNoSecondsFormat(); }
        public TimeSpan? DepartureTime { get; set; }
        public string _DepartureTime { get => DepartureTime.ToBrazilianTimeNoSecondsFormat(); set => DepartureTime = value.FromBrazilianTimeNoSecondsFormat(); }
        public string ReceptorName { get; set; }
        public string ReceptorCPF { get; set; }
        public string _ReceptorCPF  { get => ReceptorCPF.NumbersOnly(); set => ReceptorCPF = value.NumbersOnly(); }
        public string DestineJaCertificateId => !CertificateId.HasValue ? null : CertificateId.ToString().Length > 4 ? CertificateId.ToString() : CertificateId.Value.ToString("0000");
        public int? CertificateId { get; set; }
        public DateTime? VisitedDate { get; set; }
        public string _VisitedDate { get => VisitedDate.ToBrazilianDateFormat(); set => VisitedDate = value.FromBrazilianDateFormatNullable(); }
        public string MTRFileMimeType { get; set; }
        public string MTRFileGuidName { get; set; }
        public string MTRFileName { get; set; }
    }
}
