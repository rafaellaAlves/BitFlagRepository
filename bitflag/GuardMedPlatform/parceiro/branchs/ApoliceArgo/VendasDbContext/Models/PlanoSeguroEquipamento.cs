using System;
using System.Collections.Generic;

namespace VendasDbContext.Models
{
    public partial class PlanoSeguroEquipamento
    {
        public int PlanoSeguroEquipamentoId { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public bool EstaAtivo { get; set; }
        public string ExternalCode { get; set; }
    }
}
