using System;
using System.Collections.Generic;
using System.Text;
using DTO.Utils;

namespace DTO.Invoice
{
    public class InvoiceViewModel
    {
        public int? InvoiceId { get; set; }
        public string InvoiceTerraNostraId
        {
            get
            {
                return !ExternalCode.HasValue ? "[SEM NÚMERO]" : $"{ExternalCode.Value}/{CreatedDate.Year.ToString("0000")}";
            }
        }
        public int InvoiceServiceTypeId { get; set; }
        public int ClientId { get; set; }
        public int FreezedFamilyId { get; set; }
        public string FreezedFamilyName { get; set; }
        public DateTime CreatedDate { get; set; }
        public int CreatedBy { get; set; }
        public double? EuroExchange { get; set; }
        public string _EuroExchange { get { return EuroExchange.ToPtBR(); } set { EuroExchange = value.FromDoublePtBR(); } }
        public double? ItalianCertificateCost { get; set; }
        public string _ItalianCertificateCost { get { return ItalianCertificateCost.ToPtBR(); } set { ItalianCertificateCost = value.FromDoublePtBR(); } }
        public double? BrazilianCertificateCost { get; set; }
        public string _BrazilianCertificateCost { get { return BrazilianCertificateCost.ToPtBR(); } set { BrazilianCertificateCost = value.FromDoublePtBR(); } }
        public double? Cost { get; set; }
        public string _Cost { get { return Cost.ToPtBR(); } set { Cost = value.FromDoublePtBR(); } }
        public double? Tax { get; set; }
        public string _Tax { get { return Tax.ToPtBR(); } set { Tax = value.FromDoublePtBR(); } }
        public int? InvoicePaymentTypeId { get; set; }
        public double? GrandTotal { get; set; }
        public string _GrandTotal { get { return GrandTotal.ToPtBR(); } set { GrandTotal = value.FromDoublePtBR(); } }
        public double? HaiaHandoutCost { get; set; }
        public string _HaiaHandoutCost { get { return HaiaHandoutCost.ToPtBR(); } set { HaiaHandoutCost = value.FromDoublePtBR(); } }
        public double? TranslationCost { get; set; }
        public string _TranslationCost { get { return TranslationCost.ToPtBR(); } set { TranslationCost = value.FromDoublePtBR(); } }
        public double? CNNCost { get; set; }
        public string _CNNCost { get { return CNNCost.ToPtBR(); } set { CNNCost = value.FromDoublePtBR(); } }
        public double? ProcessCost { get; set; }
        public string _ProcessCost { get { return ProcessCost.ToPtBR(); } set { ProcessCost = value.FromDoublePtBR(); } }
        public double? ApplicantCost { get; set; }
        public string _ApplicantCost { get { return ApplicantCost.ToPtBR(); } set { ApplicantCost = value.FromDoublePtBR(); } }
        public double? LetterOfAttorneyCost { get; set; }
        public string _LetterOfAttorneyCost { get { return LetterOfAttorneyCost.ToPtBR(); } set { LetterOfAttorneyCost = value.FromDoublePtBR(); } }

        public DateTime? AlteredDate { get; set; }
        public int? AlteredBy { get; set; }
        public int? InvoiceStatusId { get; set; }
        public string Comments { get; set; }
        public bool IsLocked { get; set; }
        public int? InvoicePaymentWayId { get; set; }
        public int? ExternalCode { get; set; }
    }
}
