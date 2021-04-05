using System;
using System.Collections.Generic;

namespace DB
{
    public partial class ItalyProtocolAdditionalDocumentsModule
    {
        public int ItalyProtocolAdditionalDocumentsId { get; set; }
        public int JobId { get; set; }
        public string Documents { get; set; }
    }
}
