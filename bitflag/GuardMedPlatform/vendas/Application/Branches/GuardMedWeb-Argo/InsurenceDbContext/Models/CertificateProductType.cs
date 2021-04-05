using System;
using System.Collections.Generic;

namespace InsurenceDbContext.Models
{
    public partial class CertificateProductType
    {
        public int CertificateProductTypeId { get; set; }
        public string Name { get; set; }
        public bool? IsActive { get; set; }
        public string ExternalCode { get; set; }
    }
}
