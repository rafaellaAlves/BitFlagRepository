using System;
using System.Collections.Generic;
using System.Text;

namespace DAL
{
    public class CompanyLawAction : Shared.BaseEntity
    {
        public int CompanyLawActionId { get; set; }
        public int CompanyLawId { get; set; }
        public string Name { get; set; }
        public DateTime? RegistrationDate { get; set; }
        public DateTime? TargetDate { get; set; }
        public int? CompanyLawActionStatusId { get; set; }
        public int? CompanyLawActionTypeId { get; set; }
        public int? SupervisorId { get; set; }
        public int? ResponsibleId { get; set; }
        public double? FinalProjectCost { get; set; }
        public DateTime? RenewDate { get; set; }
        public DateTime? WarningDate { get; set; }
        public string Evidence { get; set; }
    }
}
