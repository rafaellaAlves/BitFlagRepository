using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using WEB.Utils;

namespace WEB.Models
{
    public class SeguradoProfissionalExtracaoViewModel
    {
        public int SeguradoProfissionalId { get; set; }
        public string Referencia { get; set; }
        public string ConsultorGuardMed { get; set; }
        public string Nome { get; set; }
        public string CPF { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Email { get; set; }
        public string CRM { get; set; }
        public string EstadoCRM { get; set; }
        public string MedicGroupName { get; set; }
        public string Especialidade1 { get; set; }
        public string Especialidade2 { get; set; }
        public string Especialidade3 { get; set; }
        public string NomePlano { get; set; }
        public int? PagamentoTipoId { get; set; }
        public int? VezesPagamento { get; set; }
        public double? PrecoTotal { get; set; }
        public string _PrecoTotal { get { return PrecoTotal.ToPtBR(); } }
        public double? PrecoNormal { get; set; }
        public double? Desconto { get; set; }
        public double? PrecoNormalComDesconto { get; set; }
        public double? ValorTotalAnualComDesconto { get; set; }
      
        public string _ValorTotalAnualComDesconto { get { return ValorTotalAnualComDesconto.ToPtBR(); } }
        public double? PrecoMensalNormal { get; set; }
        public double? PrecoMensalComDesconto { get; set; }
        public double? ValorTotalMensalComDesconto { get; set; }
        public DateTime? DataCriacao { get; set; }
        public string _DataCriacao { get { return DataCriacao.ToDatePtBR(); } }
        public bool? CoberturaAdicionalDiretorChefeEquipe { get; set; }
        public bool? CoberturaAdicionalSocioEmpresaAreaMedica { get; set; }
        public double? PrecoAdmMensal { get; set; }
        public double? PrecoAdmAnual { get; set; }
        public float? PremioAnual { get; set; }
        public float? PremioMensal { get; set; }
        public string Status { get; set; }
        public DateTime? DataAtualizacao { get; set; }
        public string _DataAtualizacao { get {  return DataAtualizacao.ToDatePtBR(); } }
        public string Telefone { get; set; }
        public string Celular { get; set; }
        public bool CertificadoGerado { get; set; }
        public int? EscritorioId { get; set; }
        public int? PlataformaId { get; set; }
        public string EscritorioName { get; set; }
        public string PlataformaName { get; set; }
        public double? ComissaoAno { get; set; }
        public string _ComissaoAno { get { return ComissaoAno.ToPtBR(); } }
        public DateTime? DataCompra { get; set; }
        public string _DataCompra { get { return DataCompra.ToDatePtBR(); } }

        public bool? HistoricoSeguro { get; set; }
        public int OrigemId { get; set; }
        public string Origem { get; set; }
        public bool RetroatividadeArquivoPendente { get; set; }
        public bool CotacaoRenovacao { get; set; }
        public int PrimeiroSeguradoProfissionalId { get; set; }

        public bool IsDeleted { get; set; }
        public bool PodeRenovar { get; set; }
    }
}
