using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VendasDbContext;
using VendasDbContext.Models;

namespace Web.Services.Pagamento
{
    public class PagamentoTipoService : Shared.BaseListServices<PagamentoTipo, PagamentoTipo, int>
    {
        public PagamentoTipoService(VendasContext context) : base(context, "PagamentoTipoId")
        {
        }

        public async Task<PagamentoTipo> GetDataByExternalCode(string externalCode) => await this.dbSet.FirstOrDefaultAsync(x => x.ExternalCode == externalCode);
    }
}
