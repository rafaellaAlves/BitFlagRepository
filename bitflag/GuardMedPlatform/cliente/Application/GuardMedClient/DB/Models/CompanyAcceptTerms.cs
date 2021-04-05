using System;
using System.Collections.Generic;
using System.Text;

namespace DB.Models
{
    public class CompanyAcceptTerms
    {
        public int CompanyAcceptTermsId { get; set; }
        public int CompanyId { get; set; }
        public string FileName { get; set; }
        public string Email { get; set; }
        public DateTime CreatedDate { get; set; }
        public int SentBy { get; set; }
    }
}
