using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GuardMedWeb.Models
{
    public class CotacaoPageViewModel
    {
        public SeguradoProfissionalViewModel SeguradoProfissionalViewModel { get; set; }
        public List<CotacaoViewModel> Cotacoes { get; set; }
    }
}
