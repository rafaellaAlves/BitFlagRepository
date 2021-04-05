using System;
using System.Collections.Generic;

namespace DAL
{
    public partial class PlanoSeguroProfissional
    {
        public int PlanoSeguroProfissionalId { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public bool EstaAtivo { get; set; }
        public string ExternalCode { get; set; }
        public float PrecoMensal { get; set; }
        public double ValorCobertura { get; set; }
        public double Franquia { get; set; }
        public string CodigoFornecedor { get; set; }
    }
}
