using DTO.HealthQuestionnaire;
using DTO.Subscription;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WEB.Models.Subscription.Questionnaire
{
    public class QuestionnaireViewModel
    {
        public SubscriptionViewModel Subscription { get; set; }
        public HealthQuestionnaireViewModel HealthQuestionnaire { get; set; }
        public List<QuestionResponseViewModel> HealthQuestionnaireResponses { get; internal set; }
    }
}
