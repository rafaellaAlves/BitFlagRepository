using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DAL
{
    public class Translation
    {
        [Key]
        public int TranslationId { get; set; }
        public string Key { get; set; }
        public string PT_BR { get; set; }
        public string ES_ES { get; set; }
    }
}
