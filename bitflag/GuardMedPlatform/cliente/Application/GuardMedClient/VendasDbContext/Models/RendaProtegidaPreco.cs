using System;
using System.Collections.Generic;

namespace VendasDbContext.Models
{
    public partial class RendaProtegidaPreco
    {
        public int RendaProtegidaPrecoId { get; set; }
        public int IdadeMin { get; set; }
        public int IdadeMax { get; set; }
        public float PrecoMensal { get; set; }
    }
}
