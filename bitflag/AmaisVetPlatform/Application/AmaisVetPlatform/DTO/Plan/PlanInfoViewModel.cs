using DTO.Extensions;
using DTO.PlanCoverage;
using System;
using System.Collections.Generic;
using System.Text;

namespace DTO.Plan
{
    public class PlanInfoViewModel
    {
        public int PlanId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double MonthlyCost { get; set; }
        public string MonthlyCostFormatted { get { return MonthlyCost.ToMoney(); } }
        public Dictionary<int, PlanCoverageViewModel> Coverages { get; set; }
        public string PaymentGatewayExternalCode { get; set; }

        public PlanInfoViewModel()
        {
            this.Coverages = new Dictionary<int, PlanCoverageViewModel>();
        }
    }
}
