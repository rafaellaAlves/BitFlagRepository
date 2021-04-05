using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DB
{
    public class ClientList
    {
        [Key]
        public int ClientId { get; set; }
        public string Cnpj { get; set; }
        public string Ie { get; set; }
        public string RazaoSocial { get; set; }
        public string NomeFantasia { get; set; }
        public string Cpf { get; set; }
        public string Rg { get; set; }
        public string ClientName { get; set; }
        public string Occupation { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public string Celular { get; set; }
        public string Cep { get; set; }
        public string Endereco { get; set; }
        public string Numero { get; set; }
        public string Complemento { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string Uf { get; set; }
        public string Observation { get; set; }
        public int ClientTypeId { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
        public int? DeletedBy { get; set; }
        public string DeletedName { get; set; }
        public DateTime? DeletedDate { get; set; }
        public DateTime CreatedDate { get; set; }
        //public int? LastHandler { get; set; }
        //public DateTime? ModifiedDate { get; set; }
        public int? UserId { get; set; }
        //public string ClientUserId { get; set; }
        public bool? FirstContacted { get; set; }
        public string FirstContactedName { get; set; }
        public DateTime? FirstContactDate { get; set; }
        public int? FirstContactBy { get; set; }
        public string Token { get; set; }
        public int? ResponsibleId { get; set; }
        public string Responsible { get; set; }
        public int? ClientStatusId { get; set; }
        public string ClientStatusName { get; set; }
        public int? CivilStatusId { get; set; }
        public string Family { get; set; }
        public string CivilStatusDescription { get; set; }
    }
}
