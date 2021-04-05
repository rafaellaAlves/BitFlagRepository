using ApplicationDbContext.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Services.Route
{
    public class RouteTypeServices : Shared.BaseListServices<RouteType, RouteType, int>
    {
        public RouteTypeServices(ApplicationDbContext.Context.ApplicationDbContext context, AspNetIdentityDbContext.ApplicationDbContext identityContext) : base(context, identityContext, "RouteTypeId")
        {
        }

        public async Task<RouteType> GetDataByExternalCode(string externalCode) => await this.dbSet.SingleOrDefaultAsync(x => x.ExternalCode == externalCode);
    }
}