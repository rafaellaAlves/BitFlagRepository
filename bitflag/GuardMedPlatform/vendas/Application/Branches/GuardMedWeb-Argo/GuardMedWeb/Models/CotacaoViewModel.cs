using GuardMedWeb.BLL.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GuardMedWeb.Models
{
    public class CotacaoViewModel
    {
        public string Nome { get; set; }

        public double ValorCobertura { get; set; }
        public string ValorCoberturaFormatado => ValorCobertura.ToPtBr();

        public double PercentualDescontoGrupoMedico { get; set; }
        public int? PercentualDescontoPlataforma { get; set; }
        public double PercentualDesconto => PercentualDescontoPlataforma ?? PercentualDescontoGrupoMedico;
        public bool PossuiDesconto => PercentualDesconto > 0;

        public double Franquia { get; set; }
        public string FranquiaFormatado => Franquia.ToPtBr();

        public double PrecoMensal { get; set; }
        public string PrecoMensalFormatado => PrecoMensal.ToPtBr();
        public string PrecoMensalFormatadoInteiro => PrecoMensalFormatado.Split(",")[0];
        public string PrecoMensalFormatadoCentavos => PrecoMensalFormatado.Split(",")[1];

        public double PrecoAnual { get; set; }
        public string PrecoAnualFormatado => PrecoAnual.ToPtBr();

        public double DescontoMensal => Math.Round(PrecoMensal * (PercentualDesconto / 100d), 2);
        public string DescontoMensalFormatado => DescontoMensal.ToPtBr();

        public double DescontoAnual => Math.Round((PrecoMensal * (PercentualDesconto / 100d)) * 12d, 2);
        public string DescontoAnualFormatado => DescontoAnual.ToPtBr();

        public double PrecoMensalTotal => PrecoMensal - DescontoMensal;
        public string PrecoMensalTotalFormatado => PrecoMensalTotal.ToPtBr();
        public string PrecoMensalTotalFormatadoInteiro => PrecoMensalTotalFormatado.Split(",")[0];
        public string PrecoMensalTotalFormatadoCentavos => PrecoMensalTotalFormatado.Split(",")[1];

        public double PrecoAnualTotal => PrecoAnual - DescontoAnual;
        public string PrecoAnualTotalFormatado => PrecoAnualTotal.ToPtBr();

        public int EspecialidadePrecoId { get; set; }
        public int PlanoSeguroProfissionalId { get; internal set; }
    }
}
