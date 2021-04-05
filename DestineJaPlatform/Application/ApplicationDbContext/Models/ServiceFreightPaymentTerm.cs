using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationDbContext.Models
{
    public class ServiceFreightPaymentTerm : Shared.ListBase
    {
        public int ServiceFreightPaymentTermId { get; set; }
        public int Order { get; set; }
        public string Days { get; set; }
    }
}
