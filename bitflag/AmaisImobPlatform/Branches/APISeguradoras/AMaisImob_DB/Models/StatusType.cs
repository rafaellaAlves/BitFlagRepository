using System;
using System.Collections.Generic;

namespace AMaisImob_DB.Models
{
    public partial class StatusType
    {
        public int StatusTypeId { get; set; }
        public string StatusName { get; set; }
        public string ExternalCode { get; set; }
        public int Order { get; set; }
    }
}
