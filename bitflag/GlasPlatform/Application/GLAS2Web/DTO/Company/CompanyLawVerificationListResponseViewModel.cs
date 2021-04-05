using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DTO.Company
{
    public class CompanyLawVerificationListItemResponseViewModel
    {
        public int? CompanyLawVerificationListItemResponseId { get; set; }
        public int CompanyLawId { get; set; }
        public int LawVerificationListId { get; set; }
        public int LawVerificationListItemId { get; set; }
        public string Reference { get; set; }
        public string Description { get; set; }

        public int ImplementationTypeId { get; set; }
        public string CompanyLawActionTypeName { get; set; }
        public bool? CreateCompanyLawAction { get; set; }
        public int? CompanyLawActionType { get; set; }
        public string Comments { get; set; }
        public int? LastHandler { get; set; }
        public DateTime? ModifiedDate { get; set; }
    }
}
