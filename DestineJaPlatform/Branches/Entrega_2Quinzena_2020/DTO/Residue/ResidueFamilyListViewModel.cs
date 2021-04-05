using System;
using System.Collections.Generic;
using System.Text;

namespace DTO.Residue
{
    public class ResidueFamilyListViewModel
    {
        public int ResidueFamilyId { get; set; }
        public string Name { get; set; }
        public string NameAbbreviation { get; set; }
        public int? ResidueFamilyClassId { get; set; }
        public string ResidueFamilyClassName { get; set; }
        public string Risk { get; set; }
        public string RiskClass { get; set; }
        public string ONUCode { get; set; }
        public DateTime CreatedDate { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime? DeletedDate { get; set; }
        public int? DeletedBy { get; set; }
        public int? ResidueCount { get; set; }
    }
}
