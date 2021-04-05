using System;
using System.Collections.Generic;

namespace DB.Models
{
    public partial class Certificate
    {
        public int CertificateId { get; set; }
        public int ProductId { get; set; }
        public string RenterName { get; set; }
        public string RenterCpf { get; set; }
        public string LocatorName { get; set; }
        public string LocatorCpf { get; set; }
        public string Cep { get; set; }
        public string Endereco { get; set; }
        public string Numero { get; set; }
        public string Complemento { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string Uf { get; set; }
        public int PropertyTypeId { get; set; }
        public string PropertyTypeDescription { get; set; }
        public bool? IsApproved { get; set; }
        public DateTime? ApprovedDate { get; set; }
        public int? ApprovedBy { get; set; }
        public bool IsDeleted { get; set; }
        public int PlanId { get; set; }
        public int PaymentTimes { get; set; }
        public int? AssistanceId { get; set; }
        public int? InsurancePolicyId { get; set; }
        public int? RealEstateAgencyId { get; set; }
        public int? RealEstateId { get; set; }
        public int TaxaInquilini { get; set; }
        public int? ConstructionTypeId { get; set; }
        public int? HabitationTypeId { get; set; }
        public string RenterEmail { get; set; }
        public string RenterPhone { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? DeletedDate { get; set; }
        public int? DeletedBy { get; set; }
        public string Reference { get; set; }
        public string LocatorEmail { get; set; }
        public string LocatorPhone { get; set; }
        public string RealEstateReference { get; set; }
        public int? CopiedFrom { get; set; }
        public double PlanPrice { get; set; }
        public int? CopiedBy { get; set; }
        public bool IsSimulation { get; set; }
        public DateTime? AdherenceDate { get; set; }
        public int? AdherenceBy { get; set; }
        public DateTime? VigencyDate { get; set; }
        public int? RenewBy { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public int? ModifiedBy { get; set; }
        public bool BlockRenew { get; set; }
    }
}
