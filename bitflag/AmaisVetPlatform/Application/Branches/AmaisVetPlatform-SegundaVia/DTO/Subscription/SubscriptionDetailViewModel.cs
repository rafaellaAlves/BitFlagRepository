using System;
using System.Collections.Generic;
using System.Text;

namespace DTO.Subscription
{
    public class SubscriptionDetailViewModel
    {
        public int PlanId { get; set; }
        public string PlanName { get; set; }
        public decimal Price { get; set; }
    }
}
