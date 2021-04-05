using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GuardMedWeb.DAL;
using BLL;
namespace GuardMedWeb.BLL.SeguradoProfissional
{
    public class SeguradoProfissionalExtracaoViewFunctions : BLLBasicFunctions<DAL.SeguradoProfissionalExtracaoView, DAL.SeguradoProfissionalExtracaoView>
    {
        public SeguradoProfissionalExtracaoViewFunctions(GuardMedWebContext context)
            : base(context, "SeguradoProfissionalId")
        {
        }

        public override int Create(SeguradoProfissionalExtracaoView model)
        {
            throw new NotImplementedException();
        }

        public override void Delete(object id)
        {
            throw new NotImplementedException();
        }

        public override List<SeguradoProfissionalExtracaoView> GetDataViewModel(IQueryable<SeguradoProfissionalExtracaoView> data)
        {
            return data.ToList();
        }

        public override SeguradoProfissionalExtracaoView GetDataViewModel(SeguradoProfissionalExtracaoView data)
        {
            return data;
        }

        public override void Update(SeguradoProfissionalExtracaoView model)
        {
            throw new NotImplementedException();
        }

        protected override void SetDbSet()
        {
            this.dbSet = context.SeguradoProfissionalExtracaoView;
        }
    }
    
}
