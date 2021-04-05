using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DB.Models
{
    public class AuditLog
    {
        [Key]
        public int AuditLogId { get; set; }
        public string EntityName { get; set; }
        public int EntityId { get; set; }
        public string EntityKey { get; set; }
        public string ActionType { get; set; } //enum: Create, update, Delete - ActionType
        public string Observation { get; set; }
        public string Entity { get; set; } // salvar string json com todos valores do truck - Entity
        public DateTime CreatedDate { get; set; } // Data atual
        public int OwnerId { get; set; } //id do usuario que fez a alteração
    }
}
