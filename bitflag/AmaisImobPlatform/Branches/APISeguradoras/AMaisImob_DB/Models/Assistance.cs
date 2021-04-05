﻿using System;
using System.Collections.Generic;

namespace AMaisImob_DB.Models
{
    public partial class Assistance
    {
        public int AssistanceId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Value { get; set; }
        public bool IsDeleted { get; set; }
        public string ReportCode { get; set; }
    }
}
