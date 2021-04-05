using System;
using System.Collections.Generic;

namespace DB
{
    public partial class InvoiceServiceType
    {
        public int InvoiceServiceTypeId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int WorkflowId { get; set; }
    }
}
