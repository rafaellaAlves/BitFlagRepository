using System;
using System.Collections.Generic;

namespace AMaisImob_DB.Models
{
    public partial class CompanyDocuSign
    {
        public int CompanyDocuSignId { get; set; }
        public int CompanyId { get; set; }
        public DateTime ReferenceDate { get; set; }
        public int Amount { get; set; }
        public double Price { get; set; }
        public int CategoryId { get; set; }
        public DateTime CreatedDate { get; set; }
        public int CreatedBy { get; set; }
    }
}
