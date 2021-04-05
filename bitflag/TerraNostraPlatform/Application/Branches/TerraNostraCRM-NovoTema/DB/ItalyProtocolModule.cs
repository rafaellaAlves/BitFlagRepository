using System;
using System.Collections.Generic;

namespace DB
{
    public partial class ItalyProtocolModule
    {
        public int ItalyProtocolId { get; set; }
        public int JobId { get; set; }
        public DateTime SentDate { get; set; }
        public int LastHandler { get; set; }
    }
}
