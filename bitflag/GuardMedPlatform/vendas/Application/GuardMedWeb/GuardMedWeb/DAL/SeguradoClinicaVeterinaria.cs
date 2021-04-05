using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GuardMedWeb.DAL
{
    public class SeguradoClinicaVeterinaria
    {
        public int SeguradoClinicaVeterinariaId { get; set; }
        public int? PlanoClinicaVeterinariaId { get; set; }
        public int? PlanoResponsavelTecnicoId { get; set; }
        public int? PlanoExtensaoCoberturaId { get; set; }
        public string Referencia { get; set; }
        public string CPF { get; set; }
        public string RazaoSocial { get; set; }
        public string CNPJ { get; set; }
        public string CEP { get; set; }
        public string Endereco { get; set; }
        public string EnderecoNumero { get; set; }
        public string Complemento { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public string Celular { get; set; }
        public string NomeGerenteFinanceiro { get; set; }
        public string NomeResponsavelTecnico { get; set; }
        public string CPFTecnico { get; set; }
        public string CRMVTecnico { get; set; }
        public string CRMVEstado { get; set; }
        public DateTime? DataNascimentoTecnico{ get; set; }
        public int? QtdFuncionarios { get; set; }
        public bool? EstaDeletado { get; set; }
        public string NomeContato { get; set; }
        public int? PagamentoTipoId { get; set; }
        public double? PrecoTotal { get; set; }
        public int? QtdFuncionarios20 { get; set; }
        public int? QtdFuncionarios30 { get; set; }
        public int? QtdFuncionarios40 { get; set; }
        public int? QtdFuncionarios50 { get; set; }
        public double? PlanoClinicaVeterinariaPreco { get; set; }
        public double? PlanoResponsavelTecnicoPreco { get; set; }
        public double? PlanoExtensaoCobertura20Preco { get; set; }
        public double? PlanoExtensaoCobertura30Preco { get; set; }
        public double? PlanoExtensaoCobertura40Preco { get; set; }
        public double? PlanoExtensaoCobertura50Preco { get; set; }
        public int? VezesPagamento { get; set; }
        public DateTime? DataCriacao { get; set; }
        public DateTime? DataAtualizacao { get; set; }
        public bool? CertificadoGerado { get; set; }
        public int? QtdCLT { get; set; }
        public bool? SeguroVida { get; set; }
        public string NomeResponsavelFinanceiro { get; set; }
        public string EmailResponsavelFinanceiro { get; set; }
        public string TelefoneResponsavelFinanceiro { get; set; }
        public string CelularResponsavelFinanceiro { get; set; }
        public bool? TecnicoFumante { get; set; }
        public string TecnicoPeso { get; set; }
        public string TecnicoAltura { get; set; }
        public string TecnicoDoencas { get; set; }
        public string TecnicoDoencasAtuais { get; set; }
        public string TecnicoMedicamentos { get; set; }
        public string IUGU_customer_id { get; set; }
        public string IUGU_invoice_id { get; set; }
        public string IUGU_invoice_secure_url { get; set; }
        public string IUGU_subscription_id { get; set; }
        
    }
}
