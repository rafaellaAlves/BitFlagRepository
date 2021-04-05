using System;
using System.Collections.Generic;

namespace InsurenceDbContext.Models
{
    public partial class RevenuesForm
    {
        public int RevenuesFormId { get; set; }
        public string Name { get; set; }
        public string ExternalCode { get; set; }
    }
}
