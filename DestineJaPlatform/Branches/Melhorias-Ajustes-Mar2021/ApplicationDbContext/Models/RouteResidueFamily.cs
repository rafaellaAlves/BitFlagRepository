using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationDbContext.Models
{
    public class RouteResidueFamily
    {
        public int RouteResidueFamilyId { get; set; }
        public int RouteId { get; set; }
        public int ResidueFamilyId { get; set; }
        public int ClientCollectionAddressId { get; set; }
    }
}
