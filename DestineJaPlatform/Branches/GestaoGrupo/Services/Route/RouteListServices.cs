using ApplicationDbContext.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Route
{
    public class RouteListServices : Shared.BaseListServices<RouteList, RouteList, int>
    {
        public RouteListServices(ApplicationDbContext.Context.ApplicationDbContext context, AspNetIdentityDbContext.ApplicationDbContext identityContext) : base(context, identityContext, "RouteId")
        {
        }
    }
}
