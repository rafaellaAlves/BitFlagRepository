using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace ApplicationDbContext
{
    public partial class AdministrativeSituation
    {
        public int IdParcel { get; set; }
        public int? StudentId { get; set; }
        public string MonthReference { get; set; }
        public DateTime? DueDate { get; set; }
        public double? ParcelValue { get; set; }
        public double? Discount { get; set; }
        public DateTime? PaymentDate { get; set; }
        public double? TotalValue { get; set; }
        public int? ParcelSituation { get; set; }
    }
}
