using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AMaisImob_WEB.Models
{
    public class ContractualContractualCertificateViewModel
    {
        public CertificateContractualListViewModel CertificateContractual { get; set; }
        public List<int> CategoryGuarantorProductTaxIds { get; set; }
        public bool Print { get; set; }
    }
}
