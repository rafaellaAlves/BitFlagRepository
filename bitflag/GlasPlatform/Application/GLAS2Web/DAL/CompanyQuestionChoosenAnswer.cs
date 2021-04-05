using System;
using System.Collections.Generic;
using System.Text;

namespace DAL
{
    public class CompanyQuestionChoosenAnswer
    {
        public int CompanyQuestionChoosenAnswerId { get; set; }
        public int CompanyId { get; set; }
        public int QuestionId { get; set; }
        public string Observation { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
