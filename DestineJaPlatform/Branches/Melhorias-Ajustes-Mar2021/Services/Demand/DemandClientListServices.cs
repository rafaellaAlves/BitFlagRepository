using ApplicationDbContext.Models;
using DTO.Demand;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Demand
{
    public class DemandClientListServices : Shared.BaseListServices<DemandClientList, DemandClientListViewModel, int>
    {
        public DemandClientListServices(ApplicationDbContext.Context.ApplicationDbContext context, AspNetIdentityDbContext.ApplicationDbContext identityContext) : base(context, identityContext, "DemandClientId")
        {
        }
    }
}
