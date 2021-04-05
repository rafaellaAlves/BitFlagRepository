using System;
using System.Collections.Generic;

namespace AMaisImob_DB.Models
{
    public partial class CompanyType
    {
        public int CompanyTypeId { get; set; }
        public string Name { get; set; }
        public bool? IsActive { get; set; }
        public string ExternalCode { get; set; }
    }
}
