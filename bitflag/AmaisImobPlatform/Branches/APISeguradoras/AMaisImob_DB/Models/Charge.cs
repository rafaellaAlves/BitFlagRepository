using System;
using System.Collections.Generic;

namespace AMaisImob_DB.Models
{
    public partial class Charge
    {
        public int ChargeId { get; set; }
        public int RealEstateId { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public DateTime ReferenceDate { get; set; }
        public DateTime? DueDate { get; set; }
        public DateTime CreateDate { get; set; }
        public string Iuguurl { get; set; }
        public bool IsPayed { get; set; }
        public DateTime? PayedDate { get; set; }
        public string PayedToken { get; set; }
        public string IuguinvoiceId { get; set; }
        public int? PayedBy { get; set; }
        public int? TotalCertificate { get; set; }
        public double? PriceCertificate { get; set; }
        public int? TotalDocuSign { get; set; }
        public double? PriceDocuSign { get; set; }
        public bool RealStateChargeContractualGuarantee { get; set; }
        public double? AlternativePriceCertificate { get; set; }
        public double? AlternativePriceDocuSign { get; set; }
        public bool IsLocked { get; set; }
        public DateTime? InvoiceDate { get; set; }
        public int? AlternativeTotalCertificate { get; set; }
        public int? AlternativeTotalDocuSign { get; set; }
        public bool RealStateChargeCertificate { get; set; }
        public bool RealStateChargeDocuSign { get; set; }
    }
}
