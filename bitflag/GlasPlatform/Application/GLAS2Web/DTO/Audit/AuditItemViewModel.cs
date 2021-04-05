using System;
using System.Collections.Generic;
using System.Text;
using DAL;

namespace DTO.Audit
{
    public class AuditItemViewModel
    {
        public int? AuditItemId { get; set; }
        public int AuditId { get; set; }
        public int? CompanyLawId { get; set; }
        public int? CompanyLawActionId { get; set; }
        public int? AuditItemStatusId { get; set; }
        public string Comments { get; set; }

        public CompanyLawView CompanyLawView { get; set; }
    }
}
