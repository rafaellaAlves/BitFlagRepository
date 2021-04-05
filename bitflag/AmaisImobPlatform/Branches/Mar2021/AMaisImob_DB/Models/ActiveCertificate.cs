using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace AMaisImob_DB.Models
{
    public partial class ActiveCertificate
    {
        [Key]
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
