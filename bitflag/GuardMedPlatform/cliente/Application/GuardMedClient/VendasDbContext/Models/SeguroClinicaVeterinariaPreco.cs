using System;
using System.Collections.Generic;

namespace VendasDbContext.Models
{
    public partial class SeguroClinicaVeterinariaPreco
    {
        public int SeguroClinicaVeterinariaPrecoId { get; set; }
        public int PlanoClinicaVeterinariaId { get; set; }
        public double Custo { get; set; }
        public double? Rcppjcusto { get; set; }
        public double? Rcppfcusto { get; set; }
        public double? EmpresarialCusto { get; set; }
        public double? ServicosAdmcusto { get; set; }
        public double? Bloco1Bruto { get; set; }
        public double? Bloco1Liquido { get; set; }
        public double? Bloco2Bruto { get; set; }
        public double? Bloco2Liquido { get; set; }
        public double? Bloco1e2Bruto { get; set; }
        public double? Bloco1e2Liquido { get; set; }
        public double? Bloco3Bruto { get; set; }
        public double? Bloco1e2e3Bruto { get; set; }
        public double? Bloco1e2e3Liquido { get; set; }
    }
}
