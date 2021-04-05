using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using AMaisImob_WEB.Utils;

namespace AMaisImob_WEB.Models
{
    public class CategoryGuarantorProductTaxViewModel
    {
        public int? CategoryGuarantorProductTaxId { get; set; }
        public int GuarantorId { get; set; }
        public string GuarantorName { get; set; }
        public byte[] GuarantorLogoTipo { get; set; }
        public string GuarantorLogoTipoMimeType { get; set; }
        public int GuarantorPaymentTypeId { get; set; }
        public int? CategoryId { get; set; }
        public string CategoryName { get; set; }
        public int GuarantorProductId { get; set; }
        public string GuarantorProductName { get; set; }
        public int GuarantorTypeId { get; set; }
        public string GuarantorTypeName { get; set; }
        public string GuarantorPrintFooterText { get; set; }
        public double TaxaMes { get; set; }
        public string _TaxaMes { get { return TaxaMes.ToPtBR(); } set { TaxaMes = (double)value.FromDoublePtBR(); } }
        public double TaxaAno { get; set; }
        public string _TaxaAno { get { return TaxaAno.ToPtBR(); } }
        public int TipoImovel { get; set; }
        public string Description { get; set; }
        public bool Edited { get; set; }
        public decimal? MaxRentPrice { get; set; }
        public string _MaxRentPrice { get { return MaxRentPrice.ToMoneyPtBR(); } set { MaxRentPrice = value.FromDecimalPtBR(); } }
        public decimal? MaxRentAndChargesPrice { get; set; }
        public string _MaxRentAndChargesPrice { get { return MaxRentAndChargesPrice.ToMoneyPtBR(); } set { MaxRentAndChargesPrice = value.FromDecimalPtBR(); } }
        public bool? Active { get; set; }
    }
}
