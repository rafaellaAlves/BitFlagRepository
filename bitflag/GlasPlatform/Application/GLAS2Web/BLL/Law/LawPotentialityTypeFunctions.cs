using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Law
{
    public class LawPotentialityTypeFunctions : BLLBasicListFunctions<DAL.LawPotentialityType>
    {
        public LawPotentialityTypeFunctions(DAL.GLAS2Context context)
            : base(context, "LawPotentialityTypeId")
        {
        }

        protected override void SetDbSet()
        {
            this.dbSet = context.LawPotentialityType;
        }
    }
}
