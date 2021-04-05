using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace ApplicationDbContext
{
    public partial class StudentPresenceSituation
    {
        public int StudentPresenceId { get; set; }
        public int ClassStudentId { get; set; }
        public int Module { get; set; }
        public int? Saturday { get; set; }
        public DateTime? SaturdayDate { get; set; }
        public string SaturdayComments { get; set; }
        public int? Sunday { get; set; }
        public DateTime? SundayDate { get; set; }
        public string SundayComments { get; set; }
        public double? TestGrade { get; set; }
        public double? ActivityGrade { get; set; }
        public int? CompletionPercent { get; set; }
        public string Comments { get; set; }
    }
}
