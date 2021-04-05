using System;
using System.Collections.Generic;
using System.Text;

namespace DTO.CompanyQuestion
{
    public class CompanyQuestionViewModel
    {
        public int? CompanyQuestionId { get; set; }
        public int CompanyId { get; set; }
        public int QuestionId { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
