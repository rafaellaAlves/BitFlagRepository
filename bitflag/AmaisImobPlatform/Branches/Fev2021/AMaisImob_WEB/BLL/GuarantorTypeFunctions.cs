using AMaisImob_DB.Models;
using AMaisImob_WEB.BLL.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AMaisImob_WEB.BLL
{
    public class GuarantorTypeFunctions : BLLBasicListFunctions<GuarantorType, GuarantorType>
    {
        public GuarantorTypeFunctions(AMaisImob_HomologContext context) : base(context, "GuarantorTypeId")
        {
        }

        public override List<GuarantorType> GetDataViewModel(IEnumerable<GuarantorType> data)
        {
            return data.ToList();
        }

        public override GuarantorType GetDataViewModel(GuarantorType data)
        {
            return data;
        }

        protected override void SetDbSet()
        {
            this.dbSet = context.GuarantorType;
        }
    }
}
