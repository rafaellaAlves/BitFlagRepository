using System;
using System.Collections.Generic;

namespace DAL
{
    public partial class SeguroResponsavelTecnicoPreco
    {
        public int SeguroResponsavelTecnicoPrecoId { get; set; }
        public int PlanoResponsavelTecnicoId { get; set; }
        public double Custo { get; set; }
        public int? IdadeMin { get; set; }
        public int? IdadeMax { get; set; }
    }
}
