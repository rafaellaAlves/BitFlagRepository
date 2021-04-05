using System;
using System.Collections.Generic;

namespace DAL
{
    public partial class PagamentoTipo
    {
        public int PagamentoTipoId { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public bool EstaAtivo { get; set; }
        public string ExternalCode { get; set; }
    }
}
