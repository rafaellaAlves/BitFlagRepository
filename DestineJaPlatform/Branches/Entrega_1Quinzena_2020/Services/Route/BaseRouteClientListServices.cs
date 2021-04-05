using ApplicationDbContext.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Route
{
    public class BaseRouteClientListServices : Shared.BaseListServices<BaseRouteClientList, BaseRouteClientList, int>
    {
        public BaseRouteClientListServices(ApplicationDbContext.Context.ApplicationDbContext context, AspNetIdentityDbContext.ApplicationDbContext identityContext) : base(context, identityContext, "ClientCollectionAddressId")
        {
        }
    }
}
