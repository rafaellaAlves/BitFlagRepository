using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DAL
{
    public class QuestionList
    {
        [Key]
        public int QuestionId { get; set; }
        public int QuestionThemeId { get; set; }
        public string QuestionText { get; set; }
        public int Order { get; set; }
        public DateTime CreatedDate { get; set; }
        public bool IsDeleted { get; set; }
        public string QuestionThemeName { get; set; }
        public DateTime QuestionThemeCreatedDate { get; set; }
        public bool QuestionThemeIsDeleted { get; set; }
    }
}
