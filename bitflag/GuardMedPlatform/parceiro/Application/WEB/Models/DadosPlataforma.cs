using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WEB.Utils;

namespace WEB.Models
{
    public class DadosPlataforma
    {
        public string CompanyName{ get; set; }

        public double? Agenciamento { get; set; }
        public double? Vitalicio { get; set; }
        public double? Comissao { get; set; }

        public string _Comissao { get { return Comissao.ToPercentPtBR(); } set { Comissao = value.FromDoublePtBR(); } }
        public string _Agenciamento { get { return Agenciamento.ToPercentPtBR(); } set { Agenciamento = value.FromDoublePtBR(); } }
        public string _Vitalicio { get { return Vitalicio.ToPercentPtBR(); } set { Vitalicio = value.FromDoublePtBR(); } }
    }
}
