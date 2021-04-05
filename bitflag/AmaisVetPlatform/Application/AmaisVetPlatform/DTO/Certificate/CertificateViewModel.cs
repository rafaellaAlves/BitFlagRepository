using DTO.Subscription;
using System;
using System.Collections.Generic;
using System.Text;

namespace DTO.Certificate
{
    public class CertificateViewModel
    {
        public SubscriptionViewModel Subscription { get; set; }
        public Plan.PlanInfoViewModel Plan { get; set; }
        public CertificateViewModel() { }
        public CertificateViewModel(SubscriptionViewModel subscription, Plan.PlanInfoViewModel plan)
        {
            this.Subscription = subscription;
            this.Plan = plan;
        }
    }
}
