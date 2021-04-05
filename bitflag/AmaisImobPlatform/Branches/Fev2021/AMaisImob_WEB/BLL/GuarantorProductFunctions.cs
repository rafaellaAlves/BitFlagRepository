using AMaisImob_DB.Models;
using AMaisImob_WEB.Models;
using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AMaisImob_WEB.BLL
{
    public class GuarantorProductFunctions : BLLBasicFunctions<GuarantorProduct, GuarantorProduct>
    {
        public GuarantorProductFunctions(AMaisImob_DB.Models.AMaisImob_HomologContext context)
           : base(context, "GuarantorProductId")
        {

        }

        public override int Create(GuarantorProduct model)
        {
            throw new NotImplementedException();
        }

        public override void Delete(object id)
        {
            throw new NotImplementedException();
        }

        public override List<GuarantorProduct> GetDataViewModel(IEnumerable<GuarantorProduct> data)
        {
            return data.ToList();
        }

        public override GuarantorProduct GetDataViewModel(GuarantorProduct data)
        {
            return data;
        }

        public override void Update(GuarantorProduct model)
        {
            throw new NotImplementedException();
        }

        protected override void SetDbSet()
        {
            this.dbSet = context.GuarantorProduct;
        }

        public GuarantorProduct GetDataByExternalCode(string externalCode) => this.dbSet.FirstOrDefault(x => x.ExternalCode == externalCode);
    }
}
