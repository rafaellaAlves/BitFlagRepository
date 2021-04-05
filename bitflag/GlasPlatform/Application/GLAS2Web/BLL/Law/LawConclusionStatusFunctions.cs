using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DAL;
using DTO.Law;

namespace BLL.Law
{
    public class LawConclusionStatusFunctions : BLLBasicListFunctions<DAL.LawConclusionStatus>
    {

        public LawConclusionStatusFunctions(DAL.GLAS2Context context)
            : base(context, "LawConclusionStatusId")
        {
        }

        protected override void SetDbSet()
        {
            this.dbSet = context.LawConclusionStatus;
        }
    }
}
