using DTO.Plan;
using DTO.PlanCoverageType;
using DTO.Subscription;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WEB.Models.Subscription.Plan
{
    public class ChoosePlanViewModel
    {
        public SubscriptionViewModel Subscription { get; set; }
        public List<PlanCoverageTypeViewModel> PlanCoverageTypes { get; set; }
        public List<PlanInfoViewModel> Plans { get; set; }
    }
}
