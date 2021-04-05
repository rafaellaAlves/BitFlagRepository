using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationDbContext.Models
{
    public class DemandDestinationStatus : Shared.ListBase
    {
        public int DemandDestinationStatusId { get; set; }
        public int Order { get; set; }
    }
}
