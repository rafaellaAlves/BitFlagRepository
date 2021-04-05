using System;
using System.Collections.Generic;

namespace InsurenceDbContext.Models
{
    public partial class CompanyAcceptTerms
    {
        public int CompanyAcceptTermsId { get; set; }
        public int CompanyId { get; set; }
        public string FileName { get; set; }
        public string Email { get; set; }
        public DateTime CreatedDate { get; set; }
        public int SentBy { get; set; }
    }
}
