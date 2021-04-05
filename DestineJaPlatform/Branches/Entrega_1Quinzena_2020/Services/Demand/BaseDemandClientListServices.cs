using ApplicationDbContext.Models;
using DTO.Demand;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Demand
{
    public class BaseDemandClientListServices : Shared.BaseListServices<BaseDemandClientList, BaseDemandClientListViewModel, int>
    {
        public BaseDemandClientListServices(ApplicationDbContext.Context.ApplicationDbContext context, AspNetIdentityDbContext.ApplicationDbContext identityContext) : base(context, identityContext, "ClientCollectionAddressId")
        {
        }
    }
}
