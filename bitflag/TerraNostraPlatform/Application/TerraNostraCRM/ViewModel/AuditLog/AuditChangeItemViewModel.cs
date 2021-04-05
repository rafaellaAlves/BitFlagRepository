using System;
using System.Collections.Generic;
using System.Text;

namespace DTO.AuditLog
{
    public class AuditChangeItemViewModel
    {
        public string Propriety { get; set; }
        public string MaskClass { get; set; }
        public string OldValue { get; set; }
        public string Value { get; set; }
    }
}
