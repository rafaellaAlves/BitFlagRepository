using ApplicationDbContext.Models;
using DTO.Client;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Services.Client
{
    public class ClientLicenseConditioningService : Shared.BaseServices<ClientLicenseConditioning, ClientLicenseConditioningViewModel, int>
    {
        public ClientLicenseConditioningService(ApplicationDbContext.Context.ApplicationDbContext context, AspNetIdentityDbContext.ApplicationDbContext identityContext) : base(context, identityContext, "ClientLicenseConditioningId")
        {
        }

        public async Task<bool> CheckDate(DateTime date, int periodicityId, int daysToRegularize, int daysToNotify)
        {
            var periodicity = await this.context.ClientLicenseConditioningPeriodicity.SingleAsync(x => x.ClientLicenseConditioningPeriodicityId == periodicityId);

            if (periodicity.Days.HasValue)
                date = date.AddDays(periodicity.Days.Value);

            if (periodicity.Months.HasValue)
                date = date.AddMonths(periodicity.Months.Value);

            date = date.AddDays(daysToRegularize);
            date = date.AddDays(-daysToNotify);

            return date > DateTime.Today;
        }
    }
}
