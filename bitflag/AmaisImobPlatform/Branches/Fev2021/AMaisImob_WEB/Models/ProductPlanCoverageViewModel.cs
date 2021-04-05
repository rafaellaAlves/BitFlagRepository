using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AMaisImob_WEB.Models
{
    public class ProductPlanCoverageViewModel
    {
        public int ProductCoverageId { get; set; }
        public int PlanCoverageId { get; set; }
        public int PlanId { get; set; }
        public int ProductId { get; set; }
        public bool Used { get; set; }
        public double? Garantia { get; set; }
        public string _Garantia { get { return Garantia.HasValue ? Garantia.Value.ToString("#,##0.00") : null; } }
        public string Name { get; set; }
        public double? Taxes { get; set; }
        public string _Taxes { get { return Taxes.HasValue ? Taxes.Value.ToString("0.00000") : null; } }
        public double? Minimum { get; set; }
        public string _Minimum { get { return Minimum.HasValue ? Minimum.Value.ToString("#,##0.00") : null; } }
        public double? Maximum { get; set; }
        public string _Maximum { get { return Maximum.HasValue ? Maximum.Value.ToString("#,##0.00") : null; } }
        public bool IsBasic { get; set; }
        public double? BasicLimit { get; set; }
        public string _BasicLimit { get { return BasicLimit.HasValue ? BasicLimit.Value.ToString("0.00") : null; } }
        public bool IsOptional { get; set; }
        public string Description { get; set; }
        public string Franquias { get; set; }
        public bool IsDeleted { get; set; }
    }
}
