using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLL;
using DAL;

namespace GuardMedWeb.BLL.SeguradoProfissional
{
    public class EspecialidadeFunctions : BLLBasicFunctions<DAL.Especialidade, DAL.Especialidade>
    {
        public EspecialidadeFunctions(GuardMedWebContext context)
            : base(context, "EspecialidadeId")
        {
        }

        public int GetMaxGroup(int seguradoProfissinalId)
        {
            var seguradoProfissional = context.SeguradoProfissional.Find(seguradoProfissinalId);

            var especialidadesId = new List<int>();
            if (seguradoProfissional.Especialidade1.HasValue) especialidadesId.Add(seguradoProfissional.Especialidade1.Value);
            if (seguradoProfissional.Especialidade2.HasValue) especialidadesId.Add(seguradoProfissional.Especialidade2.Value);
            if (seguradoProfissional.Especialidade3.HasValue) especialidadesId.Add(seguradoProfissional.Especialidade3.Value);

            return dbSet.Where(x => especialidadesId.Contains(x.EspecialidadeId)).Select(x => x.Grupo).Max();
        }
        public override int Create(Especialidade model)
        {
            throw new NotImplementedException();
        }

        public override void Delete(object id)
        {
            throw new NotImplementedException();
        }

        public override List<Especialidade> GetDataViewModel(IQueryable<Especialidade> data)
        {
            return data.ToList();
        }

        public override Especialidade GetDataViewModel(Especialidade data)
        {
            return data;
        }

        public int GetGroup(int? especialidadeId)
        {
            var group = this.context.Especialidade.SingleOrDefault(x => x.EspecialidadeId == especialidadeId);

            return group.Grupo;
        }

        public override void Update(Especialidade model)
        {
            throw new NotImplementedException();
        }

        protected override void SetDbSet()
        {
            this.dbSet = context.Especialidade;
        }
    }
}
