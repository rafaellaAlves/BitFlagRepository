using ApplicationDbContext.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Route
{
    public class RoutePeriodicityServices : Shared.BaseListServices<RoutePeriodicity, RoutePeriodicity, int>
    {
        public RoutePeriodicityServices(ApplicationDbContext.Context.ApplicationDbContext context, AspNetIdentityDbContext.ApplicationDbContext identityContext) : base(context, identityContext, "RoutePeriodicityId")
        {
        }
    }
}
