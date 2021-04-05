using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLL;
using DB.Models;

namespace WEB.BLL
{
    public class HistoricoComissaoFunctions : BLLBasicFunctions<DB.Models.HistoricoComissao, DB.Models.HistoricoComissao>
    {
        public HistoricoComissaoFunctions(Insurance_HomologContext context) : 
            base(context, "HistoricoComissaoId")
        {
        }

        public override int Create(HistoricoComissao model)
        {
            this.context.HistoricoComissao.Add(model);
            this.context.SaveChanges();

            return model.HistoricoComissaoId;
        }

        public override void Delete(object id)
        {
            throw new NotImplementedException();
        }

        public override List<HistoricoComissao> GetDataViewModel(IEnumerable<HistoricoComissao> data)
        {
            return data.ToList();
        }

        public override HistoricoComissao GetDataViewModel(HistoricoComissao data)
        {
            return data;
        }

        public override void Update(HistoricoComissao model)
        {
            throw new NotImplementedException();
        }

        protected override void SetDbSet()
        {
            this.dbSet = context.HistoricoComissao;
        }
    }
}
