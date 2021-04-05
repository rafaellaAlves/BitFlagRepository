using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GuardMedWeb.DAL;
using BLL;

namespace GuardMedWeb.BLL.SeguradoEquipamento
{
    public class PlanoSeguroEquipamentoFunctions : BLLBasicFunctions<DAL.PlanoSeguroEquipamento, DAL.PlanoSeguroEquipamento>
    {
        public PlanoSeguroEquipamentoFunctions(GuardMedWebContext context) 
            : base(context, "PlanoSeguroEquipamentoId")
        {
        }

        public override int Create(PlanoSeguroEquipamento model)
        {
            throw new NotImplementedException();
        }

        public override void Delete(object id)
        {
            throw new NotImplementedException();
        }

        public override List<PlanoSeguroEquipamento> GetDataViewModel(IQueryable<PlanoSeguroEquipamento> data)
        {
            return data.ToList();
        }

        public override PlanoSeguroEquipamento GetDataViewModel(PlanoSeguroEquipamento data)
        {
            return data;
        }

        public override void Update(PlanoSeguroEquipamento model)
        {
            throw new NotImplementedException();
        }

        protected override void SetDbSet()
        {
            this.dbSet = context.PlanoSeguroEquipamento;
        }
    }
}
