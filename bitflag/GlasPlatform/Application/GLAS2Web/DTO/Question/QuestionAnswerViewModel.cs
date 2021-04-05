using System;
using System.Collections.Generic;
using System.Text;

namespace DTO.Question
{
    public class QuestionAnswerViewModel
    {
        public int? QuestionAnswerId { get; set; }
        public int? QuestionId { get; set; }
        public int? QuestionSubThemeId { get; set; }
        public string Answer { get; set; }
        public int Order { get; set; }
        public DateTime CreatedDate { get; set; }
        public bool IsDeleted { get; set; }
    }
}