using ApplicationDbContext.Models;
using DTO.Service;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Services.Service
{
    public class ServiceHistoricServices : Shared.BaseListServices<ServiceHistoric, ServiceHistoricViewModel, int>
    {
        public ServiceHistoricServices(ApplicationDbContext.Context.ApplicationDbContext context, AspNetIdentityDbContext.ApplicationDbContext identityContext) : base(context, identityContext, "ServiceId")
        {
        }

        public async Task<List<ServiceHistoric>> GetDataByClientIdAsync(int clientId) => await GetDataAsNoTrackingAsync(x => x.ClientId == clientId);
    }
}
