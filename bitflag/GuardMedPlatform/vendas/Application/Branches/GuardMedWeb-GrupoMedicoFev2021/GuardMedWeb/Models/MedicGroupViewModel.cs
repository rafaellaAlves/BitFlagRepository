using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;



namespace GuardMedWeb.Models
{
    public class MedicGroupViewModel
    {
        public int? MedicGroupId { get; set; }
        public string MedicGroupName { get; set; }
        public string ExternalCode { get; set; }
        public string CNPJ { get; set; }
        public string Discount { get; set; }
        public double DiscountNumber { get; set; }
        public bool? IsActive { get; set; }
        public int? RevenuesFormId { get; set; }
        public int? CompanyPlatformId { get; set; }
        public double? PlatformAgency { get; set; }
        public string PlatformAgencyFormatted { get; set; }
        public double? PlatformLife { get; set; }
        public string PlatformLifeFormatted { get; set; }
        public double? PlatformComission { get; set; }
        public string PlatformComissionFormatted { get; set; }
        public int? CompanyOfficeId { get; set; }
        public double? OfficeAgency { get; set; }
        public string OfficeAgencyFormatted { get; set; }
        public double? OfficeLife { get; set; }
        public string OfficeLifeFormatted { get; set; }
        public double? OfficeComission { get; set; }
        public string OfficeComissionFormatted { get; set; }
    }
}
