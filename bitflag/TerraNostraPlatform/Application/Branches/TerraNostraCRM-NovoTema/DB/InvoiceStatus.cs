using System;
using System.Collections.Generic;

namespace DB
{
    public partial class InvoiceStatus
    {
        public int InvoiceStatusId { get; set; }
        public string Name { get; set; }
        public string ExternalCode { get; set; }
    }
}
