using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WEB.Utils;

namespace WEB.Models
{
    public class _CertificateViewModel
    {
        public int CertificateId { get; set; }
        public string Reference { get; set; }
        public int ProductId { get; set; }
        public int PlanId { get; set; }
        public string RenterName { get; set; }
        public string RenterCpf { get; set; }
        public string RenterEmail { get; set; }
        public string RenterPhone { get; set; }
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
        public string PropertyTypeName { get; set; }
        public string PropertyTypeDescription { get; set; }
        public bool? IsApproved { get; set; }
        public DateTime? ApprovedDate { get; set; }
        public int? ApprovedBy { get; set; }
        public bool IsDeleted { get; set; }
        public int PaymentTimes { get; set; }
        public int? AssistanceId { get; set; }
        public int? InsurancePolicyId { get; set; }
        public int? RealEstateAgencyId { get; set; }
        public int? RealEstateId { get; set; }
        public int TaxaInquilini { get; set; }
        public string _TaxaInquilini { get { return TaxaInquilini.ToPtBR(); } }
        public int? ConstructionTypeId { get; set; }
        public string ConstructionTypeName { get; set; }
        public int? HabitationTypeId { get; set; }
        public string HabitationTypeName { get; set; }
        public DateTime CreatedDate { get; set; }
        public string _CreatedDate { get { return CreatedDate.ToDatePtBR(); } }
        public string LocatorEmail { get; set; }
        public string LocatorPhone { get; set; }
        public string RealEstateReference { get; set; }
        public double PlanPrice { get; set; }
        public string _PlanPrice { get { return PlanPrice.ToPtBR(); } }
        public int? CopiedFrom { get; set; }
        public DateTime? AdherenceDate { get; set; }
        public string _AdherenceDate { get { return AdherenceDate.ToDatePtBR(); } }
        public DateTime? VigencyDate { get; set; }
        public string _VigencyDate { get { return VigencyDate.ToDatePtBR(); } }
        public bool BlockRenew { get; set; }
    }
}
