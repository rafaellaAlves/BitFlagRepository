using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace ApplicationDbContext.Models
{
    public class DemandClientList
    {
        [Key]
        public int? DemandClientId { get; set; }
        public int? DemandId { get; set; }
        public int Order { get; set; }
        public int ClientCollectionAddressId { get; set; }
        public int ClientId { get; set; }
        public string ContractCode { get; set; }
        public string ServiceCode { get; set; }
        public int? ContractId { get; set; }
        public int? ServiceId { get; set; }
        public int SituationId { get; set; }
        public string CompanyName { get; set; }
        public string TradeName { get; set; }
        public bool IsCompany { get; set; }
        public string PeriodicityName { get; set; }
        public int? PeriodicityId { get; set; }
        public string State { get; set; }
        public string City { get; set; }
        public string Neighborhood { get; set; }
        public string Address { get; set; }
        public string Number { get; set; }
        public bool ClientIsDeleted { get; set; }
        public DateTime? LastCollectedDate { get; set; }
        public DateTime? LastVisitedDate { get; set; }
        public bool? ClosedCollected { get; set; }
        public bool? ClosedVisited { get; set; }
        public int? ClosedDemandId { get; set; }
        public string ClosedNonCollectingReason { get; set; }
        public double? ClosedTotalWeightCollected { get; set; }
        public TimeSpan? DepartureTime { get; set; }
        public TimeSpan? ArrivedTime { get; set; }
        public string SituationName { get; set; }
        public string ReceptorName { get; set; }
        public bool? Visited { get; set; }
        public bool? Collected { get; set; }
        public string NonCollectingReason { get; set; }
        public string DemandResidueFamilyIds { get; set; }
        public IEnumerable<string> _DemandResidueFamilyIds
        {
            get => string.IsNullOrWhiteSpace(DemandResidueFamilyIds) ? (IEnumerable<string>)new List<string>() : DemandResidueFamilyIds.Split(";");//obtem os ids que estão separados por ';'
        }
        public string ResidueFamilyName { get; set; }
        public string RowColor { get; set; }
        public int? CertificateId { get; set; }
        public DateTime? VisitedDate { get; set; }
        public bool HasMTRFile { get; set; }
        public bool TimeToDemand { get; set; }
    }
}
