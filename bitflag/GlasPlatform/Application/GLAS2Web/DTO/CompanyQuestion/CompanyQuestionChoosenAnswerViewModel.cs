using System;
using System.Collections.Generic;
using System.Text;

namespace DTO.CompanyQuestion
{
    public class CompanyQuestionChoosenAnswerViewModel
    {
        public int? CompanyQuestionChoosenAnswerId { get; set; }
        public int CompanyId { get; set; }
        public int QuestionId { get; set; }
        public string Observation { get; set; }
        public DateTime CreatedDate { get; set; }

        public List<CompanyQuestionChoosenAnswerItemViewModel> Answers { get; set; }
    }
}
