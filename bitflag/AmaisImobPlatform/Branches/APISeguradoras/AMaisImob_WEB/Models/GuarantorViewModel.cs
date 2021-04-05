using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AMaisImob_WEB.Models
{
    public class GuarantorViewModel
    {
        
        public int? GuarantorId { get; set; }
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
