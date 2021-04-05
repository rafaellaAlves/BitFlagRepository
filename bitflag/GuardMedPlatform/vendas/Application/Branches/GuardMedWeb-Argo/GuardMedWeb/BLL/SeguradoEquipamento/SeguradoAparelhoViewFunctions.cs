using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DAL;
using BLL;

namespace GuardMedWeb.BLL.SeguradoEquipamento
{
    public class SeguradoAparelhoViewFunctions : BLLBasicFunctions<DAL.SeguradoAparelhoView, DAL.SeguradoAparelhoView>
    {
        public SeguradoAparelhoViewFunctions(GuardMedWebContext context) 
            : base(context, "Id")
        {
        }

        public override int Create(SeguradoAparelhoView model)
        {
            throw new NotImplementedException();
        }

        public override void Delete(object id)
        {
            throw new NotImplementedException();
        }

        public override List<SeguradoAparelhoView> GetDataViewModel(IQueryable<SeguradoAparelhoView> data)
        {
            return data.ToList();
        }

        public override SeguradoAparelhoView GetDataViewModel(SeguradoAparelhoView data)
        {
            return data;
        }

        public override void Update(SeguradoAparelhoView model)
        {
            throw new NotImplementedException();
        }

        protected override void SetDbSet()
        {
            this.dbSet = context.SeguradoAparelhoView;
        }
    }
}
