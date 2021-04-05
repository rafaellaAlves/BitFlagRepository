using System;
using System.Collections.Generic;
using System.Text;

namespace AMaisImob_DB.Models
{
    public class CertificateContractualMember
    {
        public int CertificateContractualMemberId { get; set; }
        public int CertificateContractualId { get; set; }
        public string Name { get; set; }
        public string CPF { get; set; }
        public double? Income { get; set; }
        public DateTime? BirthDate { get; set; }
        public int? CertificateContractualIncomeTypeId { get; set; }
        public int? KinshipId { get; set; }
        public string Occupation { get; set; }
    }
}
