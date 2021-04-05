using System;
using System.Collections.Generic;

namespace InsurenceDbContext.Models
{
    public partial class ProductAssistance
    {
        public int ProductAssistanceId { get; set; }
        public int ProductId { get; set; }
        public int AssistanceId { get; set; }
    }
}
