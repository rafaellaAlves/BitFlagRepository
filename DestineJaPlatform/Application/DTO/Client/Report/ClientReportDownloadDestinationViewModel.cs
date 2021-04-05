using DTO.Utils;
using System;
using System.Collections.Generic;
using System.Text;

namespace DTO.Client.Report
{
    public class ClientReportDownloadDestinationViewModel
    {
        public string DestineJaDemandDestinationId => string.IsNullOrWhiteSpace(AlternativeDemandDestinationId) ? (DemandDestinationId.ToString().Length > 4 ? DemandDestinationId.ToString() : DemandDestinationId.ToString("0000")) : AlternativeDemandDestinationId;
        public DateTime ArrivedDate { get; set; }
        public string _ArrivedDate => ArrivedDate.ToBrazilianDateFormat();
        public DateTime DepartureDate { get; set; }
        public string _DepartureDate => DepartureDate.ToBrazilianDateFormat();
        public int DemandDestinationId { get; set; }
        public string AlternativeDemandDestinationId { get; set; }
        public string ResidueFamilyName { get; set; }
        public string CDF { get; set; }
        public DateTime DemandDestinationCreatedDate { get; set; }
        public string MTRFileGuidName { get; set; }
        public string CDFFileGuidName { get; set; }
    }
}
