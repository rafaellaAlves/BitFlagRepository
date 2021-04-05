using WEB.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WEB.Models
{
    public class CompanyViewModel
    {
        public int? CompanyId { get; set; }
        public string CompanyName { get { return (string.IsNullOrWhiteSpace(RazaoSocial) ? FirstName + " " + LastName : RazaoSocial); } }
        public string CompanyDocument { get { return (string.IsNullOrWhiteSpace(Cnpj) ? Cpf : Cnpj); } }
        public string cnpj;
        public string Cnpj
        {
            get { return this.cnpj; }
            set { this.cnpj = value.NumbersOnly(); }
        }
        public string Ie { get; set; }
        public string RazaoSocial { get; set; }
        public string NomeFantasia { get; set; }
        public string cpf { get; set; }
        public string Cpf
        {
            get { return this.cpf; }
            set { this.cpf = value.NumbersOnly(); }
        }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string telefone;
        public string Telefone
        {
            get { return this.telefone; }
            set { this.telefone = value.NumbersOnly(); }
        }
        public string cep;
        public string Cep
        {
            get { return this.cep; }
            set { this.cep = value.NumbersOnly(); }
        }
        public string Endereco { get; set; }
        public string Numero { get; set; }
        public string Complemento { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string Uf { get; set; }
        public bool HasLogo { get; set; }
        public bool? IsActive { get; set; }
        public string Observation { get; set; }
        public int CompanyTypeId { get; set; }
        public int CompanyOwnerTypeId { get; set; }
        public int? ParentCompanyId { get; set; }
        public int? LastHandler { get; set; }

        // Informações Bancarias
        public string NomeBanco { get; set; }
        public string AgenciaBanco { get; set; }
        public string ContaBanco { get; set; }

        // COMISSAO GENERICO
        public double? Comissao { get; set; }
        public double? Agenciamento { get; set; }
        public double? Vitalicio { get; set; }

        public string _Comissao { get { return Comissao.ToPercentPtBR(); } set { Comissao = value.FromDoublePtBR(); } }
        public string _Agenciamento { get { return Agenciamento.ToPercentPtBR(); } set { Agenciamento = value.FromDoublePtBR(); } }
        public string _Vitalicio { get { return Vitalicio.ToPercentPtBR(); } set { Vitalicio = value.FromDoublePtBR(); } }

        public string cpfResponsavel { get; set; }
        public string CpfResponsavel
        {
            get { return this.cpfResponsavel; }
            set { this.cpfResponsavel = value.NumbersOnly(); }

        }
        public string Responsavel { get; set; }
        public string IP { get; set; }
        public bool TermAccepted { get; set; }
        public DateTime? DateAcceptTerm { get; set; }
        public DateTime? ContractSentDate { get; set; }
    }
}
