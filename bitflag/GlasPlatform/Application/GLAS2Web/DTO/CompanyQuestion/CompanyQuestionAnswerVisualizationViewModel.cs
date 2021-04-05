using System;
using System.Collections.Generic;
using System.Text;

namespace DTO.CompanyQuestion
{
    public class CompanyQuestionAnswerVisualizationViewModel
    {
        public int QuestionId { get; set; }
        public string QuestionText { get; set; }
        public int QuestionOrder { get; set; }
        public int QuestionAnswerId { get; set; }
        public string QuestionAnswerText { get; set; }
        public int QuestionAnswerOrder { get; set; }
        public int QuestionThemeId { get; set; }
        public string QuestionThemeName { get; set; }
        public int QuestionSubThemeId { get; set; }
        public string QuestionSubThemeName { get; set; }
        public bool Selected { get; set; }
        public string Observation { get; set; }
    }
}
