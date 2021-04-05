using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GuardMedWeb.Models
{
    public class PlanoSeguroProfissionalViewModel
    {
        public int PlanoSeguroProfissionalId { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public bool EstaAtivo { get; set; }
        public string ExternalCode { get; set; }
        public string PrecoMensal { get; set; }
        public double ValorCobertura { get; set; }
        public double Franquia { get; set; }
    }
}
