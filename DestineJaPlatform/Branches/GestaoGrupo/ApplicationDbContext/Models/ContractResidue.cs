using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationDbContext.Models
{
    public class ContractResidue
    {
        public int ContractResidueId { get; set; }
        public int ContractId { get; set; }
        public int ResidueId { get; set; }
        public double Price { get; set; }
        public double? MinimumPrice { get; set; }
        public double? MediumPrice { get; set; }
        public double? MaximumPrice { get; set; }
        public bool Charge { get; set; }
        public bool DeductFromFranchise { get; set; }
        public int UnitOfMeasurementId { get; set; }
        public DateTime CreatedDate { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime? DeletedDate { get; set; }
        public int? DeletedBy { get; set; }
    }
}
