using AMaisImob_DB.Models;
using AMaisImob_WEB.BLL.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AMaisImob_WEB.BLL
{
    public class MartialStatusFunctions : BLLBasicListFunctions<MartialStatus, MartialStatus>
    {
        public MartialStatusFunctions(AMaisImob_HomologContext context) : base(context, "MartialStatusId")
        {
        }

        public override List<MartialStatus> GetDataViewModel(IEnumerable<MartialStatus> data)
        {
            throw new NotImplementedException();
        }

        public override MartialStatus GetDataViewModel(MartialStatus data)
        {
            throw new NotImplementedException();
        }

        protected override void SetDbSet()
        {
            this.dbSet = context.MartialStatus;
        }
    }
}
