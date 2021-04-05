using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BLL.Utils
{
    public class CityFunctions : BLLBasicListFunctions<DAL.City>
    {
        public CityFunctions(DAL.GLAS2Context context)
            : base(context, "CityId")
        {
        }

        protected override void SetDbSet()
        {
            this.dbSet = context.City;
        }
    }
}
