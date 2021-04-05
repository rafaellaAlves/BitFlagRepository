using System;
using System.Collections.Generic;

namespace DAL
{
    public partial class Equipamento
    {
        public int EquipamentoId { get; set; }
        public int SeguradoEquipamentoId { get; set; }
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public string Serie { get; set; }
        public double? Preco { get; set; }
        public bool? Nf { get; set; }
        public int? TipoEquipamentoId { get; set; }
        public int? Ano { get; set; }
        public string EspecificacaoTipo { get; set; }
    }
}
