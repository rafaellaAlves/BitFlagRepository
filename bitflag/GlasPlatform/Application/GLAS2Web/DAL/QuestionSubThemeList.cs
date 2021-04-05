using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DAL
{
    public class QuestionSubThemeList
    {
        [Key]
        public int QuestionSubThemeId { get; set; }
        public int QuestionThemeId { get; set; }
        public string Name { get; set; }
        public string Cause { get; set; }
        public string Effect { get; set; }
        public string Control { get; set; }
        public DateTime CreatedDate { get; set; }
        public bool IsDeleted { get; set; }
        public string QuestionThemeName { get; set; }
        public DateTime QuestionThemeCreatedDate { get; set; }
        public bool QuestionThemeIsDeleted { get; set; }
    }
}
