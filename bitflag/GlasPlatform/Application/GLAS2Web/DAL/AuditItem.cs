using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DAL
{
    public class AuditItem : Shared.BaseEntity
    {
        [Key]
        public int AuditItemId { get; set; }
        public int AuditId { get; set; }
        public int? CompanyLawId { get; set; }
        public int? CompanyLawActionId { get; set; }
        public int? AuditItemStatusId { get; set; }
        public string Comments { get; set; }
    }
}
