using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ApplicationDbContext.Models
{
    public class ServiceList
    {
        [Key]
        public int ServiceId { get; set; }
        public string Code { get; set; }
        public int ClientId { get; set; }
        public string ClientName { get; set; }
        public string TradeName { get; set; }
        public double Weight { get; set; }
        public DateTime? CollectionDate { get; set; }
        public int ServiceStatusId { get; set; }
        public int ServiceSituationId { get; set; }
        public string StatusName { get; set; }
        public bool HasServiceOrderFile { get; set; }
        public bool IsDeleted { get; set; }
        public double TotalPrice { get; set; }
        public double? ResiduePrice { get; set; }
        public DateTime CreatedDate { get; set; }
        public string DemandIds { get; set; }
        public string DemandDestinationIds { get; set; }
        public bool IsActive { get; set; }
    }
}
