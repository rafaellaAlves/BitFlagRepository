using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationDbContext.Models
{
    public class ResidueFamily
    {
        public int ResidueFamilyId { get; set; }
        public string Name { get; set; }
        public string NameAbbreviation { get; set; }
        public int? ResidueFamilyClassId { get; set; }
        public string Risk { get; set; }
        public string RiskClass { get; set; }
        public string ONUCode { get; set; }
        public string GroupName { get; set; }
        public int? GroupOrder { get; set; }
        public bool AcceptDifferentFamilies { get; set; }
        public DateTime CreatedDate { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime? DeletedDate { get; set; }
        public int? DeletedBy { get; set; }
    }
}
