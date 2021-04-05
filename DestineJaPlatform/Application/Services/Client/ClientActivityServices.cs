using ApplicationDbContext.Models;
using Microsoft.EntityFrameworkCore;
using Services.Shared;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Services.Client
{
    public class ClientActivityServices : BaseListServices<ClientActivity, ClientActivity, int>
    {
        public ClientActivityServices(ApplicationDbContext.Context.ApplicationDbContext context, AspNetIdentityDbContext.ApplicationDbContext identityContext) : base(context, identityContext, "ClientActivityId")
        {
        }

        public async Task<ClientActivity> GetDataByExternalCode(string externalCode) => await this.dbSet.FirstOrDefaultAsync(x => x.ExternalCode == externalCode);
    }
}
