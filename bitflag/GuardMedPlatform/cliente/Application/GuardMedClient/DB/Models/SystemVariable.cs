using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DB.Models
{
    public class SystemVariable
    {
        [Key]
        public string Key { get; set; }
        public string Value { get; set; }
    }
}
