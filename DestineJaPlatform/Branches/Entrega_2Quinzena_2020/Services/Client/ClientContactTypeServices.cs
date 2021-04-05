using ApplicationDbContext.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Client
{
    public class ClientContactTypeServices : Shared.BaseServices<ClientContactType, ClientContactType, int>
    {
        public ClientContactTypeServices(ApplicationDbContext.Context.ApplicationDbContext context, AspNetIdentityDbContext.ApplicationDbContext identityContext) : base(context, identityContext, "ClientContactTypeId")
        {
        }

        public async Task<ClientContactType> GetDataByExternalCodeAsync(string externalCode) => await this.dbSet.SingleOrDefaultAsync(x => x.ExternalCode == externalCode);
        public ClientContactType GetDataByExternalCode(string externalCode) => this.dbSet.SingleOrDefault(x => x.ExternalCode == externalCode);
    }
}
