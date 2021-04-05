using ApplicationDbContext.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Client
{
    public class ClientLicenseConditioningPeriodicityServices : Shared.BaseListServices<ClientLicenseConditioningPeriodicity, ClientLicenseConditioningPeriodicity, int>
    {
        public ClientLicenseConditioningPeriodicityServices(ApplicationDbContext.Context.ApplicationDbContext context, AspNetIdentityDbContext.ApplicationDbContext identityContext) : base(context, identityContext, "ClientLicenseConditioningPeriodicityId")
        {
        }
    }
}
