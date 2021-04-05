using System;
using System.Collections.Generic;

namespace DB
{
    public partial class ClientDependentType
    {
        public int ClientDependentTypeId { get; set; }
        public string Name { get; set; }
        public string ExternalCode { get; set; }
        public bool? IsActive { get; set; }
    }
}
