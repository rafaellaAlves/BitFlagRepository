using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DAL;
using DTO.Law;

namespace BLL.Company
{
    public class CompanyLawActionStatusFunctions : BLLBasicListFunctions<DAL.CompanyLawActionStatus>
    {

        public CompanyLawActionStatusFunctions(DAL.GLAS2Context context)
            : base(context, "CompanyLawActionStatusId")
        {
        }

        protected override void SetDbSet()
        {
            this.dbSet = context.CompanyLawActionStatus;
        }
    }
}
