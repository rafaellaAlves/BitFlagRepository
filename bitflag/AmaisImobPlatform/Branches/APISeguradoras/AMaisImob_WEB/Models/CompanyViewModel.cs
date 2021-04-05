using AMaisImob_WEB.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AMaisImob_WEB.Models
{
    public class CompanyViewModel
    {
        public int? CompanyId { get; set; }
        public string CompanyName { get { return (string.IsNullOrWhiteSpace(RazaoSocial) ? FirstName + " " + LastName : RazaoSocial); } }
        public string CompanyName_TradeName { get { return (string.IsNullOrWhiteSpace(NomeFantasia) ? FirstName + " " + LastName : NomeFantasia); } }
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
        public int? CategoryId { get; set; }
        public DateTime? TermAcceptedDate { get; set; }
        public string _TermAcceptedDate => TermAcceptedDate.ToDateTimePtBR();
        public string TermAcceptedIP { get; set; }
        public int? UserPartnerId { get; set; }
        public bool? ChargeCertificate { get; set; }
        public bool? ChargeDocuSign { get; set; }
        public bool? ChargeContractualGuarantee { get; set; }
        public bool? ChargeFinancialProtection { get; set; }
        public string CompanyReference { get; set; }
        List<int> GuarantorProviders { get; set; }
    }
}
