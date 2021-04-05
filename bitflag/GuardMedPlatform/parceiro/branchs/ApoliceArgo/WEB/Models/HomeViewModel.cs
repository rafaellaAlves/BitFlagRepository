using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WEB.Models
{
    public class HomeViewModel
    {
        public int CertificadosPendentes { get; set; }
        public int CertificadosAtivos { get; set; }
        public int CertificadosRenovar { get; set; }
        public Dictionary<string, int> CertificadosAderidos { get; set; }
        public double TaxaClubeInquilino { get; set; }
        public double UltimaFatura { get; set; }
        public double ProximaFatura { get; set; }
    }
}
