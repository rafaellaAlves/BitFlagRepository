using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.DTO.Especialidade
{
    public class EspecialidadePrecoViewModel
    {
        public int EspecialidadePrecoId { get; set; }
        public int PlanoSeguroProfissionalId { get; set; }
        public int Gropo { get; set; }
        public float PrecoMensal { get; set; }
        public float PrecoAnual { get; set; }
        public float PrecoAdmMensal { get; set; }
        public float PrecoAdmAnual { get; set; }
        public string CodIUGU { get; set; }
        public float PrecoTotalMenosAdm { get => PrecoAnual - PrecoAdmAnual; }
        public float PrecoMensalMenosAdm { get => PrecoMensal - PrecoAdmMensal; }
    }
}
