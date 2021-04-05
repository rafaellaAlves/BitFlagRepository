using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BLL.Utils
{
    public class RegionFunctions : BLLBasicListFunctions<DAL.Region>
    {
        public RegionFunctions(DAL.GLAS2Context context)
            : base(context, "RegionId")
        {
        }

        protected override void SetDbSet()
        {
            this.dbSet = context.Region;
        }
    }
}
