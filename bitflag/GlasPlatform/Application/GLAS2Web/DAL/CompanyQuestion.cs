using System;
using System.Collections.Generic;
using System.Text;

namespace DAL
{
    public class CompanyQuestion
    {
        public int CompanyQuestionId { get; set; }
        public int CompanyId { get; set; }
        public int QuestionId { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
