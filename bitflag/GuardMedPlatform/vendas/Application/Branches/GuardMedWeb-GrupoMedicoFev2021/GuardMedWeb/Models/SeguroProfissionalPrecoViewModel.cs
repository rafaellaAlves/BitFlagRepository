using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GuardMedWeb.Models
{
    public class SeguroProfissionalPrecoViewModel
    {
        public int SeguroProfissionalPrecoId { get; set; }
        public int IdadeMin { get; set; }
        public int IdadeMax { get; set; }
        public int PlanoSeguroProfissionalId { get; set; }
        public string Custo { get; set; }
        public string CustoAssociado { get; set; }
        public string CustoMensal { get; set; }
        public string CustoAssociadoMensal { get; set; }
        public string CustoPanMensalAssociado { get; set; }
        public string CustoPanAnualAssociado { get; set; }
        public string CustoPanMensal { get; set; }
        public string CustoPanAnual { get; set; }
    }
}
