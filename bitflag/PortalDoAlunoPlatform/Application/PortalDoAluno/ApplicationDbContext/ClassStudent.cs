using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace ApplicationDbContext
{
    public partial class ClassStudent
    {
        public int ClassStudentId { get; set; }
        public int ClassId { get; set; }
        public int StudentId { get; set; }
        public string ASAAS_customer_id { get; set; }
    }
}
