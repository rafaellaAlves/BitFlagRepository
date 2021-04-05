using System;
using System.Collections.Generic;
using System.Text;

namespace DTO.AuditLog
{
    public class AuditLogItemViewModel
    {
        public int EntityId { get; set; }
        public DateTime Date { get; set; }
        public string ActionType { get; set; }
        public int LastHandler { get; set; }
        public string Observation { get; set; }
        public List<AuditChangeItemViewModel> AuditChangeItens { get; set; }
    }
}
