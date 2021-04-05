using ApplicationDbContext.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Services.Service
{
    public class ServiceSituationServices : Shared.BaseListServices<ServiceSituation, ServiceSituation, int>
    {
        public ServiceSituationServices(ApplicationDbContext.Context.ApplicationDbContext context, AspNetIdentityDbContext.ApplicationDbContext identityContext) : base(context, identityContext, "ServiceSituationId")
        {
        }

        public async Task<ServiceSituation> GetDataByExternalCode(string externalCode) => await Task.Run(async () => await this.dbSet.SingleOrDefaultAsync(x => x.ExternalCode == externalCode));
    }
}
