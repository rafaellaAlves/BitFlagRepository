using System;
using System.Collections.Generic;
using System.Text;

namespace DAL
{
    public class AuditType
    {
        public int AuditTypeId { get; set; }
        public string ExternalCode { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
