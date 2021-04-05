using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AMaisImob_WEB.Models
{
    public class CompanyListViewModel
    {
        public int CompanyId { get; set; }
        public string Cnpj { get; set; }
        public string Ie { get; set; }
        public string RazaoSocial { get; set; }
        public string NomeFantasia { get; set; }
        public string ParentRazaoSocial { get; set; }
        public string ParentNomeFantasia { get; set; }
        public string Cpf { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string ParentFirstName { get; set; }
        public string ParentLastName { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public string Cep { get; set; }
        public string Endereco { get; set; }
        public string Numero { get; set; }
        public string Complemento { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string Uf { get; set; }
        public string Observation { get; set; }
        public int CompanyTypeId { get; set; }
        public int CompanyOwnerTypeId { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime CreatedDate { get; set; }
        public int? LastHandler { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public int? ParentCompanyId { get; set; }
        public bool TermAccepted { get; set; }
        public string CompanyReference { get; set; }
        public string TermAcceptToken { get; set; }
    }
}
