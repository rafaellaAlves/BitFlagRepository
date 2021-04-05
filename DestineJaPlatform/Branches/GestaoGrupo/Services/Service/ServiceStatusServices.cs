using ApplicationDbContext.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Service
{
    public class ServiceStatusServices : Shared.BaseListServices<ServiceStatus, ServiceStatus, int>
    {
        public ServiceStatusServices(ApplicationDbContext.Context.ApplicationDbContext context, AspNetIdentityDbContext.ApplicationDbContext identityContext) : base(context, identityContext, "ServiceStatusId")
        {
        }

        public async Task<ServiceStatus> GetDataByExternalCode(string externalCode)
        {
            return (await GetDataAsNoTrackingAsync(x => x.ExternalCode == externalCode)).FirstOrDefault();
        }
    }
}
