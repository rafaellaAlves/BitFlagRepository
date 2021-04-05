using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AMaisImob_WEB.Models
{
    public class TaxaInquilinoAnualViewModel
    {
        public int TaxaInquilinoAnual { get; set; }
        public string _TaxaInquilinoAnual { get { return TaxaInquilinoAnual.ToString("#,##0.00"); } }
    }
}
