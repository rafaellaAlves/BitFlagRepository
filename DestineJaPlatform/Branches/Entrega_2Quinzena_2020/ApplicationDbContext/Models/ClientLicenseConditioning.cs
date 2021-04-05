using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationDbContext.Models
{
    public class ClientLicenseConditioning
    {
        public int ClientLicenseConditioningId { get; set; }
        public int ClientLicenseId { get; set; }
        public string Number { get; set; }
        public string Description { get; set; }
        public int DaysToRegularize { get; set; }
        public int DaysToNotify { get; set; }
        public int ClientLicenseConditioningPeriodicityId { get; set; }
        public string Protocol { get; set; }
        public DateTime? ProtocolDate { get; set; }
        public DateTime CreatedDate { get; set; }
        public bool IsDeleted { get; set; }
        public int? DeletedBy { get; set; }
        public DateTime? DeletedDate { get; set; }
    }
}
