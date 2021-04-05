using System;
using System.Collections.Generic;

namespace AMaisImob_DB.Models
{
    public partial class CertificateContractualInstallment
    {
        public int CertificateContractualInstallmentId { get; set; }
        public int CertificateContractualId { get; set; }
        public DateTime Date { get; set; }
        public double Price { get; set; }
        public bool Paid { get; set; }
        public DateTime CreatedDate { get; set; }
        public int CreatedBy { get; set; }
    }
}
