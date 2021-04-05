using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace ApplicationDbContext
{
    public partial class Course
    {
        public int CourseId { get; set; }
        public string Name { get; set; }
        public int DefaultModuleCount { get; set; }
    }
}
