using AMaisImob_DB.Models;
using AMaisImob_WEB.Models;
using AMaisImob_WEB.Models.GuarantorProvider;
using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AMaisImob_WEB.BLL.GuarantorProvider
{
    public class GuarantorProviderFunctions : BLLBasicFunctions<AMaisImob_DB.Models.GuarantorProvider, AMaisImob_DB.Models.GuarantorProvider>
    {
        public GuarantorProviderFunctions(AMaisImob_DB.Models.AMaisImob_HomologContext context)
            : base(context, "GuarantorProviderId")
        {

        }


        public override int Create(AMaisImob_DB.Models.GuarantorProvider model)
        {
            throw new NotImplementedException();
        }

        public override void Delete(object id)
        {
            throw new NotImplementedException();
        }

        public override List<AMaisImob_DB.Models.GuarantorProvider> GetDataViewModel(IEnumerable<AMaisImob_DB.Models.GuarantorProvider> data)
        {
            return data.ToList();
        }

        public override AMaisImob_DB.Models.GuarantorProvider GetDataViewModel(AMaisImob_DB.Models.GuarantorProvider data)
        {
            return data;
        }

        public override void Update(AMaisImob_DB.Models.GuarantorProvider model)
        {
            throw new NotImplementedException();
        }


        protected override void SetDbSet()
        {
            this.dbSet = context.GuarantorProvider;
        }

    }
}
