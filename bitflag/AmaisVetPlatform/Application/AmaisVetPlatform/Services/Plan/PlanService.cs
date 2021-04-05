using DTO.Plan;
using DTO.PlanCoverage;
using DTO.Subscription;
using Microsoft.EntityFrameworkCore;
using Services.PlanCoverageType;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Plan
{
    public class PlanService
    {
        private readonly ApplicationDbContext.Context.ApplicationDbContext context;
        private readonly PlanCoverageTypeService planCoverageTypeService;
        public PlanService(ApplicationDbContext.Context.ApplicationDbContext context, PlanCoverageTypeService planCoverageTypeService)
        {
            this.context = context;
            this.planCoverageTypeService = planCoverageTypeService;
        }
        public async Task<PlanInfoViewModel> GetPlanInfoAsync(int planId, int planPriceTableId)
        {
            var plan = await context.Plan.SingleAsync(x => x.PlanId == planId);
            var planInfoViewModel = new PlanInfoViewModel()
            {
                PlanId = plan.PlanId,
                Name = plan.Name,
                Description = plan.Description,
                PaymentGatewayExternalCode = await GetPlainPaymentGatewayExternalCodeAsync(plan.PlanId, planPriceTableId),
                MonthlyCost = await GetPlainMonthlyCostAsync(plan.PlanId, planPriceTableId)
            };

            foreach (var planCoverageTypeViewModel in await planCoverageTypeService.GetActivePlanCoverageTypesAsync())
            {
                if (!planInfoViewModel.Coverages.ContainsKey(planCoverageTypeViewModel.PlanCoverageTypeId))
                {
                    var planCoverage = await context.PlanCoverage.SingleOrDefaultAsync(x => x.PlanId == plan.PlanId && x.PlanCoverageTypeId == planCoverageTypeViewModel.PlanCoverageTypeId);
                    planInfoViewModel.Coverages.Add(planCoverageTypeViewModel.PlanCoverageTypeId, new PlanCoverageViewModel()
                    {
                        planCoverageTypeViewModel = planCoverageTypeViewModel,
                        Description = planCoverage?.Description
                    });
                }
            }

            return planInfoViewModel;
        }
        public async Task<double> GetPlainMonthlyCostAsync(int planId, int planPriceTableId)
        {
            var planPriceTableEntry = await context.PlanPriceTableEntry.SingleAsync(x => x.PlanId == planId && x.PlanPriceTableId == planPriceTableId);

            return planPriceTableEntry.MonthlyCost;
        }
        public async Task<string> GetPlainPaymentGatewayExternalCodeAsync(int planId, int planPriceTableId)
        {
            var planPriceTableEntry = await context.PlanPriceTableEntry.SingleAsync(x => x.PlanId == planId && x.PlanPriceTableId == planPriceTableId);

            return planPriceTableEntry.PaymentGatewayExternalCode;
        }
        public async Task<List<PlanInfoViewModel>> GetActivePlansInfoAsync(int planPriceTableId)
        {
            var planInfoViewModels = new List<PlanInfoViewModel>();
            foreach (var planId in await context.Plan.Where(x => x.IsActive).Select(x => x.PlanId).ToListAsync())
                planInfoViewModels.Add(await GetPlanInfoAsync(planId, planPriceTableId));

            return planInfoViewModels;
        }
        public async Task<int> GetPlanPriceTable(SubscriptionViewModel subscriptionViewModel)
        {
            #region [Regra Específica do Negócio]
            var externalCode = "FEV21";

            if (subscriptionViewModel.Age < 20) externalCode += "-20-29";
            else if (subscriptionViewModel.Age >= 20 && subscriptionViewModel.Age <= 29) externalCode += "-20-29";
            else if (subscriptionViewModel.Age >= 30 && subscriptionViewModel.Age <= 39) externalCode += "-30-39";
            else if (subscriptionViewModel.Age >= 40 && subscriptionViewModel.Age <= 49) externalCode += "-40-49";
            else if (subscriptionViewModel.Age > 50) externalCode += "-50-59";

            if ((new List<string>() { "SP", "PR", "GO", "SE" }).Any(x => x.ToUpper().Equals(subscriptionViewModel.Crmvstate.ToUpper())))
                externalCode += "-C";
            else
                externalCode += "-N";
            #endregion

            var planPriceTable = await context.PlanPriceTable.SingleAsync(x => x.ExternalCode.Equals(externalCode));

            return planPriceTable.PlanPriceTableId;
        }
    }
}
