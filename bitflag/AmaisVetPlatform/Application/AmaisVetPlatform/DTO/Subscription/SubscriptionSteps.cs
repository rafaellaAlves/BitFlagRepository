using System;
using System.Collections.Generic;
using System.Text;

namespace DTO.Subscription
{
    public enum SubscriptionSteps
    {
        Plans,
        HealthQuestionnaire,
        HealthQuestionnaireBlock,
        HealthQuestionnaireUnblock,
        Payment,
        Certificate,
        None
    }
}
