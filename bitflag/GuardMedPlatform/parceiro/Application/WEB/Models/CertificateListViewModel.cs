using WEB.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WEB.Models
{
    public class CertificateListViewModel
    {
        public int? CertificateId { get; set; }
        public string Reference { get; set; }
        public int? ProductId { get; set; }
        public string ProductName { get; set; }
        public string RenterName { get; set; }
        public string RenterCpf { get; set; }
        public string RenterEmail { get; set; }
        public string RenterPhone { get; set; }
        public string LocatorName { get; set; }
        public string LocatorCpf { get; set; }
        public string Cep;
        public string Endereco { get; set; }
        public string Numero { get; set; }
        public string Complemento { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string Uf { get; set; }
        public int? PropertyTypeId { get; set; }
        public string PropertyTypeName { get; set; }
        public string PropertyTypeDescription { get; set; }
        public bool? IsApproved { get; set; }
        public DateTime? ApprovedDate { get; set; }
        public int? ApprovedBy { get; set; }
        public bool? IsDeleted { get; set; }
        public DateTime? DeletedDate { get; set; }
        public string _DeletedDate { get { return DeletedDate.ToDatePtBR(); } }
        public int? DeletedBy { get; set; }
        public string NameDeletedBy { get; set; }
        public int? InsurancePolicyId { get; set; }
        public string InsurancePolicyNumber { get; set; }
        public int? RealEstateAgencyId { get; set; }
        public string RealEstateAgencyName { get; set; }
        public bool? RealEstateAgencyHasCNPJ { get; set; }
        public string RealEstateAgencyDocument { get; set; }
        public int? RealEstateId { get; set; }
        public string RealEstateName { get; set; }
        public string RealEstateDocument { get; set; }
        public bool? RealEstateHasCNPJ { get; set; }
        public DateTime CreatedDate { get; set; }
        public int? CreatedBy { get; set; }
        public string NameCreatedBy { get; set; }
        public string _CreatedDate { get { return CreatedDate.ToDatePtBR(); } }
        public double TotalPrice { get; set; }
        public string _TotalPrice { get { return TotalPrice.ToPtBR(); } }
        public double Taxes { get; set; }
        public string _Taxes { get { return Taxes.ToPtBR(); } }
        public string RealEstateReference { get; set; }
        public int? CopiedFrom { get; set; }
        public int? CopiedBy { get; set; }
        public string CopiedByReference { get; set; }
        public double PlanPrice { get; set; }
        public string _PlanPrice { get { return PlanPrice.ToPtBR(); } }
        public double PlanAssistancePrice { get; set; }
        public string _PlanAssistancePrice { get { return PlanAssistancePrice.ToPtBR(); } }
        public int PaymentTimes { get; set; }
        public double MonthlyPrice { get { return TotalPrice * 12 / PaymentTimes; } }
        public string _MonthlyPrice { get { return MonthlyPrice.ToPtBR(); } }
        public DateTime? AdherenceDate { get; set; }
        public string _AdherenceDate { get { return AdherenceDate.ToDateTimePtBR(); } }
        public int? AdherenceBy { get; set; }
        public string NameAdherenceBy { get; set; }
        public DateTime? VigencyDate { get; set; }
        public string _VigencyDate { get { return VigencyDate.ToDateTimePtBR(); } }
        public DateTime? EndVigencyDate { get { return !VigencyDate.HasValue ? null : (DateTime?)VigencyDate.Value.AddYears(1); } }
        public string _EndVigencyDate { get { return EndVigencyDate.ToDateTimePtBR(); } }
        public bool IsInTimeToRenovate { get { return !VigencyDate.HasValue? false : VigencyDate.Value.IsInTimeToRenovate(); } }
        public int? RenewBy { get; set; }
        public string NameRenewBy { get; set; }
        public string ConstructionTypeName { get; set; }
        public string HabitationTypeName { get; set; }
        public string PlanName { get; set; }
        public string AssistanceName { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string _ModifiedDate { get { return ModifiedDate.ToDateTimePtBR(); } }
        public int? ModifiedBy { get; set; }
        public string NameModifiedBy { get; set; }
        public DateTime SimulationTermDate { get { return CreatedDate.AddDays(7); } }
        public string _SimulationTermDate { get { return SimulationTermDate.ToDatePtBR(); } }
        public bool SimlationTermDatePassed { get { return DateTime.Compare(DateTime.Now, SimulationTermDate.AddDays(1)) > 0; } }
        public bool BlockRenew { get; set; }
        //public List<string> ModifiedHistory { get; set; }
    }
}