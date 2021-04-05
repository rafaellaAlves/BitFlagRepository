using System;
using System.Collections.Generic;
using System.Text;

namespace DTO.ServiceType
{
    public class ServiceTypeViewModel
    {
        public int? ServiceTypeId { get; set; }
        public string Name { get; set; }
        public string ExternalCode { get; set; }
        public bool IsDeleted { get; set; }
        public string Description { get; set; }
    }
}
