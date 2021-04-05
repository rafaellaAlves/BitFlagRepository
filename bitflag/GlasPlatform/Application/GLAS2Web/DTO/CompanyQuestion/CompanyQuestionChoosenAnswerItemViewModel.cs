using System;
using System.Collections.Generic;
using System.Text;

namespace DTO.CompanyQuestion
{
    public class CompanyQuestionChoosenAnswerItemViewModel
    {
        public int? CompanyQuestionChoosenAnswerItemId { get; set; }
        public int? CompanyQuestionChoosenAnswerId { get; set; }
        public int QuestionAnswerId { get; set; }
    }
}
