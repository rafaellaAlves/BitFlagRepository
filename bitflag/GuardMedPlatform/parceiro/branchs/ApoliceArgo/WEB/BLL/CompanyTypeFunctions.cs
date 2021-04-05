using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLL;
using DB.Models;
namespace WEB.BLL
{
    public class CompanyTypeFunctions : BLLBasicFunctions<CompanyType, CompanyType>
    {
        public CompanyTypeFunctions(Insurance_HomologContext context) 
            : base(context, "CompanyTypeId")
        {
        }

        public override int Create(CompanyType model)
        {
            throw new NotImplementedException();
        }

        public override void Delete(object id)
        {
            throw new NotImplementedException();
        }

        public override List<CompanyType> GetDataViewModel(IEnumerable<CompanyType> data)
        {
            return data.ToList();
        }

        public override CompanyType GetDataViewModel(CompanyType data)
        {
            return data;
        }

        public CompanyType GetDataByExternalCode(string externalCode)
        {
            return this.dbSet.Single(x => x.ExternalCode == externalCode);
        }

        public override void Update(CompanyType model)
        {
            throw new NotImplementedException();
        }

        protected override void SetDbSet()
        {
            this.dbSet = context.CompanyType;
        }
    }
}
