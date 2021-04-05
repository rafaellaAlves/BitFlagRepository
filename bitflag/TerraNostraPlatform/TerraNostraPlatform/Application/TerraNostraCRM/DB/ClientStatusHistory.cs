using System;
using System.Collections.Generic;

namespace DB
{
    public partial class ClientStatusHistory
    {
        public int ClientStatusHistoryId { get; set; }
        public int ClientStatusId { get; set; }
        public int ClientId { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
