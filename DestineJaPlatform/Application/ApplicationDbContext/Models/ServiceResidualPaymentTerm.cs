using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationDbContext.Models
{
    public class ServiceResidualPaymentTerm : Shared.ListBase
    {
        public int ServiceResidualPaymentTermId { get; set; }
        public int Order { get; set; }
        public string Days { get; set; }
    }
}
