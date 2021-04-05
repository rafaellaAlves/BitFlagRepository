using System;
using System.Collections.Generic;

namespace DB
{
    public partial class Job
    {
        public int JobId { get; set; }
        public int ClientId { get; set; }
        public int? WorkflowId { get; set; }
        public int? CurrentStepId { get; set; }
        public DateTime CreatedDate { get; set; }
        public int? InvoiceId { get; set; }
    }
}
