using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DB.Models;
using BLL;

namespace WEB.BLL
{
    public class PaymentWayFunctions : BLLBasicFunctions<DB.Models.PaymentWay, DB.Models.PaymentWay>
    {
        public PaymentWayFunctions(Insurance_HomologContext context) 
            : base(context, "PaymentWayId")
        {
        }

        public override int Create(PaymentWay model)
        {
            throw new NotImplementedException();
        }

        public override void Delete(object id)
        {
            throw new NotImplementedException();
        }

        public override List<PaymentWay> GetDataViewModel(IEnumerable<PaymentWay> data)
        {
            return data.ToList();
        }

        public override PaymentWay GetDataViewModel(PaymentWay data)
        {
            return data;
        }

        public override void Update(PaymentWay model)
        {
            throw new NotImplementedException();
        }

        protected override void SetDbSet()
        {
            this.dbSet = context.PaymentWay;
        }
    }
}
