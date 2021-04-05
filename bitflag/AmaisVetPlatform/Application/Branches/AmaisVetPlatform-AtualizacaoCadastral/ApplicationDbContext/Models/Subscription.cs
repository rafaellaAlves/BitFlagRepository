using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace ApplicationDbContext.Models
{
    public partial class Subscription
    {
        public int SubscriptionId { get; set; }
        public string Reference { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string MobileNumber { get; set; }
        public DateTime BirthDate { get; set; }
        public string Cpf { get; set; }
        public string Crmv { get; set; }
        public string Crmvstate { get; set; }
        public int? OccupationAreaId { get; set; }
        public int? ProfessionalSpecialtyId { get; set; }
        public int? GraduationYear { get; set; }
        public bool? IsStateAgreement { get; set; }
        public int? PlanId { get; set; }
        public string PlanName { get; set; }
        public int? PlanPriceTableId { get; set; }
        public double? MonthlyCost { get; set; }
        public double? MonthlyDiscount { get; set; }
        public double? MonthlyTotal { get; set; }
        public string ZipCode { get; set; }
        public string Address { get; set; }
        public string AddressNumber { get; set; }
        public string AddressAdditionalInfo { get; set; }
        public string Neighborhood { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public bool HasCompany { get; set; }
        public string CompanyName { get; set; }
        public string Cnpj { get; set; }
        public string IuguId { get; set; }
        public bool BilledByCompany { get; set; }
        public int? HealthQuestionnaireId { get; set; }
        public bool HealthBlock { get; set; }
        public DateTime? HealthBlockDate { get; set; }
        public Guid? HealthUnblockToken { get; set; }
        public DateTime? HealthUnblockDate { get; set; }
        public int? HealthUnblockBy { get; set; }
        public int? PaymentMethodId { get; set; }
        public DateTime? PaymentDate { get; set; }
        public bool? PaymentHasError { get; set; }
        public string PaymentErrorDetails { get; set; }
        public bool HasCertificate { get; set; }
        public DateTime? CertificateDate { get; set; }
        public bool CertificateSentError { get; set; }
        public string CertificateSentErrorDetails { get; set; }
        public DateTime? EffectiveStartDate { get; set; }
        public DateTime? EffectiveEndDate { get; set; }
        public int? AffiliateId { get; set; }
        public string Coupon { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? AlteredDate { get; set; }
        public bool IsDeleted { get; set; }
    }
}
