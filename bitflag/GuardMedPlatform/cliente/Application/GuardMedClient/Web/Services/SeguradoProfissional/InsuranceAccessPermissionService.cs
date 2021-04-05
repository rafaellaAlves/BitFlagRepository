using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VendasDbContext;
using VendasDbContext.Models;

namespace Web.Services.SeguradoProfissional
{
    public class InsuranceAccessPermissionService : Shared.BaseListServices<InsuranceAccessPermission, InsuranceAccessPermission, int>
    {
        public InsuranceAccessPermissionService(VendasContext context) : base(context, "InsuranceAccessPermissionId")
        {
        }

        /// <summary>
        /// Verifica se o acesso do segurado precisa ser liberado de qualquer forma.
        /// </summary>
        public async Task<bool> InsuranceHasAccess(int seguradoProfissionalId) => await this.dbSet.AnyAsync(x => x.SeguradoProfissionalId == seguradoProfissionalId && x.AccessUntil >= DateTime.Today);
    }
}
