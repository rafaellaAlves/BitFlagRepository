using ApplicationDbContext;
using ApplicationDbContext.Models;
using DTO.Demand;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Demand
{
    public class DemandListServices : Shared.BaseListServices<DemandList, DemandListViewModel, int>
    {
        public DemandListServices(ApplicationDbContext.Context.ApplicationDbContext context, AspNetIdentityDbContext.ApplicationDbContext identityContext) : base(context, identityContext, "DemandId")
        {
        }
    }
}
