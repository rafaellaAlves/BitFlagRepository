using System;
using System.Collections.Generic;
using System.Text;

namespace DB.Models
{
    public class HistoricoComissao
    {
        public int HistoricoComissaoId { get; set; }
        public int CompanyId { get; set; }
        public double? Agenciamento { get; set; }
        public double? Vitalicio { get; set; }
        public double? Comissao { get; set; }
        public DateTime CreatedDate { get; set; }
        public int CreatedBy { get; set; }
    }
}
