using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DAL
{
    public class QuestionAnswerList
    {
        [Key]
        public int QuestionAnswerId { get; set; }
        public int QuestionId { get; set; }
        public int QuestionSubThemeId { get; set; }
        public string Answer { get; set; }
        public int Order { get; set; }
        public DateTime CreatedDate { get; set; }
        public bool IsDeleted { get; set; }
        public int QuestionThemeId { get; set; }
        public string QuestionSubThemeName { get; set; }
        public string QuestionSubThemeCause { get; set; }
        public string QuestionSubThemeEffect { get; set; }
        public string QuestionSubThemeControl { get; set; }
        public DateTime QuestionSubThemeCreatedDate { get; set; }
        public bool QuestionSubThemeIsDeleted { get; set; }
    }
}
