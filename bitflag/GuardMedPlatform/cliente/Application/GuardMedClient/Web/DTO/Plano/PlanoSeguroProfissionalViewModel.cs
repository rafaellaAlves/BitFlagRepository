using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.DTO.Plano
{
    public class PlanoSeguroProfissionalViewModel
    {
        public int PlanoSeguroProfissionalId { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public bool EstaAtivo { get; set; }
        public string ExternalCode { get; set; }
        public float PrecoMensal { get; set; }
        public string _PrecoMensal { get => PrecoMensal.ToString("#,###,##0.00"); }
        public double ValorCobertura { get; set; }
        public string _ValorCobertura { get => ValorCobertura.ToString("#,###,##0.00"); }
        public double Franquia { get; set; }
        public string _Franquia { get => Franquia.ToString("#,###,##0.00"); }
    }
}
