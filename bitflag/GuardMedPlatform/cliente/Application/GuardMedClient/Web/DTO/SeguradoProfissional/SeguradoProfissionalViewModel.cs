using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using Web.Helpers;

namespace Web.DTO
{
    public class SeguradoProfissionalViewModel
    {
        public int SeguradoProfissionalId { get; set; }
        public string Referencia { get; set; }
        [ShowInHistoric]
        public string Nome { get; set; }
        [ShowInHistoric]
        public string CRM { get; set; }
        [ShowInHistoric("Estado do CRM")]
        public string EstadoCRM { get; set; }
        [ShowInHistoric]
        public string CPF { get; set; }
        public DateTime DataNascimento { get; set; }
        [ShowInHistoric("Data de Nascimento")]
        public string _DataNascimento { get { return DataNascimento.ToString("dd/MM/yyyy"); } }
        [ShowInHistoric]
        public string Celular { get; set; }
        [ShowInHistoric]
        public string Telefone { get; set; }
        [ShowInHistoric("E-mail")]
        public string Email { get; set; }
        [ShowInHistoric]
        public string CEP { get; set; }
        [ShowInHistoric("Endereço")]
        public string Endereco { get; set; }
        [ShowInHistoric("Número")]
        public string EnderecoNumero { get; set; }
        [ShowInHistoric]
        public string Complemento { get; set; }
        [ShowInHistoric]
        public string Bairro { get; set; }
        [ShowInHistoric]
        public string Cidade { get; set; }
        [ShowInHistoric]
        public string Estado { get; set; }
        public int? PlanoSeguroProfissionalId { get; set; }
        [ShowInHistoric("Plano")]
        public string PlanoSeguroProfissionalNome { get; set; }
        public DateTime? DataVencimentoSeguro { get; set; }
        public string _DataVencimentoSeguro { get => DataVencimentoSeguro?.ToString("dd/MM/yyyy", CultureInfo.CreateSpecificCulture("pt-BR")); }
        public DateTime? DataRetroatividade { get; set; }
        [ShowInHistoric("Data de Retroatividade")]
        public string _DataRetroatividade { get => DataRetroatividade?.ToString("dd/MM/yyyy", CultureInfo.CreateSpecificCulture("pt-BR")); }
        public string RetroatividadeFileName { get; set; }
        public string RetroatividadeFilePath { get; set; }
        public int? PagamentoTipoId { get; set; }
        public int? VezesPagamento { get; set; }
        public DateTime DataCriacao { get; set; }
        [ShowInHistoric("Data de Criação")]
        public string _DataCriacao { get => DataCriacao.ToString("dd/MM/yyyy", CultureInfo.CreateSpecificCulture("pt-BR")); }
        public DateTime DataAtualizacao { get; set; }
        public string _DataAtualizacao { get => DataAtualizacao.ToString("dd/MM/yyyy", CultureInfo.CreateSpecificCulture("pt-BR")); }
        public double PrecoTotal { get; set; }
        [ShowInHistoric("Preço Total do Seguro")]
        public string _PrecoTotal { get => "R$ " + PrecoTotal.ToString("#,###,##0.00", CultureInfo.CreateSpecificCulture("pt-BR")); }


        public List<EspecialidadeViewModel> Especialidades { get; set; }

        [ShowInHistoric("Especialidade 1")]
        public string Especialidade1Name { get => Especialidades.Count > 0? Especialidades[0].Nome : "-"; }
        [ShowInHistoric("Especialidade 2")]
        public string Especialidade2Name { get => Especialidades.Count > 1 ? Especialidades[1].Nome : "-"; }
        [ShowInHistoric("Especialidade 3")]
        public string Especialidade3Name { get => Especialidades.Count > 2 ? Especialidades[2].Nome : "-"; }

        public int? MedicGroupRevenuesFormId { get; set; }


        public SeguradoProfissionalViewModel()
        {
            this.Especialidades = new List<EspecialidadeViewModel>();
        }
    }
}
