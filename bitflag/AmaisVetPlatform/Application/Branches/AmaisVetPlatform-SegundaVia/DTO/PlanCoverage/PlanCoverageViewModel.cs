using DTO.PlanCoverageType;
using System;
using System.Collections.Generic;
using System.Text;

namespace DTO.PlanCoverage
{
    public class PlanCoverageViewModel
    {
        public PlanCoverageTypeViewModel planCoverageTypeViewModel { get; set; }
        public string Description { get; set; }
    }
}
