using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DTO.Company
{
    public class CompanyLawViewModel
    {
        public int? CompanyLawId { get; set; }
        public int CompanyId { get; set; }
        public int LawId { get; set; }
        public int? LawApplicationTypeId { get; set; }
        public string LawApplicationTypeName { get; set; }
        public int? LawConclusionStatusId { get; set; }
        public string LawConclusionStatusName { get; set; }
        public string RenewDate { get; set; }
        public string WarningDate { get; set; }
        public string Evidence { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
        public int? LawPotentialityTypeId { get; set; }
        public int? ResponsibleId { get; set; }
        public string ResponsibleName { get; set; }
        public int LastHandler { get; set; }

        public Law.LawViewModel Law { get; set; }
        public Law.LawTypeViewModel LawType { get; set; }
        public CompanyViewModel Company { get; set; }
    }

    public class SimpleCompanyLawViewModel
    {
        public int LawTypeId { get; set; }
        public string LawType { get; set; }
        public string LawNumber { get; set; }
        public string LawTitle { get; set; }
    }
}
