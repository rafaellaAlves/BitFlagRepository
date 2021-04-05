using System;
using System.Collections.Generic;
using System.Text;

namespace DAL
{
    public class QuestionTheme
    {
        public int QuestionThemeId { get; set; }
        public string Name { get; set; }
        public DateTime CreatedDate { get; set; }
        public bool IsDeleted { get; set; }
    }
}
