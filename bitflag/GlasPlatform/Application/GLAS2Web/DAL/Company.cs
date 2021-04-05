using System;
using System.Collections.Generic;
using Utils;

namespace DAL
{
    public partial class Company
    {
        public int CompanyId { get; set; }
        public string Cnpj { get; set; }
        public string Ie { get; set; }
        public string RazaoSocial { get; set; }
        public string NomeFantasia { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public string Cep { get; set; }
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
        public DateTime CreatedDate { get; set; }
        public int? LastHandler { get; set; }
        public DateTime? ModifiedDate { get; set; }
    }
}
