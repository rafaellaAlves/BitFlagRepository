﻿using System;
using System.Collections.Generic;

namespace AMaisImob_DB.Models
{
    public partial class ProductAssistance
    {
        public int ProductAssistanceId { get; set; }
        public int ProductId { get; set; }
        public int AssistanceId { get; set; }
    }
}
