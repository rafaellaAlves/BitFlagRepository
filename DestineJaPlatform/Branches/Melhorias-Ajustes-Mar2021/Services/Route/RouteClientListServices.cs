using ApplicationDbContext.Models;
using DTO.Route;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Route
{
    public class RouteClientListServices : Shared.BaseListServices<RouteClientList, RouteClientListViewModel, int>
    {
        public RouteClientListServices(ApplicationDbContext.Context.ApplicationDbContext context, AspNetIdentityDbContext.ApplicationDbContext identityContext) : base(context, identityContext, "RouteClientId")
        {
        }
    }
}
