using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AMaisImob_WEB.Models.TooSeguros
{
    public class ProposalRequestViewModel
    {
        public class Pretendent
        {
            public string Nome { get; set; }
            public string Cpf { get; set; }
            public DateTime? DataNascimento { get; set; }
            public string EstadoCivil { get; set; }
            public bool ResidiraImovel { get; set; }
            public bool ResponsavelFinanceiroPeloImovel { get; set; }
            public string RendaFixaMensal { get; set; }
            public string OutrasRendas { get; set; }
            public string VinculoEmpregaticio { get; set; }
            public string Profissao { get; set; }
            public Phone Telefone { get; set; }
            public RG Rg { get; set; }
            public string Email { get; set; }
            public string Nacionalidade { get; set; }
            public string PessoaPoliticamenteExposta { get; set; }
            public string PoliticamenteExpostaNome { get; set; }
            public string PoliticamenteExpostaCpf { get; set; }
            public string PoliticamenteExpostaGrauParentesco { get; set; }
        }
        public class Phone
        {
            public int DDD { get; set; }
            public int Numero { get; set; }
        }
        public class RG
        {
            public string Numero { get; set; }
            public DateTime DataEmissao { get; set; }
            public string OrgaoEmissor { get; set; }
        }

        public class Rent
        {
            public string CEP { get; set; }
            public string Logradouro { get; set; }
            public string Numero { get; set; }
            public string Cep { get; set; }
            public string Complemento { get; set; }
            public string Bairro { get; set; }
            public string Cidade { get; set; }
            public string Uf { get; set; }
            public Company Imobiliaria { get; set; }
            public Person CorretorImoveis { get; set; }
            public string IndiceReajusteLocacao { get; set; }
            public string PeriodicidadeLocacao { get; set; }
            public DateTime DataInicioVigenciaLocacao { get; set; }
            public DateTime DataFimVigenciaLocacao { get; set; }
            public string FinalidadeLocacao { get; set; }
            public bool PossuiEmpresaConstituida { get; set; }
            public IncorporatedCompany EmpresaConstituida { get; set; }
        }

        public class Company
        {
            public string RazaoSocial { get; set; }
            public string Cnpj { get; set; }
        }

        public class Person
        {
            public string Nome { get; set; }
            public string CPF { get; set; }
        }

        public class IncorporatedCompany
        {
            public string Cnpj { get; set; }
            public string RamoAtividade { get; set; }
        }

        public string NumeroCotacao { get; set; }
        public List<Pretendent> Pretendentes { get; set; }
        public Rent Locacao { get; set; }
        public Company CorretorSeguros { get; set; }

        public ProposalRequestViewModel() {
            Pretendentes = new List<Pretendent>();
            Locacao = new Rent();
            CorretorSeguros = new Company();
        }
        public ProposalRequestViewModel(AMaisImob_DB.Models.CertificateContractual certificateContractual) {
            Pretendentes = new List<Pretendent>();
            Locacao = new Rent();
            CorretorSeguros = new Company();

            Pretendentes.Add(new Pretendent
            {
                Cpf = certificateContractual.CPFCNPJ,
                DataNascimento = certificateContractual.BirthDate,
                //TODO: completar os dados restantes
            });

        }
    }
}
