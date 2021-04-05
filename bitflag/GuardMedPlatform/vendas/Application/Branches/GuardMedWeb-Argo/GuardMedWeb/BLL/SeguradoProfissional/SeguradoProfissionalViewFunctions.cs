using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DAL;
using BLL;

namespace GuardMedWeb.BLL.SeguradoProfissional
{
    public class SeguradoProfissionalViewFunctions : BLLBasicFunctions<DAL.SeguradoProfissionalView, DAL.SeguradoProfissionalView>
    {
        public SeguradoProfissionalViewFunctions(GuardMedWebContext context) 
            : base(context, "SeguradoProfissionalId")
        {
        }

        public override int Create(SeguradoProfissionalView model)
        {
            throw new NotImplementedException();
        }

        public override void Delete(object id)
        {
            throw new NotImplementedException();
        }

        public override List<SeguradoProfissionalView> GetDataViewModel(IQueryable<SeguradoProfissionalView> data)
        {
            return data.ToList();
        }

        public override SeguradoProfissionalView GetDataViewModel(SeguradoProfissionalView data)
        {
            return data;
        }

        public override void Update(SeguradoProfissionalView model)
        {
            throw new NotImplementedException();
        }

        protected override void SetDbSet()
        {
            this.dbSet = context.SeguradoProfissionalView;
        }
    }
}
