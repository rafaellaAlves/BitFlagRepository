using System;
using System.Collections.Generic;

namespace DB.Models
{
    public partial class AuditLog
    {
        public int AuditLogId { get; set; }
        public string EntityName { get; set; }
        public int EntityId { get; set; }
        public string ActionType { get; set; }
        public string Entity { get; set; }
        public DateTime CreatedDate { get; set; }
        public int OwnerId { get; set; }
        public string EntityKey { get; set; }
        public string Observation { get; set; }
    }
}
