using DTO.HealthQuestionnaire;
using DTO.Payment;
using DTO.Payment.Integration;
using DTO.Subscription;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Subscription
{
    public class SubscriptionService
    {
        private readonly ApplicationDbContext.Context.ApplicationDbContext context;
        private readonly Services.Plan.PlanService planService;
        private readonly IMemoryCache memoryCache;

        public SubscriptionService(ApplicationDbContext.Context.ApplicationDbContext context, Services.Plan.PlanService planService, IMemoryCache memoryCache)
        {
            this.context = context;
            this.planService = planService;
            this.memoryCache = memoryCache;
        }

        public static string NewReference()
        {
            var stringBuilder = new StringBuilder();
            var random = new Random();
            for (int j = 1; j <= 6; j++)
            {
                var charCode = random.Next(65, 90);
                stringBuilder.Append((char)charCode);
            }
            stringBuilder.Append(string.Format("{0:000000}", random.Next(0, 999999)));
            return stringBuilder.ToString();
        }
        public async Task<string> StartSubscriptionAsync(SubscriptionViewModel startSubscriptionViewModel)
        {
            var subscription = new ApplicationDbContext.Models.Subscription()
            {
                FullName = startSubscriptionViewModel.FullName,
                Email = startSubscriptionViewModel.Email,
                PhoneNumber = startSubscriptionViewModel.PhoneNumber,
                MobileNumber = startSubscriptionViewModel.MobileNumber,
                BirthDate = startSubscriptionViewModel.BirthDate,
                Crmv = startSubscriptionViewModel.Crmv,
                Crmvstate = startSubscriptionViewModel.Crmvstate,
                OccupationAreaId = startSubscriptionViewModel.OccupationAreaId,
                ProfessionalSpecialtyId = startSubscriptionViewModel.ProfessionalSpecialtyId,
                GraduationYear = startSubscriptionViewModel.GraduationYear,
                CreatedDate = DateTime.Now
            };
            // TODO: obter uma referência e ver se ela existe, senão continuar tentando até dar certo.
            subscription.Reference = SubscriptionService.NewReference();

            await context.Subscription.AddAsync(subscription);
            await context.SaveChangesAsync();

            return subscription.Reference;
        }
        public async Task<int> GetSubscriptionIdByReferenceAsync(string reference)
        {
            return (await context.Subscription.SingleAsync(x => x.Reference == reference)).SubscriptionId;
        }
        public async Task<SubscriptionViewModel> GetSubscriptionAsync(int subscriptionId)
        {
            var subscription = await context.Subscription.SingleAsync(x => x.SubscriptionId == subscriptionId);

            return new SubscriptionViewModel()
            {
                SubscriptionId = subscription.SubscriptionId,
                Reference = subscription.Reference,
                FullName = subscription.FullName,
                Email = subscription.Email,
                PhoneNumber = subscription.PhoneNumber,
                MobileNumber = subscription.MobileNumber,
                BirthDate = subscription.BirthDate,
                Cpf = subscription.Cpf,
                Crmv = subscription.Crmv,
                Crmvstate = subscription.Crmvstate,
                OccupationAreaId = subscription.OccupationAreaId,
                OccupationArea = await GetOccupationAreaAsync(subscription.OccupationAreaId),
                ProfessionalSpecialtyId = subscription.ProfessionalSpecialtyId,
                ProfessionalSpecialty = await GetProfessionalSpecialtyAsync(subscription.ProfessionalSpecialtyId),
                GraduationYear = subscription.GraduationYear,
                IsStateAgreement = subscription.IsStateAgreement,
                PlanId = subscription.PlanId,
                PlanName = subscription.PlanName,
                PlanPriceTableId = subscription.PlanPriceTableId,
                MonthlyCost = subscription.MonthlyCost,
                MonthlyDiscount = subscription.MonthlyDiscount,
                MonthlyTotal = subscription.MonthlyTotal,
                ZipCode = subscription.ZipCode,
                Address = subscription.Address,
                AddressNumber = subscription.AddressNumber,
                AddressAdditionalInfo = subscription.AddressAdditionalInfo,
                Neighborhood = subscription.Neighborhood,
                City = subscription.City,
                State = subscription.State,
                HasCompany = subscription.HasCompany,
                CompanyName = subscription.CompanyName,
                Cnpj = subscription.Cnpj,
                IuguId = subscription.IuguId,
                BilledByCompany = subscription.BilledByCompany,
                HealthBlock = subscription.HealthBlock,
                HealthBlockDate = subscription.HealthBlockDate,
                HealthUnblockDate = subscription.HealthUnblockDate,
                HealthUnblockBy = subscription.HealthUnblockBy,
                PaymentMethodId = subscription.PaymentMethodId,
                PaymentDate = subscription.PaymentDate,
                HasCertificate = subscription.HasCertificate,
                CertificateDate = subscription.CertificateDate,
                EffectiveStartDate = subscription.EffectiveStartDate,
                EffectiveEndDate = subscription.EffectiveEndDate,
                AffiliateId = subscription.AffiliateId,
                Coupon = subscription.Coupon,
                CreatedDate = subscription.CreatedDate,
                AlteredDate = subscription.AlteredDate
            };

        }
        public async Task<SubscriptionViewModel> GetSubscriptionAsync(string reference)
        {
            var subscriptionId = await GetSubscriptionIdByReferenceAsync(reference);
            return await GetSubscriptionAsync(subscriptionId);
        }
        public async Task AddCertificateSentAsync(string reference, bool hasError, string message)
        {
            var subscription = await GetByReferenceAsync(reference);

            subscription.CertificateDate = DateTime.Now;
            subscription.CertificateSentError = hasError;
            subscription.CertificateSentErrorDetails = message;
            subscription.EffectiveStartDate = new DateTime(subscription.CertificateDate.Value.Year, subscription.CertificateDate.Value.Month, 1);
            subscription.EffectiveEndDate = subscription.EffectiveStartDate.Value.AddYears(1);
            subscription.AlteredDate = DateTime.Now;

            await context.SaveChangesAsync();
        }
        public async Task<bool> CertificateSentAsync(string reference)
        {
            var subscription = await GetByReferenceAsync(reference);

            return subscription.CertificateDate.HasValue && !subscription.CertificateSentError;
        }
        public async Task AddPersonalInfoAsync(string reference, SubscriptionViewModel subscriptionViewModel)
        {
            var subscription = await GetByReferenceAsync(reference);

            subscription.FullName = subscriptionViewModel.FullName;
            subscription.OccupationAreaId = subscriptionViewModel.OccupationAreaId;
            subscription.ProfessionalSpecialtyId = subscriptionViewModel.ProfessionalSpecialtyId;
            subscription.GraduationYear = subscriptionViewModel.GraduationYear;
            subscription.Cpf = subscriptionViewModel.CpfClean;
            subscription.PhoneNumber = subscriptionViewModel.PhoneNumber;
            subscription.MobileNumber = subscriptionViewModel.MobileNumber;
            subscription.Email = subscriptionViewModel.Email;
            subscription.ZipCode = subscriptionViewModel.ZipCodeClean;
            subscription.Address = subscriptionViewModel.Address;
            subscription.AddressNumber = subscriptionViewModel.AddressNumber;
            subscription.AddressAdditionalInfo = subscriptionViewModel.AddressAdditionalInfo;
            subscription.Neighborhood = subscriptionViewModel.Neighborhood;
            subscription.City = subscriptionViewModel.City;
            subscription.State = subscriptionViewModel.State;
            subscription.AlteredDate = DateTime.Now;

            await context.SaveChangesAsync();

        }
        public async Task AddPaymentInfoAsync(string reference, PaymentMethods paymentMethodId, PaymentGatewayProviders paymentGatewayProviderId, string accountCode, string planCode, string subscriptionCode)
        {
            var subscription = await GetByReferenceAsync(reference);

            subscription.PaymentDate = DateTime.Now;
            subscription.PaymentMethodId = (int)paymentMethodId;
            subscription.AlteredDate = DateTime.Now;

            context.SubscriptionPaymentGatewayProviderInfo.Add(new ApplicationDbContext.Models.SubscriptionPaymentGatewayProviderInfo()
            {
                PaymentGatewayProviderId = (int)paymentGatewayProviderId,
                SubscriptionId = subscription.SubscriptionId,
                AccountCode = accountCode,
                PlanCode = planCode,
                SubscriptionCode = subscriptionCode,
                CreatedDate = DateTime.Now
            });

            await context.SaveChangesAsync();
        }
        public async Task AddPaymentErrorAsync(string reference, string details)
        {
            var subscription = await GetByReferenceAsync(reference);

            subscription.PaymentHasError = true;
            subscription.PaymentErrorDetails = details;

            await context.SaveChangesAsync();
        }
        public async Task ClearPaymentErrorAsync(string reference)
        {
            var subscription = await GetByReferenceAsync(reference);

            subscription.PaymentHasError = false;
            subscription.PaymentErrorDetails = null;
            subscription.AlteredDate = DateTime.Now;

            await context.SaveChangesAsync();
        }
        public async Task FlagCertificateAsync(string reference)
        {
            var subscription = await GetByReferenceAsync(reference);

            subscription.HasCertificate = true;
            subscription.AlteredDate = DateTime.Now;

            await context.SaveChangesAsync();
        }
        public async Task ClearHealthQuestionnaireAsync(string reference, int healthQuestionnaireId)
        {
            var subscription = await GetSubscriptionAsync(reference);
            var healthQuestionnaireQuestionIds = await context.HealthQuestionnaireQuestion.Where(x => x.HealthQuestionnaireId == healthQuestionnaireId).Select(x => x.HealthQuestionnaireQuestionaId).ToListAsync();
            var responses = context.HealthQuestionnaireResponse.Where(x => healthQuestionnaireQuestionIds.Contains(x.HealthQuestionnaireQuestionId) && x.SubscriptionId == subscription.SubscriptionId);
            context.HealthQuestionnaireResponse.RemoveRange(responses);
        }
        public async Task ChoosePlanPriceTableAsync(string reference, int planPriceTableId)
        {
            var subscription = await GetByReferenceAsync(reference);

            subscription.PlanPriceTableId = planPriceTableId;
            subscription.AlteredDate = DateTime.Now;

            await context.SaveChangesAsync();
        }
        public async Task ChoosePlanAsync(string reference, int planId)
        {
            var subscription = await GetByReferenceAsync(reference);
            if (!subscription.PlanPriceTableId.HasValue) throw new Exception("Uma tabela de preço deve estar definida ao selecionar um plano");
            var plan = await planService.GetPlanInfoAsync(planId, subscription.PlanPriceTableId.Value);

            subscription.PlanId = planId;
            subscription.PlanName = plan.Name;
            subscription.MonthlyCost = plan.MonthlyCost;
            subscription.MonthlyTotal = subscription.MonthlyCost - (subscription.MonthlyDiscount ?? 0);
            subscription.AlteredDate = DateTime.Now;

            await context.SaveChangesAsync();
        }
        public async Task<bool> ReferenceExistsAsync(string reference)
        {
            if (string.IsNullOrWhiteSpace(reference)) return false;

            return await context.Subscription.AnyAsync(x => x.Reference == reference);
        }
        public async Task SaveHealthQuestionnaireAsync(string reference, int healthQuestionnaireId, List<QuestionResponseViewModel> responses)
        {
            var subscription = await GetByReferenceAsync(reference);
            foreach (var response in responses)
            {
                await context.HealthQuestionnaireResponse.AddAsync(new ApplicationDbContext.Models.HealthQuestionnaireResponse()
                {
                    HealthQuestionnaireQuestionId = response.HealthQuestionnaireQuestionId,
                    SubscriptionId = subscription.SubscriptionId,
                    Response = response.Response,
                    CreatedDate = DateTime.Now
                });
            }
            subscription.HealthQuestionnaireId = healthQuestionnaireId;
            subscription.AlteredDate = DateTime.Now;

            await context.SaveChangesAsync();
        }
        public async Task<Guid> BlockSubscriptionByHealthQuestionnaireAsync(string reference)
        {
            var token = Guid.NewGuid();
            var subscription = await GetByReferenceAsync(reference);
            subscription.HealthBlock = true;
            subscription.HealthBlockDate = DateTime.Now;
            subscription.HealthUnblockToken = token;
            subscription.AlteredDate = DateTime.Now;

            await context.SaveChangesAsync();

            return token;
        }
        public async Task HealthUnblockSubscriptionAsync(string reference)
        {
            var subscription = await GetByReferenceAsync(reference);

            subscription.HealthUnblockBy = -1;
            subscription.HealthUnblockDate = DateTime.Now;
            subscription.AlteredDate = DateTime.Now;

            await context.SaveChangesAsync();
        }
        public async Task<bool> ValidateHealthUnblockTokenAsync(string reference, Guid token)
        {
            var subscription = await GetByReferenceAsync(reference);

            return subscription.HealthUnblockToken == token;
        }
        public async Task<bool> IsBlockedByHealthQuestionnaireAsync(string reference)
        {
            var subscription = await GetByReferenceAsync(reference);
            if (subscription == null) return false;

            return subscription.HealthBlock && !subscription.HealthUnblockDate.HasValue;
        }
        public async Task<bool> HealthQuestionnaireIsUnblockedAsync(string reference)
        {
            var subscription = await GetByReferenceAsync(reference);
            if (subscription == null) return false;

            return subscription.HealthUnblockDate.HasValue;
        }
        public async Task<bool> HasHealthQuestionnaireNegativeReponseAsync(string reference)
        {
            var subscription = await GetByReferenceAsync(reference);

            return await context.HealthQuestionnaireResponse.AnyAsync(x => x.SubscriptionId == subscription.SubscriptionId && !x.Response.ToUpper().Equals("TRUE"));
        }
        public async Task<List<QuestionResponseViewModel>> GetHealthQuestionnaireQuestionResponseAsync(string reference, int healthQuestionnaireId)
        {
            var subscription = await GetByReferenceAsync(reference);

            var questionResponses = await (from hq in context.HealthQuestionnaire
                                           join hqq in context.HealthQuestionnaireQuestion on hq.HealthQuestionnaireId equals hqq.HealthQuestionnaireId
                                           join hqqr in context.HealthQuestionnaireResponse on hqq.HealthQuestionnaireQuestionaId equals hqqr.HealthQuestionnaireQuestionId
                                           where hqqr.SubscriptionId == subscription.SubscriptionId && hq.HealthQuestionnaireId == healthQuestionnaireId
                                           select new QuestionResponseViewModel()
                                           {
                                               HealthQuestionnaireQuestionId = hqq.HealthQuestionnaireQuestionaId,
                                               Response = hqqr.Response
                                           }).ToListAsync();

            return questionResponses;
        }
        public async Task<SubscriptionSteps> GetCertificateSubscriptionStepAsync(string reference)
        {
            var subscription = await GetByReferenceAsync(reference);

            if (subscription.HasCertificate) return SubscriptionSteps.Certificate;
            if (!subscription.HealthBlock && subscription.HealthQuestionnaireId.HasValue && subscription.PlanId.HasValue) return SubscriptionSteps.Payment;
            if (subscription.HealthUnblockDate.HasValue) return SubscriptionSteps.Payment;
            if (subscription.HealthBlock) return SubscriptionSteps.HealthQuestionnaireBlock;
            if (subscription.PlanId.HasValue) return SubscriptionSteps.HealthQuestionnaire;
            if (!subscription.PlanId.HasValue) return SubscriptionSteps.Plans;

            return SubscriptionSteps.None;
        }
        public async Task<string> GetProfessionalSpecialtyAsync(int? professionalSpecialtyId)
        {
            if (!professionalSpecialtyId.HasValue) return null;

            if (!memoryCache.TryGetValue("GetProfessionalSpecialtyAsync", out List<ApplicationDbContext.Models.ProfessionalSpecialty> professionalSpecialties))
            {
                professionalSpecialties = await context.ProfessionalSpecialty.ToListAsync();

                memoryCache.Set("GetProfessionalSpecialtyAsync", professionalSpecialties, TimeSpan.FromHours(1));
            }

            return professionalSpecialties.Single(x => x.ProfessionalSpecialtyId == professionalSpecialtyId).Name;
        }
        public async Task<string> GetOccupationAreaAsync(int? occupationAreaId)
        {
            if (!occupationAreaId.HasValue) return null;

            if (!memoryCache.TryGetValue("GetOccupationAreaAsync", out List<ApplicationDbContext.Models.OccupationArea> occupationAreas))
            {
                occupationAreas = await context.OccupationArea.ToListAsync();

                memoryCache.Set("GetOccupationAreaAsync", occupationAreas, TimeSpan.FromHours(1));
            }

            return occupationAreas.Single(x => x.OccupationAreaId == occupationAreaId).Name;
        }
        private async Task<ApplicationDbContext.Models.Subscription> GetByReferenceAsync(string reference)
        {
            return await context.Subscription.SingleOrDefaultAsync(x => x.Reference == reference);
        }
    }
}
