using AMaisImob_WEB.Utils;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AMaisImob_WEB.Models.Charge
{
    public class ChargeCertificateContractualViewModel
    {
        public int? ChargeCertificateContractualId { get; set; }
        public int ChargeId { get; set; }
        public int GuarantorId { get; set; }
        public int Total { get; set; }
        public int? AlternativeTotal { get; set; }
        public double Price { get; set; }
        public string PriceFormated { get => Price.ToPtBR(); set => Price = value.FromDoublePtBR().Value; }
        public double? AlternativePrice { get; set; }
        public string AlternativePriceFormated { get => AlternativePrice.ToPtBR(); set => AlternativePrice = value.FromDoublePtBR(); }
        public string GuidFileName { get; set; }
        public string FileName { get; set; }
        public string MimeType { get; set; }
        public string InvoiceGuidFileName { get; set; }
        public string InvoiceFileName { get; set; }
        public string InvoiceMimeType { get; set; }
        public IFormFile File { get; set; }
        public IFormFile FileInvoice { get; set; }
    }
}