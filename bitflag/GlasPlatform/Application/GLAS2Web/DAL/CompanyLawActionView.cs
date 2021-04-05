using System;
using System.Collections.Generic;
using Utils;

namespace DAL
{
    public partial class CompanyLawActionView
    { 
        public int CompanyLawId { get; set; }
        [System.ComponentModel.DataAnnotations.Key]
        public int CompanyLawActionId { get; set; }
        public string CompanyLawActionName { get; set; }
        public DateTime? CompanyLawActionRegistrationDate { get; set; }
        public string _CompanyLawActionRegistrationDate { get { return CompanyLawActionRegistrationDate.ToBrazilianDateFormat(); } }
        public DateTime? CompanyLawActionTargetDate { get; set; }
        public string _CompanyLawActionTargetDate { get { return CompanyLawActionTargetDate.ToBrazilianDateFormat(); } }
        public DateTime? CompanyLawActionRenewDate { get; set; }
        public string _CompanyLawActionRenewDate { get { return CompanyLawActionRenewDate.ToBrazilianDateFormat(); } }
        public int? CompanyLawActionSupervisorId { get; set; }
        public string CompanyLawActionSupervisorName { get; set; }
        public double? CompanyLawActionFinalProjectCost { get; set; }
        public bool CompanyLawActionIsDeleted { get; set; }
        public int? CompanyLawActionStatusId { get; set; }
        public string CompanyLawActionStatusName { get; set; }
    }
}