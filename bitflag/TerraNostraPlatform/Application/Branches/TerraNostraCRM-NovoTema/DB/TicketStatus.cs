using System;
using System.Collections.Generic;

namespace DB
{
    public partial class TicketStatus
    {
        public int TicketStatusId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ExternalCode { get; set; }
    }
}
