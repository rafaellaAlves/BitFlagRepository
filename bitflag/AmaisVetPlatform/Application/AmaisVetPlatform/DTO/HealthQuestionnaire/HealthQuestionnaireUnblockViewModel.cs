using DTO.Plan;
using DTO.Subscription;
using System;
using System.Collections.Generic;
using System.Text;

namespace DTO.HealthQuestionnaire
{
    public class HealthQuestionnaireUnblockViewModel
    {
        public SubscriptionViewModel Subscription { get; set; }
        public PlanInfoViewModel Plan { get; set; }
        public Guid Token { get; set; }
        public HealthQuestionnaireUnblockViewModel() { }
        public HealthQuestionnaireUnblockViewModel(SubscriptionViewModel subscription, PlanInfoViewModel plan, Guid token) 
        {
            this.Subscription = subscription;
            this.Plan = plan;
            this.Token = token;
        }
    }
}
