using System;
using System.Collections.Generic;

namespace DB
{
    public partial class ClientType
    {
        public int ClientTypeId { get; set; }
        public string Name { get; set; }
        public bool? IsActive { get; set; }
        public string ExternalCode { get; set; }
    }
}
