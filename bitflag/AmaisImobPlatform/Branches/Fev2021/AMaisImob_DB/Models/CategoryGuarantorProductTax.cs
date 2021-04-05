using System;
using System.Collections.Generic;
using System.Text;

namespace AMaisImob_DB.Models
{
    public class CategoryGuarantorProductTax
    {

        public int CategoryGuarantorProductTaxId { get; set; }
        public int GuarantorId { get; set; }
        public int? CategoryId { get; set; }
        public int GuarantorProductId { get; set; }
        public double TaxaMes { get; set; }
        public int TipoImovel { get; set; }
        public string Description { get; set; }
        public bool Edited { get; set; }
        public decimal? MaxRentPrice { get; set; }
        public decimal? MaxRentAndChargesPrice { get; set; }
    }
}
