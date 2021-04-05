using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;


namespace ApplicationDbContext.Models
{
    public class TransporterDriver
    {
        [Key]
        public int? TransporterDriverId { get; set; }
        public int TransporterId { get; set; }
        public string DriverName { get; set; }
        public string RG { get; set; }
        public string RGState { get; set; }
        public string CPF { get; set; }
        public DateTime? BirthDate { get; set; }
        public string CompanyPhone { get; set; }
        public string CNH { get; set; }
        public string CNHGuidName { get; set; }
        public string CNHFileName { get; set; }
        public string CNHMimeType { get; set; }
        public string MOPP { get; set; }
        public string MOPPGuidName { get; set; }
        public string MOPPFileName { get; set; }
        public string MOPPMimeType { get; set; }
        public DateTime? MOPPDueDate { get; set; }
        public string ASO { get; set; }
        public string ASOGuidName { get; set; }
        public string ASOFileName { get; set; }
        public string ASOMimeType { get; set; }
        public string Category { get; set; }
        public DateTime CreatedDate { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime? DeletedDate { get; set; }
        public int? DeletedBy { get; set; }
        public bool IsActive { get; set; }
    }
}
