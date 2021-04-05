using System;
using System.Collections.Generic;

namespace AMaisImob_DB.Models
{
    public partial class ChargeCertificateContractual
    {
        public int ChargeCertificateContractualId { get; set; }
        public int ChargeId { get; set; }
        public int GuarantorId { get; set; }
        public int Total { get; set; }
        public double Price { get; set; }
        public double? AlternativePrice { get; set; }
        public string GuidFileName { get; set; }
        public string FileName { get; set; }
        public string MimeType { get; set; }
        public string InvoiceGuidFileName { get; set; }
        public string InvoiceFileName { get; set; }
        public string InvoiceMimeType { get; set; }
        public int? AlternativeTotal { get; set; }
    }
}
