using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationDbContext.Models
{
    public class DemandDestinationDemand
    {
        public int DemandDestinationDemandId { get; set; }
        public int DemandId { get; set; }
        public int DemandDestinationId { get; set; }
    }
}
