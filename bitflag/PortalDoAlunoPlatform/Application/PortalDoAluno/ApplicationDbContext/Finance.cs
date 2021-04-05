using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace ApplicationDbContext
{
    public partial class Finance
    {
        public int FinanceId { get; set; }
        public int ClassStudentId { get; set; }
        public string DueDate { get; set; }
        public string Payment { get; set; }
        public string Installment { get; set; }
    }
}
