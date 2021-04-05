using DTO.Utils;
using System;
using System.Collections.Generic;
using System.Text;

namespace DTO.Client
{
    public class ClientViewModel
    {
        public int? ClientId { get; set; }
        public string ClientName { get { return (string.IsNullOrWhiteSpace(RazaoSocial) ? FirstName + " " + LastName : RazaoSocial); } }
        public string ClientDocument { get { return (string.IsNullOrWhiteSpace(Cnpj) ? Cpf : Cnpj); } }
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
        public string rg { get; set; }
        public string Rg
        {
            get { return this.rg; }
            set { this.rg = value.NumbersOnly(); }
        }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Occupation { get; set; }
        public string Email { get; set; }
        public string telefone;
        public string Telefone
        {
            get { return this.telefone; }
            set { this.telefone = value.NumbersOnly(); }
        }
        public string celular;
        public string Celular
        {
            get { return this.celular; }
            set { this.celular = value.NumbersOnly(); }
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
        public bool? IsActive { get; set; }
        public string Observation { get; set; }
        public int ClientTypeId { get; set; }
        public int? LastHandler { get; set; }
        //public string Contact { get; set; }
        public bool? FirstContacted { get; set; }
        public DateTime? FirstContactDate { get; set; }
        public int? FirstContactBy { get; set; }
        public int? ResponsibleId { get; set; }
        public string ResponsibleName { get; set; }
        public string ResponsiblePhone { get; set; }
        public string ResponsibleMobilePhone { get; set; }
        public DateTime? ResponsibleDate { get; set; }
        public int? ContactMediumId { get; set; }
        public string Token { get; set; }
        public int? ClientStatusId { get; set; }
        public DateTime CreatedDate { get; set; }
        public int? CreatorUserId { get; set; }
        public int? CivilStatusId { get; set; }
        public string CivilStatusName { get; set; }
        public string Family { get; set; }
        public string RDStation_uuid { get; set; }
    }
}
