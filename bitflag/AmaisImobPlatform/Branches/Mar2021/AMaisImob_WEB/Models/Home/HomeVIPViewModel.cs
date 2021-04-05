using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AMaisImob_WEB.Models.Home
{
    public class HomeVIPViewModel
    {
        public int? RealEstateAgencyId { get; set; }
        public int? RealEstateId { get; set; }

        public int CertificateSimulationCount { get; set; }
        public int CertificateSimulationPoints { get; set; }
        public int CertificateRenewCount { get; set; }
        public int CertificateRenewPoints { get; set; }
        public int CertificateActiveCount { get; set; }
        public int CertificateActivePoints { get; set; }
        public int CertificateContractualNewCount { get; set; }
        public int CertificateContractualNewPoints { get; set; }
        public int CertificateContractualActiveCount { get; set; }
        public int CertificateContractualActivePoints { get; set; }
        public int? TotalPoints { get; set; }
        public int? NeededPoints { get; set; }
        public bool? VIP { get; set; }
    }
}
