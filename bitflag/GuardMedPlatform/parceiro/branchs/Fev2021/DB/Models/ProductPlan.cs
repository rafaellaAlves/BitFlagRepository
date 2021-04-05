using System;
using System.Collections.Generic;

namespace DB.Models
{
    public partial class ProductPlan
    {
        public int ProductPlanId { get; set; }
        public int ProductId { get; set; }
        public int PlanId { get; set; }
    }
}
