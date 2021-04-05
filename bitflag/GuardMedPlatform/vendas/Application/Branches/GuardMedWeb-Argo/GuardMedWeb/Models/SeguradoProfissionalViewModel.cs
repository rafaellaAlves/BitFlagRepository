using GuardMedWeb.BLL.Utils;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace GuardMedWeb.Models
{
    public class SeguradoProfissionalViewModel
    {
        public int? SeguradoProfissionalId { get; set; }
        public int? PlanoSeguroProfissionalId { get; set; }
        public string PlanoSeguroProfissionalExternalCode { get; set; }
        public string PlanoSeguroProfissionalNome { get; set; }
        public int? Idade { get; set; }
        public bool? Conveniado { get; set; }
        public string Nome { get; set; }
        public string CPF { get; set; }
        public string CRM { get; set; }
        public string EstadoCRM { get; set; }
        public string CEP { get; set; }
        public string Endereco { get; set; }
        public string EnderecoNumero { get; set; }
        public string Complemento { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
        public DateTime? DataNascimento { get; set; }
        public string _DataNascimento
        {
            get
            {
                return DataNascimento.HasValue ? DataNascimento.Value.ToString("dd/MM/yyyy") : "";
            }
            set
            {
                if (DateTime.TryParseExact(value, new string[] { "dd/MM/yyyy", "dd/MM/yy" }, CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime o))
                    DataNascimento = o;
                else
                    DataNascimento = null;
            }
        }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public string Celular { get; set; }
        public bool? Fumante { get; set; }
        public string Peso { get; set; }
        public string Altura { get; set; }
        public bool? EstaDeletado { get; set; }
        public int? PagamentoTipoId { get; set; }
        public double? PrecoTotal { get; set; }
        public string _PrecoTotal => !PrecoTotal.HasValue ? string.Empty : PrecoTotal.Value.ToPtBr();
        public double? PrecoMensal => PrecoTotal.HasValue ? Math.Round((PrecoTotal.Value / 12.0), 2) : (double?)null;
        public string PrecoMensalDoPlano { get; set; }
        public string PrecoPan { get; set; }
        public int? VezesPagamento { get; set; }
        public string Doencas { get; set; }
        public string DoencasAtuais { get; set; }
        public string Medicamentos { get; set; }
        public DateTime? DataCriacao { get; set; }
        public string _DataCriacao
        {
            get
            {
                return DataCriacao.HasValue ? DataCriacao.Value.ToString("dd/MM/yyyy") : "";
            }
            set
            {
                if (DateTime.TryParseExact(value, new string[] { "dd/MM/yyyy", "dd/MM/yy" }, CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime o))
                    DataNascimento = o;
                else
                    DataNascimento = null;
            }
        }
        public DateTime? DataAtualizacao { get; set; }
        public DateTime? DataCompra { get; set; }
        public string _DataCompra => DataCompra.HasValue ? DataCompra.Value.ToString("dd/MM/yyyy") : "";
        public bool? CertificadoGerado { get; set; }
        public string Referencia { get; set; }
        public string IUGU_invoice_secure_url { get; set; }
        public bool? IsLocked { get; set; }
        public Guid? LockedToken { get; set; }
        public int? SeguradoClinicaVeterinariaId { get; set; }
        public bool? ProtecaoRenda { get; set; }
        public string ConsultorGuardMed { get; set; }
        public bool AcceptTerm { get; set; }


        // coberturas adicionais
        public bool? DiretorChefeEquipe { get; set; }
        public bool? CoberturaAdicionalDiretorChefeEquipe { get; set; }
        public bool? SocioEmpresaAreaMedica { get; set; }
        public bool? CoberturaAdicionalSocioEmpresaAreaMedica { get; set; }

        // Especialidades
        public int? GrupoMedico { get; set; }
        public int? Especialidade1 { get; set; }
        public int? Especialidade2 { get; set; }
        public int? Especialidade3 { get; set; }

        //Impressao
        public double PrecoAdm { get; set; }
        public double PrecoAdmComDesconto { get; set; }
        public double PrecoTotalComDesconto { get; set; }
        public double PrecoTotalMenosAdm { get; set; }

        //Plataforma e Escritorio
        public int? EscritorioId { get; set; }
        public int? PlataformaId { get; set; }
        public int? DescontoPlataforma { get; set; }
        public double? PlataformaComissao { get; set; }
        public double? EscritorioComissao { get; set; }

        public List<DAL.EspecialidadeProfissional> EspecialidadeProfissional { get; set; }

        //Historico e Datas
        public DateTime? DataVencimentoSeguro { get; set; }
        public string _DataVencimentoSeguro
        {
            get
            {
                return DataVencimentoSeguro.HasValue ? DataVencimentoSeguro.Value.ToString("dd/MM/yyyy") : "";
            }
            set
            {
                if (DateTime.TryParseExact(value, new string[] { "dd/MM/yyyy", "dd/MM/yy" }, CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime o))
                    DataVencimentoSeguro = o;
                else
                    DataVencimentoSeguro = null;
            }
        }
        public DateTime? DataRetroatividade { get; set; }
        public string _DataRetroatividade
        {
            get
            {
                return DataRetroatividade.HasValue ? DataRetroatividade.Value.ToString("dd/MM/yyyy") : "";
            }
            set
            {
                if (DateTime.TryParseExact(value, new string[] { "dd/MM/yyyy", "dd/MM/yy" }, CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime o))
                    DataRetroatividade = o;
                else
                    DataRetroatividade = null;
            }
        }
        public bool? HistoricoSeguro { get; set; }

        public string RetroatividadeFileName { get; set; }
        public string RetroatividadeFilePath { get; set; }
        public double? DescontoGrupoMedico { get; set; }
        public string DescontoGrupoMedicoFormatado => DescontoGrupoMedico?.ToString("0.00");

        public int? RenovadoPor { get; set; }
        public bool PodeRenovar { get; set; }
        public bool RenovacaoPagamentoBloqueado { get; set; }
        public bool EmProcessoDeRenovacao { get; set; }

        //Especialidade Preços
        #region [Mensal]
        public int? EspecialidadePrecoId { get; set; }
        public double? EspecialidadePrecoMensal { get; set; }
        public double? EspecialidadePrecoAdmMensal { get; set; }
        public double? EspecialidadePremioTotalMensal { get; set; }
        public double EspecialidadePremioLiquidoMensal => EspecialidadePremioTotalMensal.HasValue ? Math.Round(EspecialidadePremioTotalMensal.Value / 1.0738, 2) : 0;
        public double EspecialidadeIOFMensal => EspecialidadePremioTotalMensal.HasValue ? EspecialidadePremioTotalMensal.Value - EspecialidadePremioLiquidoMensal : 0;
        public double DescontoTotalMensal
        {
            get
            {
                if (EspecialidadePrecoMensal.HasValue && PrecoMensal.HasValue)
                    return EspecialidadePrecoMensal.Value - PrecoMensal.Value;
                else
                    return 0;
            }
        }
        #endregion

        #region [Anual]
        public double? EspecialidadePrecoAnual { get; set; }
        public double? EspecialidadePrecoAdmAnual { get; set; }
        public double? EspecialidadePremioTotalAnual { get; set; }
        public double EspecialidadePremioLiquidoAnual => EspecialidadePremioTotalAnual.HasValue ? Math.Round(EspecialidadePremioTotalAnual.Value / 1.0738, 2) : 0;
        public double EspecialidadeIOFAnual => EspecialidadePremioTotalAnual.HasValue ? EspecialidadePremioTotalAnual.Value - EspecialidadePremioLiquidoAnual : 0;
        public double DescontoTotalAnual
        {
            get
            {
                if (EspecialidadePrecoAnual.HasValue && PrecoTotal.HasValue)
                    return EspecialidadePrecoAnual.Value - PrecoTotal.Value;
                else
                    return 0;
            }
        }
        #endregion

        //Dados do Grupo Médico
        public int? MedicGroupRevenuesFormId { get; set; }
        public int? MedicGroupCompanyPlatformId { get; set; }
        public double? MedicGroupPlatformAgency { get; set; }
        public double? MedicGroupPlatformLife { get; set; }
        public double? MedicGroupPlatformComission { get; set; }
        public int? MedicGroupCompanyOfficeId { get; set; }
        public double? MedicGroupOfficeAgency { get; set; }
        public double? MedicGroupOfficeLife { get; set; }
        public double? MedicGroupOfficeComission { get; set; }

        //Apolice
        public string NumeroDaApolice { get; set; }
        public DateTime? DataDaApolice { get; set; }
        public string _DataDaApolice => DataDaApolice.HasValue ? DataDaApolice.Value.ToString("dd/MM/yyyy") : "-";
        public int? UsuarioApolice { get; set; }
    }
}
