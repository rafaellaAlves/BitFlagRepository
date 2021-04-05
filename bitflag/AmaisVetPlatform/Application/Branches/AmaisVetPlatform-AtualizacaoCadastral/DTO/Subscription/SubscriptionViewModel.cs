using DTO.Extensions;
using System;
using System.Collections.Generic;
using System.Text;

namespace DTO.Subscription
{
    public class SubscriptionViewModel
    {
        public int SubscriptionId { get; set; }
        public string Reference { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string MobileNumber { get; set; }
        public DateTime BirthDate { get; set; }
        public string BirthDateFormatted { get { return BirthDate.ToDateOnly(); } }
        public int Age
        {
            get
            {
                var now = DateTime.Today;
                int age = now.Year - BirthDate.Year;
                if (now < BirthDate.AddYears(age)) age--;

                return age;
            }
        }
        public string AgeRange
        {
            get
            {
                if (Age < 20) return "menos de 20 anos";
                else if (Age >= 20 && Age <= 29) return "entre 20 e 29 anos";
                else if (Age >= 30 && Age <= 39) return "entre 30 e 39 anos";
                else if (Age >= 40 && Age <= 49) return "entre 40 e 49 anos";
                else if (Age >= 50 && Age <= 59) return "entre 50 e 59 anos";
                else if (Age >= 60) return "mais de 60 anos";

                return "-";
            }
        }
        public string Cpf { get; set; }
        public string CpfClean { get { return Cpf.NumbersOnly(); } }
        public string Crmv { get; set; }
        public string Crmvstate { get; set; }
        public int? OccupationAreaId { get; set; }
        public string OccupationArea { get; set; }
        public int? ProfessionalSpecialtyId { get; set; }
        public string ProfessionalSpecialty { get; set; }
        public int? GraduationYear { get; set; }
        public bool? IsStateAgreement { get; set; }
        public int? PlanId { get; set; }
        public string PlanName { get; set; }
        public int? PlanPriceTableId { get; set; }
        public double? MonthlyCost { get; set; }
        public string MonthlyCostFormatted => MonthlyCost.ToMoney();
        public double? AnnualCost
        {
            get
            {
                return !MonthlyCost.HasValue ? null : (double?)Math.Round(MonthlyCost.Value * 12d, 2);
            }
        }
        public string AnnualCostFormatted => AnnualCost.ToMoney();
        public double? MonthlyDiscount { get; set; }
        public string MonthlyDiscountFormatted => MonthlyDiscount.ToMoney();
        public double? AnnualDiscount
        {
            get
            {
                return !AnnualDiscount.HasValue ? null : (double?)Math.Round(AnnualDiscount.Value * 12d, 2);
            }
        }
        public string AnnualDiscountFormatted => AnnualDiscount.ToMoney();
        public double? MonthlyTotal { get; set; }
        public string MonthlyTotalFormatted => MonthlyTotal.ToMoney();
        public double? AnnualTotal
        {
            get
            {
                return !MonthlyTotal.HasValue ? null : (double?)Math.Round(MonthlyTotal.Value * 12d, 2);
            }
        }
        public string AnnualTotalFormatted => AnnualTotal.ToMoney();
        public string ZipCode { get; set; }
        public string ZipCodeClean => ZipCode.NumbersOnly();
        public string Address { get; set; }
        public string AddressNumber { get; set; }
        public string AddressAdditionalInfo { get; set; }
        public string Neighborhood { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public bool HasCompany { get; set; }
        public string CompanyName { get; set; }
        public string Cnpj { get; set; }
        public string CnpjClean { get { return Cnpj.NumbersOnly(); } }
        public string IuguId { get; set; }
        public bool BilledByCompany { get; set; }
        public bool HealthBlock { get; set; }
        public DateTime? HealthBlockDate { get; set; }
        public string HealthBlockDateFormatted { get { return HealthBlockDate.ToDateOnly(); } }
        public DateTime? HealthUnblockDate { get; set; }
        public string HealthUnblockDateFormatted { get { return HealthUnblockDate.ToDateOnly(); } }
        public int? HealthUnblockBy { get; set; }
        public int? PaymentMethodId { get; set; }
        public DateTime? PaymentDate { get; set; }
        public string PaymentDateFormatted { get { return PaymentDate.ToDateOnly(); } }
        public bool HasCertificate { get; set; }
        public DateTime? CertificateDate { get; set; }
        public string CertificateDateFormatted { get { return CertificateDate.ToDateOnly(); } }
        public string CertificateDateTimeFormatted { get { return CertificateDate.ToDateTime(); } }
        public DateTime? EffectiveStartDate { get; set; }
        public string EffectiveStartDateFormatted { get { return EffectiveStartDate.ToDateOnly(); } }
        public DateTime? EffectiveEndDate { get; set; }
        public string EffectiveEndDateFormatted { get { return EffectiveEndDate.ToDateOnly(); } }
        public int? AffiliateId { get; set; }
        public string Coupon { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CreatedDateFormatted { get { return CreatedDate.ToDateOnly(); } }
        public DateTime? AlteredDate { get; set; }
        public string AlteredDateFormatted { get { return AlteredDate.ToDateOnly(); } }        
    }
}
