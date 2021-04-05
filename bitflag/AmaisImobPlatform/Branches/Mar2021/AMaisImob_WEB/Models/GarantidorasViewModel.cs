using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AMaisImob_WEB.Models
{
    public class GarantidoraViewModel
    {
        public int? GuarantorId { get; set; }
        public string GuarantorName { get; set; }
        public List<TaxaGarantidora> Taxas { get; set; }
        public GarantidoraViewModel()
        {
            this.Taxas = new List<TaxaGarantidora>();
        }
    }
}
