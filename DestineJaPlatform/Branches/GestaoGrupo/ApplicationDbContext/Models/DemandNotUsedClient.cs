using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationDbContext.Models
{
    public class DemandNotUsedClient
    {
        public int DemandNotUsedClientId { get; set; }
        public int DemandId { get; set; }
        public int ClientCollectionAddressId { get; set; }
    }
}
