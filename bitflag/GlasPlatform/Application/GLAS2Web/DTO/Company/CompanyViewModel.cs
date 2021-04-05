using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Utils;

namespace DTO.Company
{
    public class CompanyViewModel
    {
        public int? CompanyId { get; set; }
        public string cnpj;
        public string Cnpj
        {
            get { return this.cnpj; }
            set { this.cnpj = value.NumbersOnly(); }
        }
        public string Ie { get; set; }
        public string RazaoSocial { get; set; }
        public string NomeFantasia { get; set; }
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
        public int? CountryId { get; set; }
        public int? StateId { get; set; }
        public int? CityId { get; set; }
        public string Uf { get; set; }
        public bool HasLogo { get; set; }

        public bool QuestionEmailSended { get; set; }
        public DateTime? QuestionEmailSendDate { get; set; }
        public bool EndedQuestions { get; set; }
        public Guid? CompanyQuestionToken { get; set; }

        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
    }
}
