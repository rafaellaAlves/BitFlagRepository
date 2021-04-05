using System;
using System.Collections.Generic;

namespace DB
{
    public partial class InvoiceItem
    {
        public int InvoiceItemId { get; set; }
        public int InvoiceId { get; set; }
        public int InvoiceItemServiceTypeId { get; set; }
        public double Value { get; set; }
    }
}
