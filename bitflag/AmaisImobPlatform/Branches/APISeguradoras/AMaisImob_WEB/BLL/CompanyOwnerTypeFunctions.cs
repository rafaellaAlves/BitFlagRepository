using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLL;
using AMaisImob_DB.Models;
namespace AMaisImob_WEB.BLL
{
    public class CompanyOwnerTypeFunctions : BLLBasicFunctions<CompanyOwnerType, CompanyOwnerType>
    {
        public CompanyOwnerTypeFunctions(AMaisImob_HomologContext context)
            : base(context, "CompanyOwnerTypeId")
        {
        }

        public override int Create(CompanyOwnerType model)
        {
            throw new NotImplementedException();
        }

        public override void Delete(object id)
        {
            throw new NotImplementedException();
        }

        public override List<CompanyOwnerType> GetDataViewModel(IEnumerable<CompanyOwnerType> data)
        {
            return data.ToList();
        }

        public override CompanyOwnerType GetDataViewModel(CompanyOwnerType data)
        {
            return data;
        }

        public override void Update(CompanyOwnerType model)
        {
            throw new NotImplementedException();
        }

        protected override void SetDbSet()
        {
            this.dbSet = context.CompanyOwnerType;
        }
    }
}
