using System;
using System.Collections.Generic;

namespace DB
{
    public partial class ServiceType
    {
        public int ServiceTypeId { get; set; }
        public string Name { get; set; }
        public string ExternalCode { get; set; }
        public bool IsDeleted { get; set; }
        public string Description { get; set; }
    }
}
