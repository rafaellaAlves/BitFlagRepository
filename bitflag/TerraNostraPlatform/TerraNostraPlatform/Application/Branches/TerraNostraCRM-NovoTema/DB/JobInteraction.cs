using System;
using System.Collections.Generic;

namespace DB
{
    public partial class JobInteraction
    {
        public int JobInteractionId { get; set; }
        public int JobId { get; set; }
        public int StepId { get; set; }
        public string Message { get; set; }
        public int? UserId { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
