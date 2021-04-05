using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GuardMedWeb.DAL
{
    public class RendaProtegidaPreco
    {
        public int RendaProtegidaPrecoId { get; set; }
        public int IdadeMin { get; set; }
        public int IdadeMax { get; set; }
        public float PrecoMensal { get; set; }
    }
}
