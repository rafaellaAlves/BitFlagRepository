using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GuardMedWeb.Models
{
    public class RendaProtegidaPrecoViewModel
    {
        public int RendaProtegidaPrecoId { get; set; }
        public int IdadeMin { get; set; }
        public int IdadeMax { get; set; }
        public string PrecoMensal { get; set; }
    }
}
