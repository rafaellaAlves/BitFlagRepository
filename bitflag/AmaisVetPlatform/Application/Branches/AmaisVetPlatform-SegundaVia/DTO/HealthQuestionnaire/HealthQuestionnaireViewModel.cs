using System;
using System.Collections.Generic;
using System.Text;

namespace DTO.HealthQuestionnaire
{
    public class HealthQuestionnaireViewModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int Version { get; set; }
        public List<HealthQuestionnaireQuestionViewModel> Questions { get; set; }

        public HealthQuestionnaireViewModel()
        {
            this.Questions = new List<HealthQuestionnaireQuestionViewModel>();
        }
    }
}
