using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WEB.Utils;

namespace WEB.Models
{
    public class InsuranceLogViewModel
    {
        public string Referencia { get; set; }
        public DateTime? InicioVigencia { get; set; }
        public string InicioVigenciaFormatado => InicioVigencia.ToDatePtBR();
        public DateTime FimVigencia { get; set; }
        public string FimVigenciaFormatado => FimVigencia.ToDatePtBR();
        public string Status { get; set; }
        public string RetroatividadeArquivo { get; set; }
    }
}
