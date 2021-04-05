using System;
using System.Collections.Generic;
using System.Text;

namespace DAL
{
    public class Audit : Shared.BaseEntity
    {
        public int AuditId { get; set; }
        public int CompanyId { get; set; }
        public string Objective { get; set; }
        public string LeaderAuditor { get; set; }
        public string CoAuditors { get; set; }
        public string Participants { get; set; }
        public string Scope { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? ConclusionDate { get; set; }
        public DateTime? ScheduleDate { get; set; }
        public int? AuditTypeId { get; set; }
        public int? SegmentoId { get; set; }
        public int? AuditStatusId { get; set; }
        public string Description { get; set; }
    }
}
