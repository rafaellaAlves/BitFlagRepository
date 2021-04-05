using AMaisImob_DB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AMaisImob_WEB.BLL
{
    public class UtilizacaoFunctions : BLL.Shared.BLLBasicListFunctions<Utilizacao, Utilizacao>
    {
        public UtilizacaoFunctions(AMaisImob_HomologContext context) : base(context,"UtilizacaoId")
        {
        }

        public override List<Utilizacao> GetDataViewModel(IEnumerable<Utilizacao> data)
        {
            return data.ToList();
        }

        public override Utilizacao GetDataViewModel(Utilizacao data)
        {
            return data;
        }

        protected override void SetDbSet()
        {
            this.dbSet = context.Utilizacao;
        }
    }
}
