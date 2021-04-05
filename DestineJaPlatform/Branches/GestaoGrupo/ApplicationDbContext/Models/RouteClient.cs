using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationDbContext.Models
{
    public class RouteClient
    {
        public int RouteClientId { get; set; }
        public int RouteId { get; set; }
        public int ClientCollectionAddressId { get; set; }
        public int? ContractId { get; set; }
        public int? ServiceId { get; set; }
        public int Order { get; set; }
    }
}
