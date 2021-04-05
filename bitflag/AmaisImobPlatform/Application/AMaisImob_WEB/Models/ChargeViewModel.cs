using AMaisImob_WEB.Utils;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace AMaisImob_WEB.Models
{
    public class ChargeViewModel
    {
        public int? ChargeId { get; set; }
        public int RealEstateId { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public string _Price { get { return Price.ToPtBR(); } }
        public DateTime ReferenceDate { get; set; }
        public string _ReferenceDate => $"{new CultureInfo("pt-BR").TextInfo.ToTitleCase(new CultureInfo("pt-BR").DateTimeFormat.GetMonthName(ReferenceDate.Month))} - {ReferenceDate.Year}";
        public string ReferenceDateISOString => ReferenceDate.ToString("yyyy-MM-ddTHH\\:mm\\:ss.fffffffzzz");
        public DateTime? DueDate { get; set; }
        public string _DueDate { get { return DueDate.ToDatePtBR(); } }
        public DateTime CreateDate { get; set; }
        public string _CreateDate { get { return DueDate.ToDatePtBR(); } }
        public string IUGUUrl { get; set; }
        public bool IsPayed { get; set; }
        public string IUGUDescription { get; set; }
        public string IUGUnotification_url { get; set; }
        public string PayedToken { get; set; }
        public string IUGUInvoiceId { get; set; }
        public DateTime? PayedDate { get; set; }
        public int? PayedBy { get; set; }
        public DateTime? InvoiceDate { get; set; }
        public string _InvoiceDate { get { return InvoiceDate.ToDatePtBR(); } }
        public bool IsLocked { get; set; }

        public bool RealStateChargeContractualGuarantee { get; set; }
        public bool RealStateChargeCertificate { get; set; }
        public bool RealStateChargeDocuSign { get; set; }
        public int? TotalCertificate { get; set; }
        public int? AlternativeTotalCertificate { get; set; }
        public double? PriceCertificate { get; set; }
        public string PriceCertificateFormated { get => PriceCertificate.ToPtBR(); set => PriceCertificate = value.FromDoublePtBR(); }
        public double? AlternativePriceCertificate { get; set; }
        public string AlternativePriceCertificateFormated { get => AlternativePriceCertificate.ToPtBR(); set => AlternativePriceCertificate = value.FromDoublePtBR(); }
        public int? TotalDocuSign { get; set; }
        public int? AlternativeTotalDocuSign { get; set; }
        public double? PriceDocuSign { get; set; }
        public string PriceDocuSignFormated { get => PriceDocuSign.ToPtBR(); set => PriceDocuSign = value.FromDoublePtBR(); }
        public double? AlternativePriceDocuSign { get; set; }
        public string AlternativePriceDocuSignFormated { get => AlternativePriceDocuSign.ToPtBR(); set => AlternativePriceDocuSign = value.FromDoublePtBR(); }

        public string CompanyName { get; set; } 
        public string CompanyTradeName { get; set; }
    }
}
