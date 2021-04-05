using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AMaisImob_WEB.Models
{
    public class TaxaGarantidora
    {
        public int CategoryGuarantorProductTaxId { get; set; }
        public int GuarantorProductId { get; set; }
        public string GuarantorProductName { get; set; }
        public double TaxaMes { get; set; }
        public double TaxaAno { get; set; }

    }
}
