using System;
using System.Collections.Generic;

namespace AMaisImob_DB.Models
{
    public partial class ActiveCertificate
    {
        public int CertAtivosId { get; set; }
        public int RealEstateAgencyId { get; set; }
        public int RealEstateId { get; set; }
        public int QtdCertificadosAtivos { get; set; }
        public double Price { get; set; }
        public bool IsPaid { get; set; }
        public DateTime ReferenceDate { get; set; }
        public double TaxaInquilini { get; set; }
    }
}
