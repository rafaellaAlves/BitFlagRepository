using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AMaisImob_WEB.Models
{
    public class HomeViewModel
    {
        public int CertificadosPendentes { get; set; }
        public int CertificadosAtivos { get; set; }
        public int CertificadosRenovar { get; set; }
        public List<PainelGestao> CertificadosAderidos { get; set; }
        public double TaxaClubeInquilino { get; set; }

        public double UltimaFatura { get; set; }
        public string ValorUltimaFatura { get; set; }
        public string ValorProximaFatura { get; set; }
        public double ProximaFatura { get; set; }
        public string TaxaInquilinoTotal { get; set; }
        public string TaxaInquilinoUltimoMes { get; set; }
        public bool? PreviousStatus { get; set; }
        public bool? CurrentStatus { get; set; }
    }
}
