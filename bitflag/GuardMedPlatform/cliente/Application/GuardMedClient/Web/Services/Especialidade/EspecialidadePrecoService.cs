using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VendasDbContext;
using VendasDbContext.Models;
using Web.DTO.Especialidade;

namespace Web.Services.Especialidade
{
    public class EspecialidadePrecoService : Shared.BaseListServices<EspecialidadePreco, EspecialidadePrecoViewModel, int>
    {
        public EspecialidadePrecoService(VendasContext context) : base(context, "EspecialidadePrecoId")
        {
        }
    }
}
