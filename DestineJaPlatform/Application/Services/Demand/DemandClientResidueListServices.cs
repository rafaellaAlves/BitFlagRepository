using ApplicationDbContext.Models;
using DTO.Demand;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Demand
{
    public class DemandClientResidueListServices : Shared.BaseServices<DemandClientResidueList, DemandClientResidueListViewModel, int>
    {
        public DemandClientResidueListServices(ApplicationDbContext.Context.ApplicationDbContext context, AspNetIdentityDbContext.ApplicationDbContext identityContext) : base(context, identityContext, "DemandClientResidueId")
        {
        }
    }
}
