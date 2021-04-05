using System;
using System.Collections.Generic;
using System.Text;

namespace DTO.CompanyQuestion
{
    public class CompanyQuestionAnswerViewModel
    {
        public int? CompanyQuestionAnswerId { get; set; }
        public int CompanyId { get; set; }
        public int QuestionAnswerId { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
