using System;
using System.Collections.Generic;

namespace InsurenceDbContext.Models
{
    public partial class Season
    {
        public int SeasonId { get; set; }
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool IsDeleted { get; set; }
    }
}
