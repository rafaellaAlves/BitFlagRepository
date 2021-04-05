using AMaisImob_DB.Models;
using AMaisImob_WEB.Models;
using AMaisImob_WEB.Models.GuarantorProvider;
using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AMaisImob_WEB.BLL
{
    public class CompanyGuarantorProviderAPIFunctions : BLLBasicFunctions<CompanyGuarantorProviderApi, CompanyGuarantorProviderApi>
    {

        public CompanyGuarantorProviderAPIFunctions(AMaisImob_DB.Models.AMaisImob_HomologContext context)
          : base(context, "GuarantorProviderId")
        {

        }

        public override int Create(CompanyGuarantorProviderApi model)
        {
            throw new NotImplementedException();
        }

        public override void Delete(object id)
        {
            throw new NotImplementedException();
        }

        public override List<CompanyGuarantorProviderApi> GetDataViewModel(IEnumerable<CompanyGuarantorProviderApi> data)
        {
            return data.ToList();
        }

        public override CompanyGuarantorProviderApi GetDataViewModel(CompanyGuarantorProviderApi data)
        {
            return data;
        }

        public override void Update(CompanyGuarantorProviderApi model)
        {
            throw new NotImplementedException();
        }


        protected override void SetDbSet()
        {
            this.dbSet = context.CompanyGuarantorProviderApi;
        }
    }
}
