using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web.DTO.Utils;

namespace Web.DTO.SeguradoProfissional
{
    public class InsuranceLogViewModel
    {
        public string Referencia { get; set; }
        public DateTime? InicioVigencia { get; set; }
        public string InicioVigenciaFormatado => InicioVigencia.HasValue ? InicioVigencia.ToDatePtBR() : "~";
        public DateTime FimVigencia { get; set; }
        public string FimVigenciaFormatado => FimVigencia.ToDatePtBR();
        public string Status { get; set; }
        public string RetroatividadeArquivo { get; set; }
    }
}
