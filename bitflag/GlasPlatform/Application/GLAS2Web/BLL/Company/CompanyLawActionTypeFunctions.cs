using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DAL;
using DTO.Law;

namespace BLL.Company
{
    public class CompanyLawActionTypeFunctions : BLLBasicListFunctions<DAL.CompanyLawActionType>
    {

        public CompanyLawActionTypeFunctions(DAL.GLAS2Context context)
            : base(context, "CompanyLawActionTypeId")
        {
        }

        protected override void SetDbSet()
        {
            this.dbSet = context.CompanyLawActionType;
        }
    }
}
