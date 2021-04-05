using GuardMedWeb.BLL.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GuardMedWeb.Models
{
    public class EspecialidadePrecoViewModel
    {
        public int EspecialidadePrecoId { get; set; }
        public int PlanoSeguroProfissionalId { get; set; }
        public int Gropo { get; set; }
     
        public float PrecoMensal { get; set; }
        public string _PrecoMensal { get { return PrecoMensal.ToPtBr(); } }
        public float PrecoAnual { get; set; }
        public string _PrecoAnual { get { return PrecoAnual.ToPtBr(); } }
        public float PrecoAdmMensal { get; set; }
        public string _PrecoAdmMensal { get { return PrecoAdmMensal.ToPtBr(); } }
        public float PrecoAdmAnual { get; set; }
        public string _PrecoAdmAnual { get { return PrecoAdmAnual.ToPtBr(); } }
        public string CodIUGU { get; set; }
        public string _PrecoMensalCobertura { get { return ((PrecoMensal) / 100d * 10d).ToPtBr(); } }
        public float PrecoMensalCom10 { get { return ((PrecoMensal / 100f * 10f) + PrecoMensal); } }
        public float PrecoMensalCom20 { get { return ((PrecoMensal / 100f * 20f) + PrecoMensal); } }
        public string _PrecoMensalCom10 { get { return PrecoMensalCom10.ToPtBr();} }
        public string _PrecoMensalCom20 { get { return PrecoMensalCom20.ToPtBr(); } }

        public float PrecoAnualCom10 { get { return ((PrecoAnual / 100f * 10f) + PrecoAnual); } }
        public float PrecoAnualCom20 { get { return ((PrecoAnual / 100f * 20f) + PrecoAnual); } }

        public string _PrecoAnualCom10 { get { return PrecoAnualCom10.ToPtBr(); } }
        public string _PrecoAnualCom20 { get { return PrecoAnualCom20.ToPtBr(); } }

       

    }
}
