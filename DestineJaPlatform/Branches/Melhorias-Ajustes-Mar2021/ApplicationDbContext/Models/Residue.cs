using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationDbContext.Models
{
    public class Residue
    {
        public int ResidueId { get; set; }
        public int ResidueFamilyId { get; set; }
        public string Name { get; set; }
        public string IBAMACode { get; set; }
        public int UnitOfMeasurementId { get; set; }
        public int PhysicalStateId { get; set; }
        public int PackagingId { get; set; }
        public int? ResidueDestinationTypeId { get; set; }
        public DateTime CreatedDate { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime? DeletedDate { get; set; }
        public int? DeletedBy { get; set; }
    }                                   
}
