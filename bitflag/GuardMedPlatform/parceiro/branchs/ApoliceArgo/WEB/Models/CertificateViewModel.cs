using WEB.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WEB.Models
{
    public class CertificateViewModel
    {
        public int? CertificateId { get; set; }
        public string Reference { get; set; }
        public int? ProductId { get; set; }
        public int? PlanId { get; set; }
        public double? PlanPrice { get; set; }
        public string _PlanPrice { get { return PlanPrice.ToPtBR(); } set { PlanPrice = value.FromDoublePtBR(); } }
        [Display(Name = "Nome do locatário")]
        public string RenterName { get; set; }
        [Display(Name = "E-mail do locatário")]
        public string RenterEmail { get; set; }
        [Display(Name = "Telefone do locatário", Description = "phone")]
        public string RenterPhone { get; set; }
        public string Rentercpf { get; set; }
        [Display(Name = "CPF/CNPJ do locatário", Description = "cnpj")]
        public string RenterCpf
        {
            get { return this.Rentercpf; }
            set { this.Rentercpf = value.NumbersOnly(); }
        }
        [Display(Name = "Nome do locador")]
        public string LocatorName { get; set; }
        public string Locatorcpf { get; set; }
        [Display(Name = "CPF/CNPJ do locador", Description = "cnpj")]
        public string LocatorCpf
        {
            get { return this.Locatorcpf; }
            set { this.Locatorcpf = value.NumbersOnly(); }
        }
        public string cep;
        [Display(Name = "CEP", Description = "cep")]
        public string Cep
        {
            get { return this.cep; }
            set { this.cep = value.NumbersOnly(); }
        }
        [Display(Name = "Endereço")]
        public string Endereco { get; set; }
        [Display(Name = "Número")]
        public string Numero { get; set; }
        [Display(Name = "Complemento")]
        public string Complemento { get; set; }
        [Display(Name = "Bairro")]
        public string Bairro { get; set; }
        [Display(Name = "Cidade")]
        public string Cidade { get; set; }
        [Display(Name = "UF")]
        public string Uf { get; set; }
        public int? PropertyTypeId { get; set; }
        [Display(Name = "Descrição do Tipo de Propriedade")]
        public string PropertyTypeDescription { get; set; }
        public bool? IsApproved { get; set; }
        public DateTime? ApprovedDate { get; set; }
        public int? ApprovedBy { get; set; }
        [Display(Name = "Vezes de Pagamento")]
        public int? PaymentTimes { get; set; }
        public int? AssistanceId { get; set; }
        public int? InsurancePolicyId { get; set; }
        public int? RealEstateAgencyId { get; set; }
        public int? RealEstateId { get; set; }
        [Display(Name = "Taxa Inquilino")]
        public int? TaxaInquilini { get; set; }
        public int? ConstructionTypeId { get; set; }
        public int? HabitationTypeId { get; set; }
        public bool? IsDeleted { get; set; }
        public DateTime? DeletedDate { get; set; }
        public string _DeletedDate { get { return DeletedDate.HasValue ? DeletedDate.Value.ToString("dd/MM/yyyy") : ""; } }
        public int? DeletedBy { get; set; }
        public string NameDeletedBy { get; set; }
        [Display(Name = "E-mail do locador")]
        public string LocatorEmail { get; set; }
        [Display(Name = "Telefone do locador")]
        public string LocatorPhone { get; set; }
        [Display(Name = "Referência Imobiliária")]
        public string RealEstateReference { get; set; }
        public DateTime CreatedDate { get; set; }
        public int? CreatedBy { get; set; }
        public int? CopiedFrom { get; set; }
        public int? CopiedBy { get; set; }
        public bool? IsSimulation { get; set; }
        public DateTime? AdherenceDate { get; set; }
        public string _AdherenceDate { get { return AdherenceDate.HasValue ? AdherenceDate.Value.ToString("dd/MM/yyyy") : ""; } }
        public int? AdherenceBy { get; set; }
        public DateTime? VigencyDate { get; set; }
        public string _VigencyDate { get { return VigencyDate.HasValue ? VigencyDate.Value.ToString("dd/MM/yyyy") : ""; } }
        public DateTime? ModifiedDate { get; set; }
        public int? ModifiedBy { get; set; }

        //Variavéis utilizadas apenas no AuditLog
        [Display(Name = "Tipo de Construção")]
        public string ConstructionTypeName { get; set; }
        [Display(Name = "Tipo de Habitação")]
        public string HabitationTypeName { get; set; }
        [Display(Name = "Assistência")]
        public string AssistanceName { get; set; }
        [Display(Name = "Apólice")]
        public string InsurancePolicyName { get; set; }
        [Display(Name = "Imobiliária")]
        public string RealEstateAgencyName { get; set; }
        [Display(Name = "Corretora")]
        public string RealEstateName { get; set; }
        [Display(Name = "Tipo de Propriedade")]
        public string PropertyTypeName { get; set; }
        [Display(Name = "Produto")]
        public string ProductName { get; set; }
        [Display(Name = "Plano")]
        public string PlanName { get; set; }
        public bool BlockRenew { get; set; }
    }
}
