using System;
using System.Collections.Generic;

namespace VendasDbContext.Models
{
    public partial class SeguradoEquipamento
    {
        public int SeguradoEquipamentoId { get; set; }
        public int? PlanoSeguroEquipamentoId { get; set; }
        public double? PrecoEquipamento { get; set; }
        public double? PrecoSeguro { get; set; }
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public string Cep { get; set; }
        public string Endereco { get; set; }
        public string EnderecoNumero { get; set; }
        public string Complemento { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
        public bool? EstaDeletado { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public string Crmv { get; set; }
        public string Crmvestado { get; set; }
        public int? PagamentoTipoId { get; set; }
        public int? VezesPagamento { get; set; }
        public int? QtdEquipamento { get; set; }
        public DateTime? DataCriacao { get; set; }
        public DateTime? DataAtualizacao { get; set; }
        public string Celular { get; set; }
        public DateTime? DataNascimento { get; set; }
        public string Referencia { get; set; }
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public string Serie { get; set; }
        public bool? Nf { get; set; }
        public bool? CertificadoGerado { get; set; }
    }
}
