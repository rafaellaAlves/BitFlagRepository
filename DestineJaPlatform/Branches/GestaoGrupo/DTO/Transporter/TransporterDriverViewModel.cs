using DTO.Utils;
using System;
using System.Collections.Generic;
using System.Text;

namespace DTO.Transporter
{
    public class TransporterDriverViewModel
    {
        public int? TransporterDriverId { get; set; }
        [Update]
        public int TransporterId { get; set; }
        [Update]
        public string DriverName { get; set; }
        [Update]
        public string RG { get; set; }
        [Update]
        public string RGState { get; set; }
        [Update]
        public string CPF { get; set; }
        [Update]
        public string _CPF
        {
            get { return CPF; }
            set { CPF = value.NumbersOnly(); }
        }
        [Update]
        public DateTime? BirthDate { get; set; }
        public string _BirthDate { get { return BirthDate.ToBrazilianDateFormat(); } set { BirthDate = value.FromBrazilianDateFormatNullable(); } }
        [Update]
        public string CompanyPhone { get; set; }
        [Update]
        public string CNH { get; set; }
        public string CNHGuidName { get; set; }
        public string CNHFileName { get; set; }
        public string CNHMimeType { get; set; }
        [Update]
        public string MOPP { get; set; }
        public string MOPPGuidName { get; set; }
        public string MOPPFileName { get; set; }
        public string MOPPMimeType { get; set; }
        [Update]
        public DateTime? MOPPDueDate { get; set; }
        public string _MOPPDueDate { get { return MOPPDueDate.ToBrazilianDateFormat(); } set { MOPPDueDate = value.FromBrazilianDateFormatNullable(); } }
        [Update]
        public string ASO { get; set; }
        public string ASOGuidName { get; set; }
        public string ASOFileName { get; set; }
        public string ASOMimeType { get; set; }
        [Update]
        public string Category { get; set; }
        public string CreatedDate { get; set; }
        public bool Isdeleted { get; set; }
        public DateTime? DeletedDate { get; set; }
        public int? DeletedBy { get; set; }
        public bool IsActive { get; set; }
    }
}
