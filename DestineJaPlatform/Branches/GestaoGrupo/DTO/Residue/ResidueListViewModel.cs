using System;
using System.Collections.Generic;
using System.Text;
using DTO.Utils;

namespace DTO.Residue
{
    public class ResidueListViewModel
    {
        public int ResidueId { get; set; }
        public int ResidueFamilyId { get; set; }
        public string Name { get; set; }
        public string IBAMACode { get; set; }
        public int UnitOfMeasurementId { get; set; }
        public string UnitOfMeasurementName { get; set; }
        public int PhysicalStateId { get; set; }
        public string PhysicalStateName { get; set; }
        public int PackagingId { get; set; }
        public string PackagingName { get; set; }
        public int? ResidueDestinationTypeId { get; set; }
        public DateTime CreatedDate { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime? DeletedDate { get; set; }
        public int? DeletedBy { get; set; }
        public string ResidueFamilyClassName { get; set; }
        public string ResidueFamilyName { get; set; }
        public string ResidueFamilyGroupName { get; set; }
        public int? ResidueFamilyGroupOrder { get; set; }
        public string ONUCode { get; set; }
        public string Risk { get; set; }
        public string RiskClass { get; set; }
    }
}
