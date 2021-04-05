using DTO.PlanCoverageType;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.PlanCoverageType
{

    public class PlanCoverageTypeService
    {
        private readonly ApplicationDbContext.Context.ApplicationDbContext context;

        public PlanCoverageTypeService(ApplicationDbContext.Context.ApplicationDbContext context)
        {
            this.context = context;
        }
        public async Task<List<PlanCoverageTypeViewModel>> GetActivePlanCoverageTypesAsync()
        {
            return await context.PlanCoverageType.Where(x => x.IsActive).Select(x => new PlanCoverageTypeViewModel()
            {
                PlanCoverageTypeId = x.PlanCoverageTypeId,
                Description = x.Description
            }).ToListAsync();
        }
        public async Task<PlanCoverageTypeViewModel> GetPlanCoverageTypeByIdAsync(int planCoverageTypeId)
        {
            var planCoverageTypeViewModel = await context.PlanCoverageType.SingleAsync(x => x.PlanCoverageTypeId == planCoverageTypeId);

            return new PlanCoverageTypeViewModel()
            {
                PlanCoverageTypeId = planCoverageTypeViewModel.PlanCoverageTypeId,
                Description = planCoverageTypeViewModel.Description
            };
        }
    }
}
