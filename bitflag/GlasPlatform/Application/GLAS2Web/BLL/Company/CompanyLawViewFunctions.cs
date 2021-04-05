using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL;

namespace BLL.Company
{
    public class CompanyLawViewFunctions : BLLBasicFunctions<DAL.CompanyLawView, DAL.CompanyLawView>
    {
        public CompanyLawViewFunctions(DAL.GLAS2Context context)
           : base(context, "LawId")
        {
        }

        public override int Create(CompanyLawView model)
        {
            throw new NotImplementedException();
        }

        public override void Delete(object id)
        {
            throw new NotImplementedException();
        }

        public override List<CompanyLawView> GetDataViewModel(IQueryable<CompanyLawView> data)
        {
            return data.ToList(); 
        }

        public override CompanyLawView GetDataViewModel(CompanyLawView data)
        {
            return data;
        }

        public override void Update(CompanyLawView model)
        {
            throw new NotImplementedException();
        }

        protected override void SetDbSet()
        {
            this.dbSet = context.CompanyLawView;
        }
    }
}
