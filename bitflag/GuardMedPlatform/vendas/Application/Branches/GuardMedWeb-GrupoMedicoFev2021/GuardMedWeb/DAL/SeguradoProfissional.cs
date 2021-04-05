using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GuardMedWeb.DAL
{
    public class SeguradoProfissional
    {
        public int SeguradoProfissionalId { get; set; }
        public int? PlanoSeguroProfissionalId { get; set; }
        public int Idade { get; set; }
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
        public DateTime DataNascimento { get; set; }
        public string Email { get; set; }
        public string Celular { get; set; }
        public string Telefone { get; set; }
        public bool? Fumante { get; set; }
        public string Peso { get; set; }
        public string Altura { get; set; }
        public int? PagamentoTipoId { get; set; }
        public double? PrecoTotal { get; set; }
        public int? VezesPagamento { get; set; }
        public string Doencas { get; set; }
        public string DoencasAtuais { get; set; }
        public string Medicamentos { get; set; }
        public DateTime? DataCriacao { get; set; }
        public DateTime? DataAtualizacao { get; set; }
        public DateTime? DataCompra { get; set; }
        public bool? IsLocked { get; set; }
        public Guid? LockedToken { get; set; }
        public int? SeguradoClinicaVeterinariaId { get; set; }
        public bool? ProtecaoRenda { get; set; }
        public string ConsultorGuardMed { get; set; }
        public bool AcceptTerm { get; set; }

        public bool? PaymentOk { get; set; }
        public DateTime? PaymentDate { get; set; }
        public bool? CertificadoGerado { get; set; }
        public string Referencia { get; set; }

        public string IUGU_customer_id { get; set; }
        public string IUGU_token { get; set; }
        public string IUGU_customer_payment_method_id { get; set; }
        public string IUGU_subscription_id { get; set; }
        public string IUGU_invoice_id { get; set; }
        public string IUGU_invoice_secure_url { get; set; }

        public bool? DiretorChefeEquipe { get; set; }
        public bool? CoberturaAdicionalDiretorChefeEquipe { get; set; }
        public bool? SocioEmpresaAreaMedica { get; set; }
        public bool? CoberturaAdicionalSocioEmpresaAreaMedica { get; set; }

        public int? GrupoMedico { get; set; }
        public int? Especialidade1 { get; set; }
        public int? Especialidade2 { get; set; }
        public int? Especialidade3 { get; set; }

        public int? EscritorioId { get; set; }
        public int? PlataformaId { get; set; }
        public int? DescontoPlataforma { get; set; }

        public DateTime? DataVencimentoSeguro { get; set; }
        public DateTime? DataRetroatividade { get; set; }
        public bool? HistoricoSeguro { get; set; }
        public string RetroatividadeFileName { get; set; }
        public string RetroatividadeFilePath { get; set; }
        public bool IsDeleted { get; set; }
        public int? DeletedBy { get; set; }
        public DateTime? DeletedDate { get; set; }

        public int? RenovadoPor { get; set; }
        public bool EmProcessoDeRenovacao { get; set; }
        public bool RenovacaoPagamentoBloqueado { get; set; } // O pagamento é bloqueado quando o administrador envia o email para redefinição dos dados de cartão de crédito (Ação realizada na renovação do certificado).

        public string Senha { get; set; }
        public double? DescontoGrupoMedico { get; set; }
    }
}
