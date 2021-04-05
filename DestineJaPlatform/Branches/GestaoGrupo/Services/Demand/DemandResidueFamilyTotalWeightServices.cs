using ApplicationDbContext.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Demand
{
    public class DemandResidueFamilyTotalWeightServices : Shared.BaseListServices<DemandResidueFamilyTotalWeight, DemandResidueFamilyTotalWeight, int>
    {
        public DemandResidueFamilyTotalWeightServices(ApplicationDbContext.Context.ApplicationDbContext context, AspNetIdentityDbContext.ApplicationDbContext identityContext) : base(context, identityContext, "DemandId")
        {
        }
    }
}
