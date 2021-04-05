using AMaisImob_DB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AMaisImob_WEB.BLL
{
    public class RegimeTributarioFunctions : BLL.Shared.BLLBasicListFunctions<RegimeTributario, RegimeTributario>
    {
        public RegimeTributarioFunctions(AMaisImob_HomologContext context) : base(context, "RegimeTributarioId")
        {
        }

        public override List<RegimeTributario> GetDataViewModel(IEnumerable<RegimeTributario> data)
        {
            return data.ToList();
        }

        public override RegimeTributario GetDataViewModel(RegimeTributario data)
        {
            return data;
        }

        protected override void SetDbSet()
        {
            this.dbSet = context.RegimeTributario;
        }
    }
}
