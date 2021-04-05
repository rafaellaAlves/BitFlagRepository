using AMaisImob_DB.Models;
using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AMaisImob_WEB.BLL
{
    public class StatusTypeFunctions : BLL.Shared.BLLBasicListFunctions<StatusType, StatusType>
    {
        public StatusTypeFunctions(AMaisImob_HomologContext context) : base(context, "StatusTypeId")
        {
        }

        public override List<StatusType> GetDataViewModel(IEnumerable<StatusType> data) => data.ToList();

        public override StatusType GetDataViewModel(StatusType data) => data;

        public StatusType GetByExternalCode(string externalCode) => this.dbSet.SingleOrDefault(x => x.ExternalCode == externalCode);

        public IEnumerable<StatusType> GetByExternalCode(params string[] externalCode) => this.dbSet.Where(x => externalCode.Contains(x.ExternalCode));

        protected override void SetDbSet() => this.dbSet = context.StatusType;
    }
}
