using DTO.Utils;
using System;
using System.Collections.Generic;
using System.Text;

namespace DTO.Client
{
    public class ClientDependentViewModel
    {
        public int? ClientDependentId { get; set; }
        public int ClientId { get; set; }
        public int ClientDependentTypeId { get; set; }
        public int? CivilStatusId { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Cpf { get; set; }
        public string _Cpf { get { return Cpf.CPFMask(); } set { Cpf = value.NumbersOnly(); } }
        public string Rg { get; set; }
        public string _Rg { get { return Rg.RGMask(); } set { Rg = value.NumbersOnly(); } }
        public string Family { get; set; }
        public string Occupation { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public string Celular { get; set; }
        public string Cep { get; set; }
        public string _Cep { get { return Cep.CEPMask(); } set { Cep = value.NumbersOnly(); } }
        public string Endereco { get; set; }
        public string Numero { get; set; }
        public string Complemento { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string Uf { get; set; }
        public string Observation { get; set; }

        public bool IsDeleted { get; set; }
        public DateTime CreatedDate { get; set; }
        public string _CreatedDate { get { return CreatedDate.ToBrazilianDateFormat();  } }
        public int LastHandler { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string _ModifiedDate { get { return ModifiedDate.ToBrazilianDateFormat();  } }
        public DateTime? DeletedDate { get; set; }
        public string _DeletedDate { get { return DeletedDate.ToBrazilianDateFormat();  } }
        public int? DeletedBy { get; set; }
    }
}
