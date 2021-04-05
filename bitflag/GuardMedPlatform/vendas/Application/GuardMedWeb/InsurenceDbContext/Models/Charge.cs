using System;
using System.Collections.Generic;

namespace InsurenceDbContext.Models
{
    public partial class Charge
    {
        public int ChargeId { get; set; }
        public int RealEstateId { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public DateTime ReferenceDate { get; set; }
        public DateTime DueDate { get; set; }
        public DateTime CreateDate { get; set; }
        public string Iuguurl { get; set; }
        public bool IsPayed { get; set; }
        public DateTime? PayedDate { get; set; }
        public string PayedToken { get; set; }
        public string IuguinvoiceId { get; set; }
        public int? PayedBy { get; set; }
    }
}
