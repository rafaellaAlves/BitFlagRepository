using System;
using System.Collections.Generic;

namespace DB.Models
{
    public partial class Company
    {
        public int CompanyId { get; set; }
        public string Cnpj { get; set; }
        public string Ie { get; set; }
        public string RazaoSocial { get; set; }
        public string NomeFantasia { get; set; }
        public string Cpf { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
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
        public DateTime? TermAcceptedDate { get; set; }
        public string TermAcceptToken { get; set; }

        // Informações Bancarias
        public string NomeBanco { get; set; }
        public string AgenciaBanco { get; set; }
        public string ContaBanco { get; set; }


        // COMISSAO GENERICO
        public double? Comissao { get; set; }
        public double? Agenciamento { get; set; }
        public double? Vitalicio { get; set; }
        public string CpfResponsavel { get; set; }
        public string Responsavel { get; set; }

        public string IP { get; set; }
        public DateTime? DateAcceptTerm { get; set; }
    }

    }
