using DTO.Utils;
using System;
using System.Collections.Generic;
using System.Text;

namespace DTO.Client.Report
{
    public class ClientReportCollectionMovementViewModel
    {
        public string DestineJaDemandDestinationId => string.IsNullOrWhiteSpace(AlternativeDemandDestinationId) ? (DemandDestinationId?.ToString().Length > 4 ? DemandDestinationId?.ToString() : DemandDestinationId?.ToString("0000")) : AlternativeDemandDestinationId;
        public string DestineJaDemandId => string.IsNullOrWhiteSpace(AlternativeDemandId) ? $"{DemandId}/{CreatedDate:yyyy}" : AlternativeDemandId;
        public string DestineJaCertificateId => CertificateId.ToString().Length > 4 ? CertificateId.ToString() : CertificateId.ToString("0000");
        public DateTime CreatedDate { get; set; }
        public int DemandId { get; set; }
        public string AlternativeDemandId { get; set; }
        public string ResidueFamilyName { get; set; }
        public int CertificateId { get; set; }
        public string RecipientName { get; set; }
        public int? DemandDestinationId { get; set; }
        public string AlternativeDemandDestinationId { get; set; }
        public DateTime? DemandDestinationArrivedDate { get; set; }
        public string _DemandDestinationArrivedDate => DemandDestinationArrivedDate.ToBrazilianDateFormat();
        public DateTime? DemandVisitedDate { get; set; }
        public string _DemandVisitedDate => DemandVisitedDate.ToBrazilianDateFormat();
        public string CDF { get; set; }
        public double Weight { get; set; }
        public string _Weight => Weight.ToWeightPtBr();
    }
}
