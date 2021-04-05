using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace AMaisImob_DB.Models
{
    public class CertificateListView
    {

        public string Reference { get; set; }
        public string Bairro { get; set; }
        public string Cep { get; set; }
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string Cidade { get; set; }
        public string Complemento { get; set; }
        public string Endereco { get; set; }
        public bool? IsApproved { get; set; }
        public string LocatorCpf { get; set; }
        public string LocatorName { get; set; }
        public string Numero { get; set; }
        public string PropertyTypeDescription { get; set; }
        public int PropertyTypeId { get; set; }
        public string RenterCpf { get; set; }
        public string RenterName { get; set; }
        public string Uf { get; set; }
        [Key]
        public int CertificateId { get; set; }
        public bool IsDeleted { get; set; }
        public string PropertyTypeName { get; set; }
        public int? InsurancePolicyId { get; set; }
        public string InsurancePolicyNumber { get; set; }
        public int? RealEstateAgencyId { get; set; }
        public string RealEstateAgencyName { get; set; }
        public string RealEstateAgencyCNPJ { get; set; }
        public string RealEstateAgencyDocument { get; set; }
        public int? RealEstateId { get; set; }
        public string RealEstateName { get; set; }
        public string RealEstateCNPJ { get; set; }
        public string RealEstateDocument { get; set; }
        public string RenterPhone { get; set; }
        public string RenterEmail { get; set; }
        public DateTime CreatedDate { get; set; }
        public int? ApprovedBy { get; set; }
        public DateTime? ApprovedDate { get; set; }
        public double? TotalPrice { get; set; }
        public double? Taxes { get; set; }
        public string RealEstateReference { get; set; }
        public int? DeletedBy { get; set; }
        public DateTime? DeletedDate { get; set; }
        public string NameDeletedBy { get; set; }
        public int? CopiedFrom { get; set; }
        public int? CopiedBy { get; set; }
        public double PlanPrice { get; set; }
        public double PlanAssistancePrice { get; set; }
        public int PaymentTimes { get; set; }
        public DateTime? AdherenceDate { get; set; }
        public DateTime? VigencyDate { get; set; }
        public int? AdherenceBy { get; set; }
        public string NameAdherenceBy { get; set; }
        public int? CreatedBy { get; set; }
        public string NameCreatedBy { get; set; }
        public int? RenewBy { get; set; }
        public string NameRenewBy { get; set; }
        public string AssistanceName { get; set; }
        public string ConstructionTypeName { get; set; }
        public string HabitationTypeName { get; set; }
        public string PlanName { get; set; }
        public string CopiedByReference { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string NameModifiedBy { get; set; }
        public bool BlockRenew { get; set; }
        public bool IsSimulation { get; set; }

    }
}
