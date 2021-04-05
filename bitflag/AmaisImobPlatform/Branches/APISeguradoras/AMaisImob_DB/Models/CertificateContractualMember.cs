using System;
using System.Collections.Generic;

namespace AMaisImob_DB.Models
{
    public partial class CertificateContractualMember
    {
        public int CertificateContractualMemberId { get; set; }
        public int CertificateContractualId { get; set; }
        public string Name { get; set; }
        public string Cpf { get; set; }
        public double? Income { get; set; }
        public DateTime? BirthDate { get; set; }
        public int? CertificateContractualIncomeTypeId { get; set; }
        public int? KinshipId { get; set; }
        public string Occupation { get; set; }
    }
}
