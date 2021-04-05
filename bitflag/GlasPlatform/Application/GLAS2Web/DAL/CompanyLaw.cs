using System;
using System.Collections.Generic;
using System.Text;

namespace DAL
{
    public class CompanyLaw
    {
        public int CompanyLawId { get; set; }
        public int CompanyId { get; set; }
        public int LawId { get; set; }
        public int? LawApplicationTypeId { get; set; }
        public int? LawConclusionStatusId { get; set; }
        public DateTime? RenewDate { get; set; }
        public DateTime? WarningDate { get; set; }
        public string Evidence { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime CreatedDate { get; set; }
        public int LastHandler { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public int? LawPotentialityTypeId { get; set; }
        public int? ResponsibleId { get; set; }
    }
}