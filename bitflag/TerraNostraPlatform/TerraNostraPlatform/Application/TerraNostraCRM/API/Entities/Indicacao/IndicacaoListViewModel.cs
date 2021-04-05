using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Entities.Indicacao
{
    public class IndicacaoListViewModel
    {
        public string Nome { get; set; }
        public string Data { get; set; }
        public string Status { get; set; }
        public string Comissao { get; set; }
    }
}
