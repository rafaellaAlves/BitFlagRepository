using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationDbContext.Models
{
    public class DemandResidueFamily
    {
        public int DemandResidueFamilyId { get; set; }
        public int DemandId { get; set; }
        public int ResidueFamilyId { get; set; }
        public int ClientCollectionAddressId { get; set; }
    }
}