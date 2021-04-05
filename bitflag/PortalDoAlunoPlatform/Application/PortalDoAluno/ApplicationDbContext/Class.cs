using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace ApplicationDbContext
{
    public partial class Class
    {
        public int ClassId { get; set; }
        public int CourseId { get; set; }
        public int ModuleCount { get; set; }
        public string State { get; set; }
        public int Year { get; set; }
        public string Info { get; set; }
        public int? PeriodId { get; set; }
    }
}
