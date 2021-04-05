using AMaisImob_DB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AMaisImob_WEB.BLL
{
    public class PaymentTypeFunctions : BLL.Shared.BLLBasicListFunctions<PaymentType, PaymentType>
    {
        public PaymentTypeFunctions(AMaisImob_HomologContext context) : base(context, "PaymentTypeId")
        {
        }

        public override List<PaymentType> GetDataViewModel(IEnumerable<PaymentType> data)
        {
            return data.ToList();
        }

        public override PaymentType GetDataViewModel(PaymentType data)
        {
            return data;
        }

        public PaymentType GetByExternalCode(string externalCode)
        {
            return this.dbSet.SingleOrDefault(x => x.ExternalCode == externalCode);
        }

        protected override void SetDbSet()
        {
            this.dbSet = context.PaymentType;
        }
    }
}
