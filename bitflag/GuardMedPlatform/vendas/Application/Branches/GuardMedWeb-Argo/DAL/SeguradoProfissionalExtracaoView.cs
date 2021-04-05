using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DAL
{
    public class SeguradoProfissionalExtracaoView
    {
        [Key]
        public int SeguradoProfissionalId { get; set; }
        public string Referencia { get; set; }
        public string ConsultorGuardMed { get; set; }
        public int? PlataformaId { get; set; }
        public int? EscritorioId { get; set; }
        public string PlataformaPF { get; set; } = default;
        public string EscritorioPF { get; set; } = default;
        public string PlataformaPFLast { get; set; } = default;
        public string EscritorioPFLast { get; set; } = default;
        public string PlataformaPJ { get; set; }
        public string EscritorioPJ { get; set; }
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
        public double? PrecoNormal { get; set; }
        public double? Desconto { get; set; }
        public double? PrecoNormalComDesconto { get; set; }
        public double? ValorTotalAnualComDesconto { get; set; }
        public double? PrecoMensalNormal { get; set; }
        public double? PrecoMensalComDesconto { get; set; }
        public double? ValorTotalMensalComDesconto { get; set; }
        public DateTime? DataCriacao { get; set; }
        public bool? CoberturaAdicionalDiretorChefeEquipe { get; set; }
        public bool? CoberturaAdicionalSocioEmpresaAreaMedica { get; set; }
        public double? PrecoAdmMensal { get; set; }
        public double? PrecoAdmAnual { get; set; }
        public float? PremioAnual { get; set; }
        public float? PremioMensal { get; set; }
        public string Status { get; set; }
        public DateTime? DataAtualizacao { get; set; }
        public DateTime? DataCompra { get; set; }
        public DateTime? DataRetroatividade { get; set; }
        public string Telefone { get; set; }
        public string Celular { get; set; }
        public bool CertificadoGerado { get; set; }
        public string Endereco { get; set; }
        public string EnderecoNumero { get; set; }
        public string Complemento { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
        public string CEP { get; set; }
        public bool IsDeleted { get; set; }
    }
}
