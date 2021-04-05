using System;
using System.Collections.Generic;

namespace DAL
{
    public partial class EspecialidadeProfissional
    {
        public int EspecialidadeProfissionalId { get; set; }
        public int SeguradoProfissionalId { get; set; }
        public int EspecialidadeId { get; set; }
        public bool Invasivo { get; set; }
    }
}
