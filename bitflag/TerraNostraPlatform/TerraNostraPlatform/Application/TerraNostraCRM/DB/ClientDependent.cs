using System;
using System.Collections.Generic;

namespace DB
{
    public partial class ClientDependent
    {
        public int ClientDependentId { get; set; }
        public int ClientId { get; set; }
        public int ClientDependentTypeId { get; set; }
        public int? CivilStatusId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Cpf { get; set; }
        public string Rg { get; set; }
        public string Family { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public string Celular { get; set; }
        public string Occupation { get; set; }
        public string Cep { get; set; }
        public string Endereco { get; set; }
        public string Numero { get; set; }
        public string Complemento { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string Uf { get; set; }
        public string Observation { get; set; }
        public int LastHandler { get; set; }
        public DateTime CreatedDate { get; set; }
        public bool IsDeleted { get; set; }
        public int? DeletedBy { get; set; }
        public DateTime? DeletedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
    }
}
