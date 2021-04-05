using System;
using System.Collections.Generic;

namespace DB
{
    public partial class Workflow
    {
        public int WorkflowId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string LinkedServiceType { get; set; }
    }
}
