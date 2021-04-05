using System;
using System.Collections.Generic;
using System.Text;

namespace DTO.Audit
{
    public class AuditItemUpdateViewModel
    {
        public int AuditItemId { get; set; }
        public int AuditItemStatusId { get; set; }
        public string Comments { get; set; }
        public int CompanyLawId { get; set; }
        public int CompanyId { get; set; }
        public DateTime? CompanyLawRenewDate { get; set; }
        public DateTime? CompanyLawWarningDate { get; set; }
    }
}
