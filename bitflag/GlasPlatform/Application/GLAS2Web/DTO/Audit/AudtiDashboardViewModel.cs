using System;
using System.Collections.Generic;
using System.Text;

namespace DTO.Audit
{
    public class AudtiDashboardViewModel
    {
        public DateTime? StartDate { get; set; }
        public string Status { get; set; }
        public DateTime? ScheduleDate { get; set; }
    }
}
