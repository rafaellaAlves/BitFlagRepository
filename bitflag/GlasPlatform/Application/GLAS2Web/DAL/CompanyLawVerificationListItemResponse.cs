using System;
using System.Collections.Generic;
using System.Text;

namespace DAL
{
    public class CompanyLawVerificationListItemResponse // : Shared.BaseEntity
    {
        public int CompanyLawVerificationListItemResponseId { get; set; }
        public int CompanyLawId { get; set; }
        public int LawVerificationListId { get; set; }
        public int LawVerificationListItemId { get; set; }
        public int ImplementationTypeId { get; set; }
        public bool? CreateCompanyLawAction { get; set; }
        public int? CompanyLawActionType { get; set; }
        public string Comments { get; set; }
        public int? LastHandler { get; set; }
        public DateTime? ModifiedDate { get; set; }
    }
}
