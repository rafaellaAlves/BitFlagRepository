using System;
using System.Collections.Generic;
using System.Text;

namespace AMaisImob_DB.Models
{
    public class MartialStatus
    {
        public int MartialStatusId { get; set; }
        public string Name { get; set; }
        public string ExternalCode { get; set; }
        public int Order { get; set; }
    }
}
