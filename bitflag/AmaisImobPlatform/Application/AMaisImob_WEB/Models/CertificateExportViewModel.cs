using AMaisImob_WEB.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AMaisImob_WEB.Models
{
    public class CertificateExportViewModel
    {
        public string Referencia { get; set; }
        public string NovoOuRenovado { get; set; }
        public string DataDeInclusao { get; set; }
        public string Imobiliaria { get; set; }
        public string Corretora { get; set; }
        public int ProductId { get; set; }
        public string Produto { get; set; }
        public string Apolice { get; set; }
        public string NomeInquilino { get; set; }
        public string CPFInquilino { get; set; }
        public string NomeProprietario { get; set; }
        public string CPFProprietario { get; set; }
        public string TipoDeImovel { get; set; }
        public string CEP { get; set; }
        public string LocalDeRisco { get; set; }
        public string Numero { get; set; }
        public string Complemento { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string UF { get; set; }
        public string Plano { get; set; }
        public string Coberturas { get; set; }
        public string CoberturaBasica { get; set; }
        public double PrecoPlano { get; set; }
        public int TaxaInquilino { get; set; }
        public double ValorAssistencia { get; set; }
        public double PrecoPlanoEAssistencia { get { return PrecoPlano + ValorAssistencia; } }
        //24
        //public int? CertificateId { get; set; }
        //public string Reference { get; set; }
        //public int? ProductId { get; set; }
        //public string ProductName { get; set; }
        //public string RenterName { get; set; }
        //public string RenterCpf { get; set; }
        //public string RenterEmail { get; set; }
        //public string RenterPhone { get; set; }
        //public string LocatorName { get; set; }
        //public string LocatorCpf { get; set; }
        //public string Cep;
        //public string Endereco { get; set; }
        //public string Numero { get; set; }
        //public string Complemento { get; set; }
        //public string Bairro { get; set; }
        //public string Cidade { get; set; }
        //public string Uf { get; set; }
        //public int? PropertyTypeId { get; set; }
        //public string PropertyTypeName { get; set; }
        //public string PropertyTypeDescription { get; set; }
        //public bool? IsApproved { get; set; }
        //public DateTime? ApprovedDate { get; set; }
        //public int? ApprovedBy { get; set; }
        //public bool? IsDeleted { get; set; }
        //public DateTime? DeletedDate { get; set; }
        //public string _DeletedDate { get { return DeletedDate.ToDatePtBR(); } }
        //public int? DeletedBy { get; set; }
        //public string NameDeletedBy { get; set; }
        //public int? InsurancePolicyId { get; set; }
        //public string InsurancePolicyNumber { get; set; }
        //public int? RealEstateAgencyId { get; set; }
        //public string RealEstateAgencyName { get; set; }
        //public bool? RealEstateAgencyHasCNPJ { get; set; }
        //public string RealEstateAgencyDocument { get; set; }
        //public int? RealEstateId { get; set; }
        //public string RealEstateName { get; set; }
        //public string RealEstateDocument { get; set; }
        //public bool? RealEstateHasCNPJ { get; set; }
        //public DateTime CreatedDate { get; set; }
        //public int? CreatedBy { get; set; }
        //public string NameCreatedBy { get; set; }
        //public string _CreatedDate { get { return CreatedDate.ToDateTimePtBR(); } }
        //public double TotalPrice { get; set; }
        //public string _TotalPrice { get { return TotalPrice.ToPtBR(); } }
        //public double Taxes { get; set; }
        //public string _Taxes { get { return Taxes.ToPtBR(); } }
        //public string RealEstateReference { get; set; }
        //public int? CopiedFrom { get; set; }
        //public int? CopiedBy { get; set; }
        //public int PlanId { get; set; }
        //public double PlanPrice { get; set; }
        //public string _PlanPrice { get { return PlanPrice.ToPtBR(); } }
        //public double PlanAssistancePrice { get; set; }
        //public string _PlanAssistancePrice { get { return PlanAssistancePrice.ToPtBR(); } }
        //public int PaymentTimes { get; set; }
        //public DateTime? AdherenceDate { get; set; }
        //public string _AdherenceDate { get { return AdherenceDate.ToDateTimePtBR(); } }
        //public int? AdherenceBy { get; set; }
        //public string NameAdherenceBy { get; set; }
        //public int? RenewBy { get; set; }
        //public string NameRenewBy { get; set; }
        //public string ConstructionTypeName { get; set; }
        //public string HabitationTypeName { get; set; }
        //public string PlanName { get; set; }
        //public string AssistanceName { get; set; }
        //public string Coverages { get; set; }
        //public string Description { get { return IsDeleted.HasValue && IsDeleted.Value ? "CANCELADO" : CopiedFrom.HasValue ? "RENOVADO" : "INCLUÍDO"; } }
    }
}
