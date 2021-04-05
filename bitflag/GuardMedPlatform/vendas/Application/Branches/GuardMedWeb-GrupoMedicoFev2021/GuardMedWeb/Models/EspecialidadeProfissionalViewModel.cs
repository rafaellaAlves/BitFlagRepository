using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GuardMedWeb.Models
{
    public class EspecialidadeProfissionalViewModel
    {
        public int? EspecialidadeProfissionalId { get; set; }
        public string NomeEspecialidade { get; set; }
        public int SeguradoProfissionalId { get; set; }
        public int? EspecialidadeId { get; set; }
        public bool? Invasivo { get; set; }
    }
}
