using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ApplicationDbContext.Models
{
    public class DemandClientResidueList
    {
        [Key]
        public int DemandClientResidueId { get; set; }
        public int DemandClientId { get; set; }
        public int DemandId { get; set; }
        public int RouteId { get; set; }
        public int ResidueId { get; set; }
        public string IBAMACode { get; set; }
        public string ResidueName { get; set; }
        public double Weight { get; set; }
        public string ResidueFamilyNameAbbreviation { get; set; }
        public string ResidueFamilyName { get; set; }
        public int? ResidueFamilyId { get; set; }
        public string RecipientName { get; set; }
        public string RecipientDocument { get; set; }
        public int UnitOfMeasurementId { get; set; }
        public string UnitOfMeasurementName { get; set; }
    }
}
