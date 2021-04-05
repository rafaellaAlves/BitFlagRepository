using System;
using System.Collections.Generic;
using System.Text;

namespace DB
{
    public class RDStationLog
    {
        public int RDStationLogId { get; set; }
        public string Uuid { get; set; }
        public int? ClientId { get; set; }
        public bool Success { get; set; }
        public string Message { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
