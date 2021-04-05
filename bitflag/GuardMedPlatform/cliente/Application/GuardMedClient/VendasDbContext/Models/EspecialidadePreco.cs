using System;
using System.Collections.Generic;

namespace VendasDbContext.Models
{
    public partial class EspecialidadePreco
    {
        public int EspecialidadePrecoId { get; set; }
        public int PlanoSeguroProfissionalId { get; set; }
        public int Grupo { get; set; }
        public float PrecoMensal { get; set; }
        public float PrecoAdmMensal { get; set; }
        public float PremioTotalMensal { get; set; }
        public float PrecoAnual { get; set; }
        public float PrecoAdmAnual { get; set; }
        public float PremioTotalAnual { get; set; }
        public string CodIugu { get; set; }
    }
}
