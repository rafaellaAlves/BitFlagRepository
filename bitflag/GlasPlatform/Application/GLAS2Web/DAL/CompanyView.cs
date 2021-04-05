using System;
using System.Collections.Generic;
using Utils;

namespace DAL
{
    public partial class CompanyView
    {
        [System.ComponentModel.DataAnnotations.Key]
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
        public int? CountryId { get; set; }
        public string Country { get; set; }
        public int? StateId { get; set; }
        public string State { get; set; }
        public int? CityId { get; set; }
        public string City { get; set; }
        public bool HasLogo { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
        public int CompanyQuestionStatusId { get; set; }
        public string CompanyQuestionStatusName { get; set; }
        public bool CompanyEndedQuestions { get; set; }
    }
}
