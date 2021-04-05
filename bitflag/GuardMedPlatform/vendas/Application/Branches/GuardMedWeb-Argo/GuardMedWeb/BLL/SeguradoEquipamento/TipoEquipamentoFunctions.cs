using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DAL;
using BLL;

namespace GuardMedWeb.BLL.SeguradoEquipamento
{
    public class TipoEquipamentoFunctions : BLLBasicFunctions<DAL.TipoEquipamento, DAL.TipoEquipamento>
    {
        public TipoEquipamentoFunctions(GuardMedWebContext context) 
            : base(context, "TipoEquipamentoId")
        {
        }

        public override int Create(TipoEquipamento model)
        {
            throw new NotImplementedException();
        }

        public override void Delete(object id)
        {
            throw new NotImplementedException();
        }

        public override List<TipoEquipamento> GetDataViewModel(IQueryable<TipoEquipamento> data)
        {
            return data.ToList();
        }

        public override TipoEquipamento GetDataViewModel(TipoEquipamento data)
        {
            return data;
        }

        public override void Update(TipoEquipamento model)
        {
            throw new NotImplementedException();
        }

        protected override void SetDbSet()
        {
            this.dbSet = context.TipoEquipamento;
        }
    }
}
