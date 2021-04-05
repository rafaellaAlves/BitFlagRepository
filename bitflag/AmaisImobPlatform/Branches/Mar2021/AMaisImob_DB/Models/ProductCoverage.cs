using System;
using System.Collections.Generic;

namespace AMaisImob_DB.Models
{
    public partial class ProductCoverage
    {
        public int ProductCoverageId { get; set; }
        public int ProductId { get; set; }
        public string Name { get; set; }
        public double Taxes { get; set; }
        public double? Minimum { get; set; }
        public double? Maximum { get; set; }
        public bool IsBasic { get; set; }
        public double? BasicLimit { get; set; }
        public bool IsOptional { get; set; }
        public string Description { get; set; }
        public string Franquias { get; set; }
        public bool IsDeleted { get; set; }
    }
}
