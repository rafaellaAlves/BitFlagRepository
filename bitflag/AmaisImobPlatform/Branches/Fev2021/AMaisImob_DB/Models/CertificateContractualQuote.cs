using System;
using System.Collections.Generic;
using System.Text;

namespace AMaisImob_DB.Models
{
    public class CertificateContractualQuote
    {
        public int CertificateContractualQuoteId { get; set; }
        public int CertificateContractualId { get; set; }
        public int CategoryGuarantorProductTaxId { get; set; }
    }
}
