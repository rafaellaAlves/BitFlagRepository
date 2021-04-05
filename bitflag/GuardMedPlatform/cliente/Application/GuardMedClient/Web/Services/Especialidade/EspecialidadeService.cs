using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VendasDbContext;
using VendasDbContext.Models;
using Web.DTO;

namespace Web.Services.Especialidade
{
    public class EspecialidadeService : Shared.BaseListServices<VendasDbContext.Models.Especialidade, EspecialidadeViewModel, int>
    {
        public EspecialidadeService(VendasContext context) : base(context, "EspecialidadeId")
        {
        }
    }
}
