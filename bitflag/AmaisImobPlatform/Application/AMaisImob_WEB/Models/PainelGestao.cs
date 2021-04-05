using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AMaisImob_WEB.Utils;

namespace AMaisImob_WEB.Models
{
    public class PainelGestao
    {
        public int TotalAdherence { get; set; }
        public double TotalInquilino { get; set; }
        public DateTime MesAtual { get; set; }
        public string _MesAtual { get { return MesAtual.ToShortDatePtBR(); }}

    }
}
