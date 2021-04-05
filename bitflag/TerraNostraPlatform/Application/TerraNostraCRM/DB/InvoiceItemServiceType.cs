using System;
using System.Collections.Generic;

namespace DB
{
    public partial class InvoiceItemServiceType
    {
        public int InvoiceItemServiceTypeId { get; set; }
        public string Name { get; set; }
        public bool IsCredit { get; set; }
        public double? Value { get; set; }
        public bool? IsActive { get; set; }
        public int Order { get; set; }
    }
}
