using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DAL;
using DTO.Law;

namespace BLL.Company
{
    public class CompanyViewFunctions : BLLBasicListFunctions<DAL.CompanyView>
    {

        public CompanyViewFunctions(DAL.GLAS2Context context)
            : base(context, "CompanyId")
        {
        }

        protected override void SetDbSet()
        {
            this.dbSet = context.CompanyView;
        }
    }
}
