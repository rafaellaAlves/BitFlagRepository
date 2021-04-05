using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using Web.DTO.Plano;

namespace Web.DTO.SeguradoProfissional
{
    public class InsuredChangePlanEmailViewModel
    {
        public SeguradoProfissionalViewModel Segurado { get; set; }

        public double OldPrice { get; set; }
        public string _OldPrice { get => OldPrice.ToString("#,###,##0.00", CultureInfo.CreateSpecificCulture("pt-BR")); }
        public double MonthlyOldPrice { get => OldPrice / 12; }
        public string _MonthlyOldPrice { get => MonthlyOldPrice.ToString("#,###,##0.00", CultureInfo.CreateSpecificCulture("pt-BR")); }
        public double NewPrice { get; set; }
        public string _NewPrice { get => NewPrice.ToString("#,###,##0.00", CultureInfo.CreateSpecificCulture("pt-BR")); }
        public double MonthlyNewPrice { get => NewPrice / 12; }
        public string _MonthlyNewPrice { get => MonthlyNewPrice.ToString("#,###,##0.00", CultureInfo.CreateSpecificCulture("pt-BR")); }
        public PlanoSeguroProfissionalViewModel UpgradedPlan { get; set; }
        public List<EspecialidadeViewModel> Especialidades { get; set; }

        public InsuredChangePlanEmailViewModel() { }
        public InsuredChangePlanEmailViewModel(SeguradoProfissionalViewModel segurado, double oldPrice, double newPrice, PlanoSeguroProfissionalViewModel upgradedPlan, List<EspecialidadeViewModel> especialidades) {
            Segurado = segurado;
            OldPrice = oldPrice;
            NewPrice = newPrice;
            UpgradedPlan = upgradedPlan;
            Especialidades = especialidades;
        }
    }
}
