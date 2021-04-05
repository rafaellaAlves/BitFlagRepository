using System;
using System.Collections.Generic;
using System.Text;

namespace DTO.Question
{
    public class QuestionThemeViewModel
    {
        public int? QuestionThemeId { get; set; }
        public string Name { get; set; }
        public DateTime CreatedDate { get; set; }
        public bool IsDeleted { get; set; }
    }
}