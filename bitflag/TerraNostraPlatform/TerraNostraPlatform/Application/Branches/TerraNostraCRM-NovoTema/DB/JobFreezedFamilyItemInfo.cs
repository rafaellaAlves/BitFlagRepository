using System;
using System.Collections.Generic;

namespace DB
{
    public partial class JobFreezedFamilyItemInfo
    {
        public int JobFreezedFamilyItemInfoId { get; set; }
        public int InvoiceFreezedFamilyItemId { get; set; }
        public int CertificateTypeId { get; set; }
        public DateTime? CertificateDate { get; set; }
        public int? RegistryOfficeId { get; set; }
        public string RegistryOfficeBook { get; set; }
        public string RegistryOfficePage { get; set; }
        public string RegistryOfficeTerm { get; set; }
        public bool RegistryOfficeRequirementSent { get; set; }
        public DateTime? RegistryOfficeRequirementSentDate { get; set; }
        public bool RegistryOfficeCertificateCheck { get; set; }
        public DateTime? RegistryOfficeRequirementSentEmailDate { get; set; }
        public bool RegistryOfficeRequirementCheck { get; set; }
        public double? RegistryOfficeCertificatePrice { get; set; }
        public double? RegistryOfficeShippingPrice { get; set; }
        public double? RegistryOfficeTotalPrice { get; set; }
        public DateTime? RegistryOfficePaymentDate { get; set; }
        public DateTime? RegistryOfficeShippingDate { get; set; }
        public DateTime? RegistryOfficeCertificateShippingArrivalDate { get; set; }
        public DateTime? TranslationSentDate { get; set; }
        public DateTime? TranslationReceiveDate { get; set; }
        public DateTime? HaiaHandoutSentDate { get; set; }
        public DateTime? HaiaHandoutReceiveDate { get; set; }
        public bool ItalyProtocolTranslationCheck { get; set; }
        public bool ItalyProtocolHaiaCheck { get; set; }
    }
}
