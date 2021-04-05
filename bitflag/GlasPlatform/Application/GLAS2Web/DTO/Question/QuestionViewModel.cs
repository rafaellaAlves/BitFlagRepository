using System;
using System.Collections.Generic;
using System.Text;

namespace DTO.Question
{
    public class QuestionViewModel
    {
        public int? QuestionId { get; set; }
        public int? QuestionThemeId { get; set; }
        public string QuestionText { get; set; }
        public int Order { get; set; }
        public DateTime CreatedDate { get; set; }
        public bool IsDeleted { get; set; }
    }
}