using System;
using System.Collections.Generic;
using System.Text;

namespace DAL
{
    public class AuditStatus
    {
        public int AuditStatusId { get; set; }
        public string ExternalCode { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
