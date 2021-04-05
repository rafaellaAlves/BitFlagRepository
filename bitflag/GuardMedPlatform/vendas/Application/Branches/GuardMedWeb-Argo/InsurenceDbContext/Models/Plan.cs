using System;
using System.Collections.Generic;

namespace InsurenceDbContext.Models
{
    public partial class Plan
    {
        public int PlanId { get; set; }
        public int ProductId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool? IsDeleted { get; set; }
        public int? AssistanceId { get; set; }
        public int? CertificateId { get; set; }
    }
}
