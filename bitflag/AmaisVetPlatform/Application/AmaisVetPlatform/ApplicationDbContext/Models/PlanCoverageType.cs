﻿using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace ApplicationDbContext.Models
{
    public partial class PlanCoverageType
    {
        public int PlanCoverageTypeId { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; }
    }
}
