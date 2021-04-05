using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VendasDbContext;
using VendasDbContext.Models;
using Web.DTO.Plano;

namespace Web.Services.Plano
{
    public class PlanoSeguroProfissionalService : Shared.BaseListServices<VendasDbContext.Models.PlanoSeguroProfissional, PlanoSeguroProfissionalViewModel, int>
    {
        public PlanoSeguroProfissionalService(VendasContext context) : base(context, "PlanoSeguroProfissionalId")
        {
        }
    }
}
