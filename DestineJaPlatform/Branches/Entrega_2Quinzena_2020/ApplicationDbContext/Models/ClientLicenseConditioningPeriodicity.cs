using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationDbContext.Models
{
    public class ClientLicenseConditioningPeriodicity
    {
        public int ClientLicenseConditioningPeriodicityId { get; set; }
        public string Name { get; set; }
        public string ExternalCode { get; set; }
        public int Order { get; set; }
        public int? Days { get; set; }
        public int? Months { get; set; }
    }
}
