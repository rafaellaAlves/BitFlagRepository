using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationDbContext.Models
{
    public class ServiceResidueFamilyPrice
    {
        public int ServiceResidueFamilyPriceId { get; set; }
        public int ServiceId { get; set; }
        public int ResidueFamilyId { get; set; }
        public double Price { get; set; }
        public int UnitOfMeasurementId { get; set; }
        public double? MinimumPrice { get; set; }
        public double? MediumPrice { get; set; }
        public double? MaximumPrice { get; set; }
    }
}
