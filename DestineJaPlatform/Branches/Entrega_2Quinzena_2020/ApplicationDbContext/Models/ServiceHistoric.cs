using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ApplicationDbContext.Models
{
    public class ServiceHistoric
    {
        [Key]
        public int ServiceId { get; set; }
        public int ClientId { get; set; }
        public string Code { get; set; }
        public string DemandIds { get; set; }
        public string DemandDestinationIds { get; set; }
        public string CollectionDate { get; set; }
        public string Receptor { get; set; }
        public double Weight { get; set; }
        public double TotalPrice { get; set; }
        public DateTime? CreatedDate { get; set; }
    }
}
