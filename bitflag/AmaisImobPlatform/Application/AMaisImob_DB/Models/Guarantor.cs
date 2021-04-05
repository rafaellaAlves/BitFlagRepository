using System;
using System.Collections.Generic;
using System.Text;

namespace AMaisImob_DB.Models
{
    public class Guarantor
    {
        public int GuarantorId { get; set; }
        public string NomeFantasia { get; set; }
        public string RazaoSocial { get; set; }
        public byte[] Logotipo { get; set; }
        public string LogoTipoMimeType { get; set; }
        public bool IsDeleted { get; set; }
        public bool IsActive { get; set; }
        public int TipoPagamento { get; set; }
        public int GuarantorTypeId { get; set; }
        public string PrintFooterText { get; set; }
    }
}
