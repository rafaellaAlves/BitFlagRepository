using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DAL;
using BLL;

namespace GuardMedWeb.BLL.Pagamento
{
    public class PagamentoTipoFunctions : BLLBasicFunctions<DAL.PagamentoTipo, DAL.PagamentoTipo>
    {
        public PagamentoTipoFunctions(GuardMedWebContext context) 
            : base(context, "PagamentoTipoId")
        {
        }

        public override int Create(PagamentoTipo model)
        {
            throw new NotImplementedException();
        }

        public override void Delete(object id)
        {
            throw new NotImplementedException();
        }

        public override List<PagamentoTipo> GetDataViewModel(IQueryable<PagamentoTipo> data)
        {
            return data.ToList();
        }

        public override PagamentoTipo GetDataViewModel(PagamentoTipo data)
        {
            return data;
        }

        public override void Update(PagamentoTipo model)
        {
            throw new NotImplementedException();
        }

        protected override void SetDbSet()
        {
            this.dbSet = context.PagamentoTipo;
        }
    }
}
