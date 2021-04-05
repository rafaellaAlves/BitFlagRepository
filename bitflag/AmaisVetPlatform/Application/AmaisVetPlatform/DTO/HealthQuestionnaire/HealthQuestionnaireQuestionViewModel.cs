using System;
using System.Collections.Generic;
using System.Text;

namespace DTO.HealthQuestionnaire
{
    public class HealthQuestionnaireQuestionViewModel
    {
        public int HealthQuestionnaireQuestionId { get; set; }
        public string Description { get; set; }
        public List<HealthQuestionnaireOptionViewModel> Options { get; set; }

        public HealthQuestionnaireQuestionViewModel()
        {
            this.Options = new List<HealthQuestionnaireOptionViewModel>();
        }
    }
}
