using DB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WEB.Models
{
    public class CertificatePrintViewModel
    {
        public _CertificateViewModel Certificate { get; set; }

        public CompanyViewModel RealEstateAgency { get; set; }
        public CompanyViewModel RealEstate { get; set; }

        public _InsurancePolicyViewModel InsurancePolicy { get; set; }

        public AssistanceViewModel Assistance { get; set; }

        public CertificatePlanViewModel Plan { get; set; }
        public List<ProductPlanCoverageViewModel> Coverages { get; set; }
    }
}
