using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DAL
{
    public class SeguradoAparelhoView
    {
        [Key]
        public Int64 Id { get; set; }
        public int SeguradoEquipamentoId { get; set; }
        public string Referencia { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Celular { get; set; }
        public string Telefone { get; set; }
        public int PlanoSeguroEquipamentoId { get; set; }
        public string PlanoSeguroEquipamentoNome { get; set; }
        public int QtdEquipamento { get; set; }
        public double? PrecoEquipamento { get; set; }
        public string CRMV { get; set; }
        public string CRMVEstado { get; set; }
        public string CPF { get; set; }
        public DateTime? DataNascimento { get; set; }
        public string CEP { get; set; }
        public string Endereco { get; set; }
        public string EnderecoNumero { get; set; }
        public string Complemento { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
        public int? EquipamentoId { get; set; }
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public string Serie { get; set; }
        public double? Preco { get; set; }
        public bool? NF { get; set; }
        public int? TipoEquipamentoId { get; set; }
        public string TipoEquipamentoNome { get; set; }
        public string EspecificacaoTipo { get; set; }
        public int? Ano { get; set; }
        public int? PagamentoTipoId { get; set; }
        public string PagamentoTipoNome { get; set; }
        public double? PrecoSeguro { get; set; }
        public int? VezesPagamento { get; set; }
        public DateTime? DataCriacao { get; set; }
        public DateTime? DataAtualizacao { get; set; }
        public string StopedStep { get; set; }
    }
}