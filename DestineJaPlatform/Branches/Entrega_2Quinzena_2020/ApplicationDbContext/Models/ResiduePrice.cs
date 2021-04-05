using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationDbContext.Models
{
    public class ResiduePrice
    {
        public int ResiduePriceId { get; set; }
        public int ResidueFamilyId { get; set; }
        public int RecipientId { get; set; }
        public int UnitOfMeasurementId { get; set; }
        public double Price { get; set; }
        public DateTime CreatedDate { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime? DeletedDate { get; set; }
        public int? DeletedBy { get; set; }
    }
}
