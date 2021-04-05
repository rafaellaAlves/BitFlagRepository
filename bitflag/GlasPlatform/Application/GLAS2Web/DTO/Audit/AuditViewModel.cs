using System;
using System.Collections.Generic;
using System.Text;

namespace DTO.Audit
{
    public class AuditViewModel
    {
        public int? AuditId { get; set; }
        public int CompanyId { get; set; }
        public string Objective { get; set; }
        public string LeaderAuditor { get; set; }
        public string CoAuditors { get; set; }
        public string Participants { get; set; }
        public string Scope { get; set; }
        public string StartDate { get; set; }
        public string ConclusionDate { get; set; }
        public string ScheduleDate { get; set; }
        public int? AuditTypeId { get; set; }
        public string AuditTypeName { get; set; }
        public int? SegmentoId { get; set; }
        public string SegmentoName { get; set; }
        public int? AuditStatusId { get; set; }
        public string AuditStatusName { get; set; }
        public string Description { get; set; }
        public string CreateDate { get; set; }

        public List<int> CompanyLaws { get; set; }
    }
}
