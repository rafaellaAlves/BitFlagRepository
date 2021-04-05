using System;
using System.Collections.Generic;

namespace InsurenceDbContext.Models
{
    public partial class InsurancePolicy
    {
        public int InsurancePolicyId { get; set; }
        public string InsurancePolicyNumber { get; set; }
        public int CompanyId { get; set; }
        public int ProductId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public DateTime? StartRegisteredDate { get; set; }
        public DateTime? EndRegisteredDate { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public bool IsDeleted { get; set; }
    }
}
