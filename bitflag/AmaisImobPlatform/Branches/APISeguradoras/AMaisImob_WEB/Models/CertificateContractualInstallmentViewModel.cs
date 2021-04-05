using AMaisImob_WEB.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AMaisImob_WEB.Models
{
    public class CertificateContractualInstallmentViewModel
    {
        public int? CertificateContractualInstallmentId { get; set; }
        public int CertificateContractualId { get; set; }
        public int Order { get; set; }
        public DateTime? Date { get; set; }
        public string _Date => Date.ToShortDatePtBR();
        public double? Price { get; set; }
        public string _Price { get => Price.ToPtBR(); set => Price = value.FromDoublePtBR(); }
        public bool Paid { get; set; }
        public DateTime CreatedDate { get; set; }
        public int CreatedBy { get; set; }
    }
}
