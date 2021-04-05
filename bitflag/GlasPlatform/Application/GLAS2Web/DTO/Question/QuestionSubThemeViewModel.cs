using System;
using System.Collections.Generic;
using System.Text;

namespace DTO.Question
{
    public class QuestionSubThemeViewModel
    {
        public int? QuestionSubThemeId { get; set; }
        public int? QuestionThemeId { get; set; }
        public string Name { get; set; }
        public string Cause { get; set; }
        public string Effect { get; set; }
        public string Control { get; set; }
        public DateTime CreatedDate { get; set; }
        public bool IsDeleted { get; set; }
    }
}