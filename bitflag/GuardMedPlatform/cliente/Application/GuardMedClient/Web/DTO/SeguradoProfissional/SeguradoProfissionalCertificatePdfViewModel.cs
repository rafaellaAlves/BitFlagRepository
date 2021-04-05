using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web.DTO.Especialidade;

namespace Web.DTO.SeguradoProfissional
{
    public class SeguradoProfissionalCertificatePdfViewModel
    {
        public string Referencia { get; set; }
        public int PlanoSeguroProfissionalId { get; set; }
        public DateTime DataCriacao { get; set; }
        public DateTime? DataAtualizacao { get; set; }
        public string Nome { get; set; }
        public DateTime? DataNascimento { get; set; }
        public string CPF { get; set; }
        public string CRM { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public string Celular { get; set; }
        public int? PagamentoTipoId { get; set; }
        public int? VezesPagamento { get; set; }
        public string CEP { get; set; }
        public string Endereco { get; set; }
        public string EnderecoNumero { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
        public int? SeguradoClinicaVeterinariaId { get; set; }
        public bool? HistoricoSeguro { get; set; }
        public DateTime? DataRetroatividade { get; set; }
        public string _DataRetroatividade { get => DataRetroatividade?.ToString("dd/MM/yyyy"); }
        public double PrecoAdm { get; set; }
        public double PrecoTotal { get; set; }
        public string _PrecoTotal { get => PrecoTotal.ToString("#,###,##0.00"); }
        public double PrecoMensal { get => PrecoTotal / 12.0d; }
        public double PrecoTotalComDesconto { get; set; }
        public double PrecoTotalMenosAdm { get; set; }

        private double ValorAtualIOF { get => 7.38d; }

        public double PrecoAdmComIOF
        {
            get
            {
                if (DiretorChefeEquipe == true && CoberturaAdicionalDiretorChefeEquipe == true && SocioEmpresaAreaMedica == true && CoberturaAdicionalSocioEmpresaAreaMedica == true) return PrecoAdm + (PrecoAdm / 100 * 20);
                else if (DiretorChefeEquipe == true && CoberturaAdicionalDiretorChefeEquipe == true) return PrecoAdm + (PrecoAdm / 100 * 10);
                else if (SocioEmpresaAreaMedica == true && CoberturaAdicionalSocioEmpresaAreaMedica == true) return PrecoAdm + (PrecoAdm / 100 * 10);

                return PrecoAdm;
            }
        }
        public string _PrecoAdmComIOF { get => PrecoAdmComIOF.ToString("#,###,##0.00"); }
        public double PrecoTotalSemIOF { get => EspecialidadePreco.PrecoTotalMenosAdm - (EspecialidadePreco.PrecoTotalMenosAdm / 100 * ValorAtualIOF); }
        public string _PrecoTotalSemIOF { get => PrecoTotalSemIOF.ToString("#,###,##0.00"); }
        public double CoberturaDiretorSemIOF { get => CoberturaAdicionalDiretorChefeEquipe == true ? PrecoTotalSemIOF / 100 * 10 : 0d; }
        public string _CoberturaDiretorSemIOF { get => CoberturaDiretorSemIOF.ToString("#,###,##0.00"); }
        public double CoberturaSocioEmpresaSemIOF { get => CoberturaAdicionalSocioEmpresaAreaMedica == true ? PrecoTotalSemIOF / 100 * 10 : 0d; }
        public string _CoberturaSocioEmpresaSemIOF { get => CoberturaSocioEmpresaSemIOF.ToString("#,###,##0.00"); }
        public double PremioValor { get => PrecoTotalSemIOF + PrecoAdmComIOF + CoberturaDiretorSemIOF + CoberturaSocioEmpresaSemIOF; }
        public string _PremioValor { get => PremioValor.ToString("#,###,##0.00"); }
        public double CoberturaExtraAnualDiretor
        {
            get
            {

                if (DiretorChefeEquipe == true && CoberturaAdicionalDiretorChefeEquipe == true && SocioEmpresaAreaMedica == true && CoberturaAdicionalSocioEmpresaAreaMedica == true) return EspecialidadePreco.PrecoTotalMenosAdm / 100 * 10;
                else if (DiretorChefeEquipe == true && CoberturaAdicionalDiretorChefeEquipe == true) return EspecialidadePreco.PrecoTotalMenosAdm / 100 * 10;

                return 0d;
            }
        }
        public double CoberturaExtraMensalDiretor
        {
            get
            {

                if (DiretorChefeEquipe == true && CoberturaAdicionalDiretorChefeEquipe == true && SocioEmpresaAreaMedica == true && CoberturaAdicionalSocioEmpresaAreaMedica == true) return EspecialidadePreco.PrecoMensalMenosAdm / 100 * 10;
                else if (DiretorChefeEquipe == true && CoberturaAdicionalDiretorChefeEquipe == true) return EspecialidadePreco.PrecoMensalMenosAdm / 100 * 10;

                return 0d;
            }
        }

        public double CoberturaExtraAnualJuridica
        {
            get
            {
                if (DiretorChefeEquipe == true && CoberturaAdicionalDiretorChefeEquipe == true && SocioEmpresaAreaMedica == true && CoberturaAdicionalSocioEmpresaAreaMedica == true) return EspecialidadePreco.PrecoTotalMenosAdm / 100 * 10;
                else if (SocioEmpresaAreaMedica == true && CoberturaAdicionalSocioEmpresaAreaMedica == true) return EspecialidadePreco.PrecoTotalMenosAdm / 100 * 10;

                return 0d;
            }
        }

        public double CoberturaExtraMensalJuridica
        {
            get
            {
                if (DiretorChefeEquipe == true && CoberturaAdicionalDiretorChefeEquipe == true && SocioEmpresaAreaMedica == true && CoberturaAdicionalSocioEmpresaAreaMedica == true) return EspecialidadePreco.PrecoTotalMenosAdm / 100 * 10;
                else if (SocioEmpresaAreaMedica == true && CoberturaAdicionalSocioEmpresaAreaMedica == true) return EspecialidadePreco.PrecoTotalMenosAdm / 100 * 10;

                return 0d;
            }
        }

        public double Iof
        {
            get
            {
                if (PagamentoTipoId == 1) // A VISTA, BOLETO
                    return (EspecialidadePreco.PrecoTotalMenosAdm + CoberturaExtraAnualDiretor + CoberturaExtraAnualJuridica) / 100 * ValorAtualIOF;

                return (EspecialidadePreco.PrecoTotalMenosAdm + CoberturaExtraMensalDiretor + CoberturaExtraMensalJuridica) / 100 * ValorAtualIOF;
            }
        }
        public string _Iof { get => Iof.ToString("#,###,##0.00"); }
        public double PremioValorTotal
        {
            get
            {
                if (PagamentoTipoId == 1) // A VISTA, BOLETO
                    return PrecoTotal;

                return PrecoMensal;
            }
        }
        public string _PremioValorTotal { get => PremioValorTotal.ToString("#,###,##0.00"); }

        public bool? DiretorChefeEquipe { get; set; }
        public bool? CoberturaAdicionalDiretorChefeEquipe { get; set; }
        public bool? SocioEmpresaAreaMedica { get; set; }
        public bool? CoberturaAdicionalSocioEmpresaAreaMedica { get; set; }


        public List<EspecialidadeViewModel> EspecialidadeProfissional { get; set; }
        public EspecialidadePrecoViewModel EspecialidadePreco { get; set; }

        public SeguradoProfissionalCertificatePdfViewModel()
        {
            EspecialidadeProfissional = new List<EspecialidadeViewModel>();
            EspecialidadePreco = new EspecialidadePrecoViewModel();
        }
    }
}