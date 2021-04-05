using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DTO.Company
{
    public class CompanyLawActionViewModel
    {
        public int? CompanyLawActionId { get; set; }
        public int CompanyLawId { get; set; }
        public string Name { get; set; }
        public string RegistrationDate { get; set; }
        public string TargetDate { get; set; }
        public string CompanyLawActionStatusName { get; set; }
        public int? CompanyLawActionStatusId { get; set; }
        public string CompanyLawActionTypeName { get; set; }
        public int? CompanyLawActionTypeId { get; set; }
        public string SupervisorName { get; set; }
        public int? SupervisorId { get; set; }
        public string ResponsibleName { get; set; }
        public int? ResponsibleId { get; set; }
        public string FinalProjectCost { get; set; }
        public string RenewDate { get; set; }
        public string WarningDate { get; set; }
        public string Evidence { get; set; }
        public bool IsActive { get; set; }
    }
}
