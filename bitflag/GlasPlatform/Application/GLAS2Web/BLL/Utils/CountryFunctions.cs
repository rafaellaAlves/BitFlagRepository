using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BLL.Utils
{
    public class CountryFunctions : BLLBasicListFunctions<DAL.Country>
    {
        public CountryFunctions(DAL.GLAS2Context context)
            : base(context, "CountryId")
        {
        }

        protected override void SetDbSet()
        {
            this.dbSet = context.Country;
        }
    }
}
