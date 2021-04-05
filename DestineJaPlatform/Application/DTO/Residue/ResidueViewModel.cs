using System;
using System.Collections.Generic;
using System.Text;
using DTO.Utils;

namespace DTO.Residue
{
    public class ResidueViewModel
    {
        public int? ResidueId { get; set; }
        public int ResidueFamilyId { get; set; }
        [Update]
        public string Name { get; set; }
        [Update]
        public string IBAMACode { get; set; }
        [Update]
        public int UnitOfMeasurementId { get; set; }
        [Update]
        public int PhysicalStateId { get; set; }
        [Update]
        public int PackagingId { get; set; }
        [Update]
        public int? ResidueDestinationTypeId { get; set; }
        public DateTime CreatedDate { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime? DeletedDate { get; set; }
        public int? DeletedBy { get; set; }
    }
}
