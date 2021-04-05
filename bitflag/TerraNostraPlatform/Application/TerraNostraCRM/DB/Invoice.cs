using System;
using System.Collections.Generic;

namespace DB
{
    public partial class Invoice
    {
        public int InvoiceId { get; set; }
        public int InvoiceServiceTypeId { get; set; }
        public int? InvoiceStatusId { get; set; }
        public int ClientId { get; set; }
        public int FreezedFamilyId { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int CreatedBy { get; set; }
        public double? EuroExchange { get; set; }
        public double? ItalianCertificateCost { get; set; }
        public double? BrazilianCertificateCost { get; set; }
        public double? HaiaHandoutCost { get; set; }
        public double? TranslationCost { get; set; }
        public double? Cnncost { get; set; }
        public double? ProcessCost { get; set; }
        public double? ApplicantCost { get; set; }
        public double? Cost { get; set; }
        public double? Tax { get; set; }
        public int? InvoicePaymentTypeId { get; set; }
        public double? GrandTotal { get; set; }
        public DateTime? AlteredDate { get; set; }
        public int? AlteredBy { get; set; }
        public string Comments { get; set; }
        public bool IsLocked { get; set; }
        public int? InvoicePaymentWayId { get; set; }
        public double? LetterOfAttorneyCost { get; set; }
        public int? ExternalCode { get; set; }
    }
}
