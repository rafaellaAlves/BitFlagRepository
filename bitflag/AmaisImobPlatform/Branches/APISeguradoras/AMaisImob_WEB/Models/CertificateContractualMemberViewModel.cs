using AMaisImob_WEB.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AMaisImob_WEB.Models
{
    public class CertificateContractualMemberViewModel
    {
        public int? CertificateContractualMemberId { get; set; }
        public int CertificateContractualId { get; set; }
        public string Name { get; set; }
        public string CPF { get; set; }
        public string _CPF { get { return CPF; } set { CPF = value.NumbersOnly(); } }
        public double? Income { get; set; }
        public string _Income { get { return Income.ToPtBR(); } set { Income = value.FromDoublePtBR(); } }
        public DateTime? BirthDate { get; set; }
        public string _BirthDate { get => BirthDate.ToDatePtBR(); set => BirthDate = value.FromDatePtBR();  }
        public int? CertificateContractualIncomeTypeId { get; set; }
        public int? KinshipId { get; set; }
        public string Occupation { get; set; }
    }
}
