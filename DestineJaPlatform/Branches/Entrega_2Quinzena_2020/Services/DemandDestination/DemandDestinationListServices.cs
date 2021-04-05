using ApplicationDbContext.Models;
using DTO.DemandDestination;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.DemandDestination
{
    public class DemandDestinationListServices : Shared.BaseListServices<DemandDestinationList, DemandDestinationListViewModel, int>
    {
        public DemandDestinationListServices(ApplicationDbContext.Context.ApplicationDbContext context, AspNetIdentityDbContext.ApplicationDbContext identityContext) : base(context, identityContext, "DemandDestinationId")
        {
        }
    }
}
