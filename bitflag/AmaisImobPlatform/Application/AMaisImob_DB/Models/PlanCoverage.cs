using System;
using System.Collections.Generic;

namespace AMaisImob_DB.Models
{
    public partial class PlanCoverage
    {
        public int PlanCoverageId { get; set; }
        public int PlanId { get; set; }
        public int ProductCoverageId { get; set; }
        public bool Used { get; set; }
        public double? Garantia { get; set; }
    }
}
