using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLL;
using DAL;
using GuardMedWeb.Models;

namespace GuardMedWeb.BLL.SeguradoProfissional
{
    public class EspecialidadeProfissionalFunctions : BLLBasicFunctions<DAL.EspecialidadeProfissional, Models.EspecialidadeProfissionalViewModel>
    {
        public EspecialidadeProfissionalFunctions(GuardMedWebContext context) 
            : base(context, "EspecialidadeProfissionalId")
        {
        }

        public override int Create(EspecialidadeProfissionalViewModel model)
        {
            var especialidadeProfissional = new EspecialidadeProfissional {
                EspecialidadeId = model.EspecialidadeId.Value,
                Invasivo = model.Invasivo.Value,
                SeguradoProfissionalId = model.SeguradoProfissionalId
            };

            this.dbSet.Add(especialidadeProfissional);
            this.context.SaveChanges();

            return especialidadeProfissional.EspecialidadeProfissionalId;
        }

        public override void Delete(object id)
        {
            var especialidadeProfissional = GetDataByID(id);

            this.dbSet.Remove(especialidadeProfissional);
            context.SaveChanges();
        }

        public void DeleteBySegurado(int seguradoProfissionalId)
        {
            var especialidadesProfissional = GetData().Where(x => x.SeguradoProfissionalId == seguradoProfissionalId).ToList();
            foreach(var especialidadeProfissional in especialidadesProfissional)
                this.dbSet.Remove(especialidadeProfissional);

            context.SaveChanges();
        }

        public override List<EspecialidadeProfissionalViewModel> GetDataViewModel(IQueryable<EspecialidadeProfissional> data)
        {
            return (from y in data
                    join e in context.Especialidade on y.EspecialidadeId equals e.EspecialidadeId
                    select new EspecialidadeProfissionalViewModel {
                        EspecialidadeId = y.EspecialidadeId,
                        NomeEspecialidade = e.Nome,
                        EspecialidadeProfissionalId = y.EspecialidadeProfissionalId,
                        Invasivo = y.Invasivo,
                        SeguradoProfissionalId = y.SeguradoProfissionalId
                    }).ToList();
        }

        public override EspecialidadeProfissionalViewModel GetDataViewModel(EspecialidadeProfissional data)
        {
            return new EspecialidadeProfissionalViewModel
            {
                EspecialidadeId = data.EspecialidadeId,
                EspecialidadeProfissionalId = data.EspecialidadeProfissionalId,
                Invasivo = data.Invasivo,
                SeguradoProfissionalId = data.SeguradoProfissionalId
            };
        }

        public override void Update(EspecialidadeProfissionalViewModel model)
        {
            throw new NotImplementedException();
        }

        protected override void SetDbSet()
        {
            this.dbSet = context.EspecialidadeProfissional;
        }
    }
}
