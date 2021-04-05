using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DAL
{
    public class SeguradoClinicaVeterinariaView
    {
        [Key]
        public int SeguradoClinicaVeterinariaId { get; set; }
        public string Referencia { get; set; }
        public string NomeFantasia { get; set; }
        public string RazaoSocial { get; set; }
        public string NomeContato { get; set; }
        public string CPF { get; set; }
        public string CNPJ { get; set; }
        public string CEP { get; set; }
        public string Endereco { get; set; }
        public string EnderecoNumero { get; set; }
        public string Complemento { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
        public int? PlanoClinicaVeterinariaId { get; set; }
        public string PlanoClinicaVeterinariaNome { get; set; }
        public string NomeResponsavelFinanceiro { get; set; }
        public string EmailResponsavelFinanceiro { get; set; }
        public string TelefoneResponsavelFinanceiro { get; set; }
        public string CelularResponsavelFinanceiro { get; set; }
        public string NomeResponsavelTecnico { get; set; }
        public string CPFTecnico { get; set; }
        public DateTime? DataNascimentoTecnico { get; set; }
        public string CRMVTecnico { get; set; }
        public string CRMVEstado { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public string Celular { get; set; }
        public bool? TecnicoFumante { get; set; }
        public string TecnicoPeso { get; set; }
        public string TecnicoAltura { get; set; }
        public string TecnicoDoencas { get; set; }
        public string TecnicoDoencasAtuais { get; set; }
        public string TecnicoMedicamentos { get; set; }
        public int? PlanoResponsavelTecnicoId { get; set; }
        public string PlanoResponsavelTecnicoNome { get; set; }
        public int? QtdFuncionarios { get; set; }
        public int? QtdFuncionarios20 { get; set; }
        public int? QtdFuncionarios30 { get; set; }
        public int? QtdFuncionarios40 { get; set; }
        public int? QtdFuncionarios50 { get; set; }
        public int? PlanoExtensaoCoberturaId { get; set; }
        public string PlanoExtensaoCoberturaNome { get; set; }
        public double? PlanoClinicaVeterinariaPreco { get; set; }
        public double? PlanoResponsavelTecnicoPreco { get; set; }
        public double? PlanoExtensaoCobertura20Preco { get; set; }
        public double? PlanoExtensaoCobertura30Preco { get; set; }
        public double? PlanoExtensaoCobertura40Preco { get; set; }
        public double? PlanoExtensaoCobertura50Preco { get; set; }
        public int? PagamentoTipoId { get; set; }
        public string PagamentoTipo { get; set; }
        public double? PrecoTotal { get; set; }
        public int? VezesPagamento { get; set; }
        public DateTime? DataCriacao { get; set; }
        public bool? CertificadoGerado { get; set; }
        public string StopedStep { get; set; }
    }
}
