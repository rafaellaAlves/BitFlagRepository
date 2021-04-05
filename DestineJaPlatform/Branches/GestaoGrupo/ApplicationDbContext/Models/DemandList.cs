using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ApplicationDbContext.Models
{
    public class DemandList
    {
        [Key]
        public int DemandId { get; set; }
        public DateTime ArriveDate { get; set; }
        public DateTime DepartureDate { get; set; }
        public int RouteId { get; set; }
        public string RouteName { get; set; }
        public int DemandStatusId { get; set; }
        public string DemandStatusName { get; set; }
        public int TotalClient { get; set; }
        public bool Closed { get; set; }
        public double TotalWeight { get; set; }
        public DateTime CreatedDate { get; set; }
        public string DemandDestinationIds { get; set; }
        public string DemandClientCompanyNames { get; set; }
        public string DemandClientTradeNames { get; set; }
        public string AlternativeDemandId { get; set; }
        public bool Cancel { get; set; }
        public bool IsDeleted { get; set; }
    }
}
