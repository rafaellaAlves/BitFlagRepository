using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace VendasDbContext.Models
{
    public class MedicGroupListView
    {
        [Key]
        public int MedicGroupId { get; set; }
        public string MedicGroupName { get; set; }
        public string ExternalCode { get; set; }
        public string CNPJ { get; set; }
        public double Discount { get; set; }
        public bool IsActive { get; set; }
        public int QtdCRM { get; set; }
        public int? RevenuesFormId { get; set; }
        public int? CompanyPlatformId { get; set; }
        public double? PlatformAgency { get; set; }
        public double? PlatformLife { get; set; }
        public double? PlatformComission { get; set; }
        public int? CompanyOfficeId { get; set; }
        public double? OfficeAgency { get; set; }
        public double? OfficeLife { get; set; }
        public double? OfficeComission { get; set; }
    }
}
