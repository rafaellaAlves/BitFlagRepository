using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace Web.DTO.SeguradoProfissional
{
    public class SeguradoProfissionalHistoricoViewModel
    {
        public int? SeguradoProfissionalHistoricoId { get; set; }
        public int SeguradoProfissionalId { get; set; }
        public bool Creation { get; set; }
        public string Observation { get => Creation ? "Criação" : "Atualização"; }
        public DateTime DataCriacaoHistorico { get; set; }
        public string _DataCriacaoHistorico { get => DataCriacaoHistorico.ToString("dd/MM/yyyy", CultureInfo.CreateSpecificCulture("pt-BR")); }
        public string _DataTimeCriacaoHistorico { get => DataCriacaoHistorico.ToString("dd/MM/yyyy hh:mm:ss", CultureInfo.CreateSpecificCulture("pt-BR")); }

        public List<SeguradoProfissionalHistoricoItemViewModel> Changes { get; set; }
    }
}
