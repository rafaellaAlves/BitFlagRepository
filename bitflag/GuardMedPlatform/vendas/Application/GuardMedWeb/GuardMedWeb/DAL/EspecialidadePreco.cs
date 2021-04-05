using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GuardMedWeb.DAL
{
    public class EspecialidadePreco
    {
        public int EspecialidadePrecoId { get; set; }
        public int PlanoSeguroProfissionalId { get; set; }
        public int Gropo { get; set; }
        public float PrecoMensal { get; set; }
        public float PrecoAnual { get; set; }
        public float PrecoAdmMensal { get; set; }
        public float PrecoAdmAnual { get; set; }
        public string CodIUGU { get; set; }
    }
}
