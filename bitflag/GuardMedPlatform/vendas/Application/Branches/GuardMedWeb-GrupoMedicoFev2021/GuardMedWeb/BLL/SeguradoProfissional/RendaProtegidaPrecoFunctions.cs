using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLL;
using GuardMedWeb.DAL;
using GuardMedWeb.Models;

namespace GuardMedWeb.BLL.SeguradoProfissional
{
    public class RendaProtegidaPrecoFunctions : BLLBasicFunctions<DAL.RendaProtegidaPreco, RendaProtegidaPrecoViewModel>
    {
        public RendaProtegidaPrecoFunctions(GuardMedWebContext context) 
            : base(context, "RendaProtegidaPrecoId")
        {
        }

        public override int Create(RendaProtegidaPrecoViewModel model)
        {
            throw new NotImplementedException();
        }

        public override void Delete(object id)
        {
            throw new NotImplementedException();
        }

        public override List<RendaProtegidaPrecoViewModel> GetDataViewModel(IQueryable<RendaProtegidaPreco> data)
        {
            return (from y in data
                    select new RendaProtegidaPrecoViewModel {
                        IdadeMax = y.IdadeMax,
                        IdadeMin = y.IdadeMin,
                        PrecoMensal = y.PrecoMensal.ToString("#,##0.00"),
                        RendaProtegidaPrecoId = y.RendaProtegidaPrecoId
                    }).ToList();
        }

        public override RendaProtegidaPrecoViewModel GetDataViewModel(RendaProtegidaPreco data)
        {
            return new RendaProtegidaPrecoViewModel
            {
                IdadeMax = data.IdadeMax,
                IdadeMin = data.IdadeMin,
                PrecoMensal = data.PrecoMensal.ToString("#,##0.00"),
                RendaProtegidaPrecoId = data.RendaProtegidaPrecoId
            };
        }

        public override void Update(RendaProtegidaPrecoViewModel model)
        {
            throw new NotImplementedException();
        }

        protected override void SetDbSet()
        {
            this.dbSet = context.RendaProtegidaPreco;
        }
    }
}
