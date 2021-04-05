using ApplicationDbContext.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Demand
{
    public class DemandWeightServices : Shared.BaseListServices<DemandWeight, DemandWeight, int>
    {
        public DemandWeightServices(ApplicationDbContext.Context.ApplicationDbContext context, AspNetIdentityDbContext.ApplicationDbContext identityContext) : base(context, identityContext, "DemandId")
        {
        }
    }
}
