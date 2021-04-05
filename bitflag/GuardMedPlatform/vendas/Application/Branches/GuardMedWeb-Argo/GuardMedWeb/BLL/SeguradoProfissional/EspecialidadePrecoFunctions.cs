using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLL;
using DAL;

namespace GuardMedWeb.BLL.SeguradoProfissional
{
    public class EspecialidadePrecoFunctions : BLLBasicFunctions<DAL.EspecialidadePreco, Models.EspecialidadePrecoViewModel>
    {
        public EspecialidadePrecoFunctions(GuardMedWebContext context)
            : base(context, "EspecialidadePrecoId")
        {
        }

        public override int Create(Models.EspecialidadePrecoViewModel model)
        {
            throw new NotImplementedException();
        }

        public override void Delete(object id)
        {
            throw new NotImplementedException();
        }
        public Models.EspecialidadePrecoViewModel Get(int planoSeguroProfissionalId, int grupo)
        {
            var item = dbSet.Single(x => x.PlanoSeguroProfissionalId == planoSeguroProfissionalId && x.Grupo == grupo);
            
            return GetDataViewModel(item);
        }
        public override List<Models.EspecialidadePrecoViewModel> GetDataViewModel(IQueryable<EspecialidadePreco> data)
        {
            return (from y in data
                    select new Models.EspecialidadePrecoViewModel
                    {
                        Gropo = y.Grupo,
                        EspecialidadePrecoId = y.EspecialidadePrecoId,
                        PlanoSeguroProfissionalId = y.PlanoSeguroProfissionalId,
                        PrecoAnual = y.PrecoAnual,
                        PrecoMensal = y.PrecoMensal,
                        PrecoAdmAnual = y.PrecoAdmAnual,
                        PrecoAdmMensal = y.PrecoAdmMensal,
                        CodIUGU = y.CodIugu,
                        
                    }).ToList();
        }

        public List<Models.EspecialidadePrecoViewModel> GetDataViewModel(List<EspecialidadePreco> data)
        {
            return (from y in data
                    select new Models.EspecialidadePrecoViewModel
                    {
                        Gropo = y.Grupo,
                        EspecialidadePrecoId = y.EspecialidadePrecoId,
                        PlanoSeguroProfissionalId = y.PlanoSeguroProfissionalId,
                        PrecoAnual = y.PrecoAnual,
                        PrecoMensal = y.PrecoMensal,
                        PrecoAdmAnual = y.PrecoAdmAnual,
                        PrecoAdmMensal = y.PrecoAdmMensal,
                        CodIUGU = y.CodIugu
                    }).ToList();
        }

        public override Models.EspecialidadePrecoViewModel GetDataViewModel(EspecialidadePreco data)
        {
            return new Models.EspecialidadePrecoViewModel
            {
                Gropo = data.Grupo,
                EspecialidadePrecoId = data.EspecialidadePrecoId,
                PlanoSeguroProfissionalId = data.PlanoSeguroProfissionalId,
                PrecoAnual = data.PrecoAnual,
                PrecoMensal = data.PrecoMensal,
                PrecoAdmAnual = data.PrecoAdmAnual,
                PrecoAdmMensal = data.PrecoAdmMensal,
                CodIUGU = data.CodIugu
            };
        }

        public override void Update(Models.EspecialidadePrecoViewModel model)
        {
            throw new NotImplementedException();
        }

        protected override void SetDbSet()
        {
            this.dbSet = context.EspecialidadePreco;
        }
    }
}
