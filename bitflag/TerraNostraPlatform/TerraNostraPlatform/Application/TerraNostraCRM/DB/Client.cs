using System;
using System.Collections.Generic;

namespace DB
{
    public partial class Client
    {
        public int ClientId { get; set; }
        public string Cnpj { get; set; }
        public string Ie { get; set; }
        public string RazaoSocial { get; set; }
        public string NomeFantasia { get; set; }
        public string Cpf { get; set; }
        public string Rg { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Occupation { get; set; }
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
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime CreatedDate { get; set; }
        public int? LastHandler { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public int ClientTypeId { get; set; }
        public string Contact { get; set; }
        public DateTime? DeletedDate { get; set; }
        public int? DeletedBy { get; set; }
        public bool? FirstContacted { get; set; }
        public DateTime? FirstContactDate { get; set; }
        public int? FirstContactBy { get; set; }
        public int? ResponsibleId { get; set; }
        public DateTime? ResponsibleDate { get; set; }
        public int? ContactMediumId { get; set; }
        public string Token { get; set; }
        public int? ClientStatusId { get; set; }
        public int? CreatorUserId { get; set; }
        public int? CivilStatusId { get; set; }
        public string Family { get; set; }
        public string Celular { get; set; }
        public string RDStation_uuid { get; set; }
    }
}
