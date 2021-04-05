using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationDbContext.Models
{
    public class DemandClient
    {
        public int DemandClientId { get; set; }
        public int DemandId { get; set; }
        public int ClientCollectionAddressId { get; set; }
        public int? ContractId { get; set; }
        public int? ServiceId { get; set; }
        public int Order { get; set; }
        public bool? Visited { get; set; }
        public bool? Collected { get; set; }
        public string NonCollectingReason { get; set; }
        public TimeSpan? ArrivedTime { get; set; }
        public TimeSpan? DepartureTime { get; set; }
        public string ReceptorName { get; set; }
        public string ReceptorCPF { get; set; }
        public int? CertificateId { get; set; }
        public DateTime? VisitedDate { get; set; }
        public string MTRFileMimeType { get; set; }
        public string MTRFileGuidName { get; set; }
        public string MTRFileName { get; set; }
    }
}
