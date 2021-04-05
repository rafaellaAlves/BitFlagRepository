using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AMaisImob_WEB.Models
{
    public class ContractualGuaranteeCertificateHeaderViewModel
    {
        public _CertificateContractualViewModel CertificateContractual { get; set; }
        public List<CertificateContractualMemberViewModel> Members { get; set; }

        public ContractualGuaranteeCertificateHeaderViewModel(_CertificateContractualViewModel CertificateContractual, List<CertificateContractualMemberViewModel> Members)
        {
            this.CertificateContractual = CertificateContractual;
            this.Members = Members;
        }
    }
}
