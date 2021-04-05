using WEB.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WEB.Models
{
    public class AuditLogItemViewModel
    {
        public int EntityId { get; set; }
        public DateTime? Date { get; set; }
        public string _Date { get { return Date.ToDateTimePtBR(); } set { Date = (DateTime)value.FromDatePtBR(); } }
        public string ActionType { get; set; }
        public int LastHandler { get; set; }
        public string LastHandlerName { get; set; }
        public string Observation { get; set; }
        public List<AuditChangeItemViewModel> AuditChangeItens { get; set; }
    }
}
