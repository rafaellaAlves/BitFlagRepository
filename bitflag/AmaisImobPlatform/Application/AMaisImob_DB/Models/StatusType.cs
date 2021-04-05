using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace AMaisImob_DB.Models
{
    public class StatusType
    {
        [Key]
        public int StatusTypeId { get; set; }
        public string StatusName { get; set; }
        public string ExternalCode { get; set; }
        public int Order { get; set; }
    }
}
