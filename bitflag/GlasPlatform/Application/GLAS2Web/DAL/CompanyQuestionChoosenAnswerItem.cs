using System;
using System.Collections.Generic;
using System.Text;

namespace DAL
{
    public class CompanyQuestionChoosenAnswerItem
    {
        public int CompanyQuestionChoosenAnswerItemId { get; set; }
        public int CompanyQuestionChoosenAnswerId { get; set; }
        public int QuestionAnswerId { get; set; }
    }
}