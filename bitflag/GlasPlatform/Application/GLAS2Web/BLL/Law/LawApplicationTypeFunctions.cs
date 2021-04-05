using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DAL;
using DTO.Law;

namespace BLL.Law
{
    public class LawApplicationTypeFunctions : BLLBasicListFunctions<DAL.LawApplicationType>
    {

        public LawApplicationTypeFunctions(DAL.GLAS2Context context)
            : base(context, "LawApplicationTypeId")
        {
        }

        protected override void SetDbSet()
        {
            this.dbSet = context.LawApplicationType;
        }
    }
}
