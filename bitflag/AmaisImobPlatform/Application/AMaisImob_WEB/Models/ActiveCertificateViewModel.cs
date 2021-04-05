using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AMaisImob_WEB.Models
{
    public class ActiveCertificateViewModel
    {
        public int CertAtivosId { get; set; }
        public int RealEstateAgencyId { get; set; }
        public int RealEstateId { get; set; }
        public int QtdCertificadosAtivos { get; set; }
        public double Price { get; set; }
        public bool IsPaid { get; set; }
        public DateTime ReferenceDate { get; set; }
        public float TaxaInquilini { get; set; }
    }
}
