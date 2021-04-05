using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BLL.Utils
{
    public class StateFunctions : BLLBasicListFunctions<DAL.State>
    {
        public StateFunctions(DAL.GLAS2Context context)
            : base(context, "StateId")
        {
        }

        protected override void SetDbSet()
        {
            this.dbSet = context.State;
        }
    }
}
