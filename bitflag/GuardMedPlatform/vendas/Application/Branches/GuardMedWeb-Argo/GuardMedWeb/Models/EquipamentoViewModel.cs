using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GuardMedWeb.Models
{
    public class EquipamentoViewModel
    {
        public int? EquipamentoId { get; set; }
        public int? SeguradoEquipamentoId { get; set; }
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public string Serie { get; set; }
        public string Preco { get; set; }
        public bool? NF { get; set; }
        public int? TipoEquipamentoId { get; set; }
        public string TipoEquipamentoNome { get; set; }
        public int? Ano { get; set; }
        public string EspecificacaoTipo { get; set; }
    }
}
