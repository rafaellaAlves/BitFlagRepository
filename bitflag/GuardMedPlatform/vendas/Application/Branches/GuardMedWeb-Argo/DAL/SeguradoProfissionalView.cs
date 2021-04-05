using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DAL
{
    public class SeguradoProfissionalView
    {
        [Key]
        public int SeguradoProfissionalId { get; set; }
        public string Referencia { get; set; }
        public string ConsultorGuardMed { get; set; }
        public string Nome { get; set; }
        public string CRM { get; set; }
        public string EstadoCRM { get; set; }
        public bool? Conveniado { get; set; }
        public string Celular { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }
        public DateTime DataNascimento { get; set; }
        public int Idade { get; set; }
        public int? PlanoSeguroProfissionalId { get; set; }
        public string PlanoSeguroProfissionalNome { get; set; }
        public string CPF { get; set; }
        public string CEP { get; set; }
        public string Endereco { get; set; }
        public string EnderecoNumero { get; set; }
        public string Complemento { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
        public string Doencas { get; set; }
        public string DoencasAtuais { get; set; }
        public string Medicamentos { get; set; }
        public bool? Fumante { get; set; }
        public string Peso { get; set; }
        public string Altura { get; set; }
        public int? PagamentoTipoId { get; set; }
        public string PagamentoTipoNome { get; set; }
        public int? VezesPagamento { get; set; }
        public int? SeguroProfissionalPrecoId { get; set; }
        public double? CustoTotal { get; set; }
        public double? CustoMensal { get; set; }
        public DateTime? DataCriacao { get; set; }
        public DateTime? DataAtualizacao { get; set; }
        public bool? IsLocked { get; set; }
        public string StopedStep { get; set; }
    }
}
