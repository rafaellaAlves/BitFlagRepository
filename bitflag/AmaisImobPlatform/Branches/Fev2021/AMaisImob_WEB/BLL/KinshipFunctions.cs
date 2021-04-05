using AMaisImob_DB.Models;
using AMaisImob_WEB.BLL.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AMaisImob_WEB.BLL
{
    public class KinshipFunctions : BLLBasicListFunctions<Kinship, Kinship>
    {
        public KinshipFunctions(AMaisImob_HomologContext context) : base(context, "KinshipId")
        {
        }

        public override List<Kinship> GetDataViewModel(IEnumerable<Kinship> data)
        {
            throw new NotImplementedException();
        }

        public override Kinship GetDataViewModel(Kinship data)
        {
            throw new NotImplementedException();
        }

        protected override void SetDbSet()
        {
            this.dbSet = context.Kinship;
        }
    }
}
