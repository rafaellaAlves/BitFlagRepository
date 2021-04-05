using DTO.Utils;
using System;
using System.Collections.Generic;
using System.Text;

namespace DTO.Client.Report
{
    public class ClientReportDownloadViewModel
    {
        public string DestineJaDemandId => string.IsNullOrWhiteSpace(AlternativeDemandId) ? $"{DemandId}/{DemandCreatedDate:yyyy}" : AlternativeDemandId;
        public DateTime VisitedDate { get; set; }
        public string _VisitedDate => VisitedDate.ToBrazilianDateFormat();
        public int DemandId { get; set; }
        public string AlternativeDemandId { get; set; }
        public string DestineJaCertificateId => !CertificateId.HasValue ? null : CertificateId.ToString().Length > 4 ? CertificateId.ToString() : CertificateId.Value.ToString("0000");
        public int? CertificateId { get; set; }
        public int DemandClientId { get; set; }
        public DateTime DemandCreatedDate { get; set; }
        public string MTRFileGuidName { get; set; }
    }
}
