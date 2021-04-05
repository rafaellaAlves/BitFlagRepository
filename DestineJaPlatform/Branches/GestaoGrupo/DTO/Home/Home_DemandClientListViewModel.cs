using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using DTO.Utils;

namespace DTO.Home
{
    public class HomeDemandClientListViewModel
    {
        public int DemandClientId { get; set; }
        public string DestineJaDemandId => string.IsNullOrWhiteSpace(AlternativeDemandId)? $"{DemandId}/{DemandCreatedDate:yyyy}" : AlternativeDemandId;
        public int DemandId { get; set; }
        public string AlternativeDemandId { get; set; }
        public string ReceptorName { get; set; }
        public DateTime? VisitedDate { get; set; }
        public string _VisitedDate => VisitedDate.ToBrazilianDateFormat();
        public string VisitedDateISO => VisitedDate?.ToString("yyyy-MM-ddTHH\\:mm\\:ss.fffffffzzz");
        public TimeSpan? ArrivedTime { get; set; }
        public bool? Visited { get; set; }
        public bool? Collected { get; set; }
        public int? CertificateId { get; set; }
        public double? Weight { get; set; }
        public DateTime DemandCreatedDate { get; set; }
        public int TransporterDriverId { get; set; }
        public string DriverName { get; set; }
        public string DestineJaCertificateId => !CertificateId.HasValue ? null : CertificateId.ToString().Length > 4 ? CertificateId.ToString() : CertificateId.Value.ToString("0000");
        public int ClientId { get; set; }
    }
}
