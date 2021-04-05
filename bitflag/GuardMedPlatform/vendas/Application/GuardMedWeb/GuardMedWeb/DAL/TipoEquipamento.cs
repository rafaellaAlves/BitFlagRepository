using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GuardMedWeb.DAL
{
    public class TipoEquipamento
    {
        [Key]
        public int TipoEquipamentoId { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public bool EstaAtivo { get; set; }
        public string ExternalCode { get; set; }
    }
}
