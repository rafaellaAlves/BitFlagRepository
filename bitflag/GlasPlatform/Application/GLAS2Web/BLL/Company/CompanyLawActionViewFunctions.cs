using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL;

namespace BLL.Company
{
    public class CompanyLawActionViewFunctions : BLLBasicFunctions<DAL.CompanyLawActionView, DAL.CompanyLawActionView>
    {
        public CompanyLawActionViewFunctions(DAL.GLAS2Context context)
           : base(context, "CompanyLawActionId")
        {
        }

        public override int Create(CompanyLawActionView model)
        {
            throw new NotImplementedException();
        }

        public override void Delete(object id)
        {
            throw new NotImplementedException();
        }

        public override List<CompanyLawActionView> GetDataViewModel(IQueryable<CompanyLawActionView> data)
        {
            return data.ToList();
        }

        public override CompanyLawActionView GetDataViewModel(CompanyLawActionView data)
        {
            return data;
        }

        public override void Update(CompanyLawActionView model)
        {
            throw new NotImplementedException();
        }

        protected override void SetDbSet()
        {
            this.dbSet = context.CompanyLawActionView;
        }
    }
}
