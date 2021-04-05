using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ApplicationDbContext.Models
{
    public class DemandDestinationList
    {
        [Key]
        public int DemandDestinationId { get; set; }
        public string AlternativeDemandDestinationId { get; set; }
        public DateTime ArrivedDate { get; set; }
        public DateTime DepartureDate { get; set; }
        public bool Finished { get; set; }
        public bool IsDeleted { get; set; }
        public string CompanyName { get; set; }
        public string ResidueFamilyName { get; set; }
        public string ResidueFamilyNameAbbreviation { get; set; }
        public string DemandDestintionStatusName { get; set; }
        public int demandDestintionStatusOrder { get; set; }
        public int? DemandDestinationStatusId { get; set; }
        public string CDF { get; set; }
        public string DemandIds { get; set; }
    }
}
