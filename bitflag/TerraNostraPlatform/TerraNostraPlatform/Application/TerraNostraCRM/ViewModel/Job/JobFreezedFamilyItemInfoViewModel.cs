using DTO.Utils;
using System;
using System.Collections.Generic;
using System.Text;

namespace DTO.Job
{
    public class JobFreezedFamilyItemInfoViewModel
    {
        public int? JobFreezedFamilyItemInfoId { get; set; }
        public int InvoiceFreezedFamilyItemId { get; set; }
        public int CertificateTypeId { get; set; }
        public string CertificateType { get; set; }
        public DateTime? CertificateDate { get; set; }
        public string _CertificateDate { get { return CertificateDate.ToDatePtBR(); } }
        public int? RegistryOfficeId { get; set; }
        public string RegistryOfficeBook { get; set; }
        public string RegistryOfficePage { get; set; }
        public string RegistryOfficeTerm { get; set; }
        public bool RegistryOfficeRequirementSent { get; set; }
        public DateTime? RegistryOfficeRequirementSentDate { get; set; }
        public string _RegistryOfficeRequirementSentDate { get { return RegistryOfficeRequirementSentDate.ToDatePtBR(); } }
        public bool RegistryOfficeCertificateCheck { get; set; }
        public DateTime? RegistryOfficeRequirementSentEmailDate { get; set; }
        public string _RegistryOfficeRequirementSentEmailDate { get { return RegistryOfficeRequirementSentEmailDate.ToDatePtBR(); } }
        public bool RegistryOfficeRequirementCheck { get; set; }
        public double? RegistryOfficeCertificatePrice { get; set; }
        public string _RegistryOfficeCertificatePrice { get { return RegistryOfficeCertificatePrice.ToPtBR(); } }
        public double? RegistryOfficeShippingPrice { get; set; }
        public string _RegistryOfficeShippingPrice { get { return RegistryOfficeShippingPrice.ToPtBR(); } }
        public double? RegistryOfficeTotalPrice { get; set; }
        public string _RegistryOfficeTotalPrice { get { return RegistryOfficeTotalPrice.ToPtBR(); } }
        public DateTime? RegistryOfficePaymentDate { get; set; }
        public string _RegistryOfficePaymentDate { get { return RegistryOfficePaymentDate.ToDatePtBR(); } }
        public DateTime? RegistryOfficeShippingDate { get; set; }
        public string _RegistryOfficeShippingDate { get { return RegistryOfficeShippingDate.ToDatePtBR(); } }
        public DateTime? RegistryOfficeCertificateShippingArrivalDate { get; set; }
        public string _RegistryOfficeCertificateShippingArrivalDate { get { return RegistryOfficeCertificateShippingArrivalDate.ToDatePtBR(); } }
        public DateTime? TranslationSentDate { get; set; }
        public string _TranslationSentDate { get { return TranslationSentDate.ToDatePtBR(); } }
        public DateTime? TranslationReceiveDate { get; set; }
        public string _TranslationReceiveDate { get { return TranslationReceiveDate.ToDatePtBR(); } }
        public DateTime? HaiaHandoutSentDate { get; set; }
        public string _HaiaHandoutSentDate { get { return HaiaHandoutSentDate.ToDatePtBR(); } }
        public DateTime? HaiaHandoutReceiveDate { get; set; }
        public string _HaiaHandoutReceiveDate { get { return HaiaHandoutReceiveDate.ToDatePtBR(); } }
        public bool ItalyProtocolTranslationCheck { get; set; }
        public bool ItalyProtocolHaiaCheck { get; set; }
    }
}
