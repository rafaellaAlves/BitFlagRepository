using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AMaisImob_WEB.Models
{
    public class AuditChangeItemViewModel
    {
        public string Propriety { get; set; }
        public string MaskClass { get; set; }
        public string OldValue { get; set; }
        public string Value { get; set; }
    }
}
